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

        public static YPF ReadFile(BinaryReader reader)
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
                int hash = reader.ReadInt32();
                int length = 255 - reader.ReadByte();
                if (NameLengthTable.ContainsKey(length))
                {
                    length = NameLengthTable[length];
                }

                var entry = new YPFEntry()
                {
                    Name = Encoding.GetEncoding("SHIFT-JIS").GetString(reader.ReadBytes(length).Select(c => (byte)~c).ToArray()),
                    Type = (YPFEntryType)reader.ReadByte(),
                    Compressed = reader.ReadByte() != 0,
                    Size = reader.ReadInt32(),
                    CompressedSize = reader.ReadInt32()
                };
                result.Entries.Add(entry);

                if (entry.Size < 0 || (entry.Size != entry.CompressedSize && !entry.Compressed))
                {
                    throw new InvalidDataException("YPF structure mismatch");
                }
                offsets.Add(reader.ReadInt64());

                hash = reader.ReadInt32();
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Position = offsets[i];
                var entry = result.Entries[i];
                if (entry.Compressed)
                {
                    if (reader.ReadByte() != 0x78)
                    {
                        throw new InvalidDataException("Invalid compressed data");
                    }
                    reader.ReadByte();
                    using (var ms = new MemoryStream())
                    using (var deflate = new DeflateStream(new MemoryStream(reader.ReadBytes(entry.CompressedSize - 2)), CompressionMode.Decompress, false))
                    {
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
                    entry.SetData(reader.ReadBytes(entry.Size));
                }
            }
            return result;
        }

        public List<YPFEntry> Entries = new List<YPFEntry>();

        public void Write(BinaryWriter writer)
        {
            writer.Write(YPFHeader);
            writer.Write(490);
            writer.Write(Entries.Count);

            List<long> entryPosition = new List<long>();
            foreach (var entry in Entries)
            {
                // TODO: Write Hash

                int length = entry.Name.Length;
                if (NameLengthTable.ContainsKey(length))
                {
                    length = NameLengthTable[length];
                }
                writer.Write((byte)(255 - length));
                writer.Write(Encoding.GetEncoding("SHIFT-JIS").GetBytes(entry.Name).Select(c => (byte)~c).ToArray());

                writer.Write((byte)entry.Type);
                writer.Write(entry.Compressed);

                writer.Write((long)entry.Size);
                entryPosition.Add(writer.BaseStream.Position);
                writer.Write((long)entry.Size); // Compressed size, placeholder

                var name = Encoding.UTF8.GetBytes(entry.Name);
                writer.Write(name, 0, name.Length);
            }

            long dataOffset = writer.BaseStream.Position;
            for (int i = 0; i < Entries.Count; i++)
            {
                writer.BaseStream.Position = dataOffset;

                var entry = Entries[i];
                if (entry.Compressed)
                {
                    writer.Write(0x78);
                    writer.Write(0x9C);
                    using (var deflate = new DeflateStream(writer.BaseStream, CompressionMode.Compress, true))
                    {
                        deflate.Write(entry.Data, 0, entry.Size);
                    }
                }
                else
                {
                    writer.Write(entry.Data, 0, entry.Size);
                }

                entry.CompressedSize = (int)(writer.BaseStream.Position - dataOffset);
                dataOffset = writer.BaseStream.Position;

                writer.BaseStream.Position = entryPosition[i];
                writer.Write(entry.CompressedSize);
                writer.Write(dataOffset);

                // TODO: Write another Hash
            }
        }
    }
}
