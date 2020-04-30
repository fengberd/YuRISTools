using System;
using System.IO;
using System.Text;
using System.Linq;
using System.IO.Compression;
using System.Collections.Generic;

namespace YuRIS.Package
{
    public class YPF
    {
        public static Dictionary<int, int> NameLengthTable = new Dictionary<int, int>()
        {
            { 3, 72 }, { 6, 53 }, { 9, 11 }, { 12, 16 },
            { 13, 19 }, { 17, 25 }, { 21, 27 }, { 28, 30 },
            { 32, 35 }, { 38, 41 }, { 44, 47 }, { 46, 50 }
        };
        public static byte[] YPFHeader = new byte[] { 0x59, 0x50, 0x46, 0x00 };

        static YPF()
        {
            NameLengthTable.ToList().ForEach(kv => NameLengthTable.Add(kv.Value, kv.Key));
        }

        public static YPF ReadFile(BinaryReader reader, Func<byte[], uint> nameHash = null, Func<byte[], uint> dataHash = null)
        {
            if (Encoding.UTF8.GetString(reader.ReadBytes(3)) != "YPF" || reader.ReadByte() != 0)
            {
                throw new InvalidDataException("YPF header mismatch");
            }

            int version = reader.ReadInt32();
            if (version < 234 || version > 490)
            {
                throw new InvalidDataException("Unsupported YPF engine version: " + version);
            }

            var result = new YPF();
            int count = reader.ReadInt32();
            if (count <= 0)
            {
                throw new InvalidDataException("YPF structure mismatch");
            }
            
            reader.BaseStream.Position = 32;

            List<long> offsets = new List<long>();
            for (int i = 0; i < count; i++)
            {
                uint hash = reader.ReadUInt32();
                int length = reader.ReadByte() ^ 0xff;
                if (NameLengthTable.ContainsKey(length))
                {
                    length = NameLengthTable[length];
                }

                var name = reader.ReadBytes(length).Select(c => (byte)~c).ToArray();
                if (nameHash != null && nameHash(name) != hash)
                {
                    throw new InvalidDataException("File name hash mismatch");
                }

                var entry = new YPFEntry()
                {
                    Name = Encoding.GetEncoding("SHIFT-JIS").GetString(name),
                    Type = (ResourceType)reader.ReadByte(),
                    Compressed = reader.ReadByte() != 0,
                    Size = reader.ReadInt32(),
                    CompressedSize = reader.ReadInt32()
                };
                result.Entries.Add(entry);

                if (entry.Size < 0 || (entry.Size != entry.CompressedSize && !entry.Compressed))
                {
                    throw new InvalidDataException("YPF structure mismatch");
                }

                offsets.Add(version >= 480 ? reader.ReadInt64() : reader.ReadInt32());
                entry.Hash = version >= 473 ? reader.ReadUInt32() : 0;
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Position = offsets[i];
                var entry = result.Entries[i];
                var data = reader.ReadBytes(entry.CompressedSize);
                if (dataHash != null && entry.Hash!=0 && dataHash(data) != entry.Hash)
                {
                    throw new InvalidDataException("File data hash mismatch");
                }
                if (entry.Compressed)
                {
                    if (data[0] != 0x78)
                    {
                        throw new InvalidDataException("Invalid compressed data");
                    }
                    using (var ms = new MemoryStream())
                    using (var input = new MemoryStream(data))
                    using (var deflate = new DeflateStream(input, CompressionMode.Decompress, false))
                    {
                        input.Position = 2;
                        deflate.CopyTo(ms);
                        if (ms.Length != entry.Size)
                        {
                            throw new InvalidDataException("YPF decompression failed");
                        }
                        entry.SetData(ms.ToArray());
                    }
                }
                else
                {
                    entry.SetData(data);
                }
            }
            return result;
        }

        public List<YPFEntry> Entries = new List<YPFEntry>();

        public void Write(BinaryWriter writer, int engine, Func<byte[], uint> nameHash, Func<byte[], uint> dataHash)
        {
            writer.Write(YPFHeader);
            writer.Write(engine);
            writer.Write(Entries.Count);
            writer.BaseStream.Position = 32;

            List<long> entryPosition = new List<long>();
            foreach (var entry in Entries)
            {
                var name = Encoding.GetEncoding("SHIFT-JIS").GetBytes(entry.Name);
                writer.Write(nameHash(name));

                int length = entry.Name.Length;
                if (NameLengthTable.ContainsKey(length))
                {
                    length = NameLengthTable[length];
                }
                writer.Write((byte)(255 - length));
                writer.Write(name.Select(c => (byte)~c).ToArray());

                writer.Write((byte)entry.Type);
                writer.Write(entry.Compressed);
                writer.Write(entry.Size);

                entryPosition.Add(writer.BaseStream.Position);
                writer.Write(0); // Compressed size placeholder
                writer.Write(0L); // Data offset placeholder
                writer.Write(0); // Hash placeholder
            }

            for (int i = 0; i < Entries.Count; i++)
            {
                var entry = Entries[i];
                var data = entry.Data;
                if (entry.Compressed)
                {
                    using (var ms = new MemoryStream())
                    {
                        ms.WriteByte(0x78);
                        ms.WriteByte(0xDA);
                        using (var deflate = new DeflateStream(ms, CompressionLevel.Optimal, true))
                        {
                            deflate.Write(entry.Data, 0, entry.Size);
                        }
                        data = ms.ToArray();
                    }
                }
                writer.Write(data);

                long dataOffset = writer.BaseStream.Position;
                writer.BaseStream.Position = entryPosition[i];

                entry.CompressedSize = data.Length;
                writer.Write(entry.CompressedSize);
                if(engine >= 480)
                {
                    writer.Write(dataOffset - data.Length);
                }
                else
                {
                    writer.Write((int)(dataOffset - data.Length));
                }
                writer.Write(dataHash(data));

                writer.BaseStream.Position = dataOffset;
            }
        }
    }
}
