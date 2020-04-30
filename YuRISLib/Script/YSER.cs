using System.IO;
using System.Text;
using System.Collections.Generic;

namespace YuRIS.Script
{
    public class YSER
    {
        public uint Engine = 481;

        public List<string> Data = new List<string>();
        public Encoding Encoding = Encoding.GetEncoding("SHIFT-JIS");

        public YSER() { }

        public YSER(BinaryReader reader, Encoding encoding = null)
        {
            if (encoding != null)
            {
                Encoding = encoding;
            }

            if (Encoding.GetString(reader.ReadBytes(4)) != "YSER")
            {
                throw new InvalidDataException("YSER structure mismatch");
            }

            Engine = reader.ReadUInt32();
            if (Engine < 234 || Engine > 490)
            {
                throw new InvalidDataException("Unsupported YSER engine version: " + Engine);
            }

            var stringCount = reader.ReadInt64();
            using (var ms = new MemoryStream())
            {
                for (long i = 0; i < stringCount; i++)
                {
                    ms.SetLength(0);
                    reader.ReadInt32(); // ?
                    byte b;
                    while ((b = reader.ReadByte()) != 0)
                    {
                        ms.WriteByte(b);
                    }
                    Data.Add(Encoding.GetString(ms.ToArray()));
                }
            }
        }
    }
}
