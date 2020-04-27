using System.IO;
using System.Text;
using System.Collections.Generic;

namespace YuRIS.Package
{
    public class YPF
    {
        public static byte[] YPFHeader = new byte[] { 0x4D, 0x50, 0x4B, 0x00, 0x00, 0x00, 0x02, 0x00 };

        public static YPF ReadFile(BinaryReader reader)
        {
            if (Encoding.UTF8.GetString(reader.ReadBytes(3)) != "YPF" || reader.ReadByte() != 0)
            {
                throw new InvalidDataException("YPF header mismatch");
            }
            reader.BaseStream.Position += 4;

            var result = new YPF();
            int count = reader.ReadInt32();
            if (count <= 0)
            {
                throw new InvalidDataException("YPF structure mismatch");
            }

            List<long> offsets = new List<long>();
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Position += YPFEntry.PrePadding.Length;
                if (reader.ReadInt32() != i)
                {
                    throw new InvalidDataException("YPF index mismatch");
                }

                offsets.Add(reader.ReadInt64());
                long size = reader.ReadInt64();
                if (size < 0 || size > int.MaxValue || reader.ReadInt64() != size)
                {
                    throw new InvalidDataException("Unsupported YPF structure");
                }

                var name = Encoding.UTF8.GetString(reader.ReadBytes(YPFEntry.PostPadding.Length));
                int index = name.IndexOf('\0');
                if (index >= 0)
                {
                    name = name.Remove(index);
                }

                result.Entries.Add(new YPFEntry(name, (int)size));
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Position = offsets[i];
                result.Entries[i].SetData(reader.ReadBytes(result.Entries[i].Size));
            }
            return result;
        }

        public List<YPFEntry> Entries = new List<YPFEntry>();

        public void Write(BinaryWriter writer)
        {
            writer.Write(YPFHeader);
            writer.Write(Entries.Count);

            int i = 0;
            long offset = YPFHeader.Length + 4 + Entries.Count * YPFEntry.EntrySize;

            foreach (var entry in Entries)
            {
                writer.Write(YPFEntry.PrePadding);
                writer.Write(i++);

                writer.Write(offset);

                offset += entry.Size;

                writer.Write((long)entry.Size);
                writer.Write((long)entry.Size); // Compressed size or sth?

                var name = Encoding.UTF8.GetBytes(entry.Name);
                writer.Write(name, 0, name.Length);
                writer.Write(YPFEntry.PostPadding, 0, YPFEntry.PostPadding.Length - name.Length);
            }

            foreach (var entry in Entries)
            {
                writer.Write(entry.Data, 0, entry.Size);
            }
        }
    }
}
