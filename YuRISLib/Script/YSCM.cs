using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace YuRIS.Script
{
    public class YSCM : List<YSCM.OPCode>
    {
        public uint Engine = 481;

        public Encoding Encoding = Encoding.GetEncoding("SHIFT-JIS");

        public YSCM() { }

        public YSCM(BinaryReader reader, Encoding encoding = null)
        {
            if (encoding != null)
            {
                Encoding = encoding;
            }

            if (Encoding.GetString(reader.ReadBytes(4)) != "YSCM")
            {
                throw new InvalidDataException("YSCM structure mismatch");
            }

            Engine = reader.ReadUInt32();
            if (Engine < 234 || Engine > 490)
            {
                throw new InvalidDataException("Unsupported YSER engine version: " + Engine);
            }

            var opcodeCount = reader.ReadInt32();
            reader.ReadBytes(4);
            for (int i = 0; i < opcodeCount; i++)
            {
                Add(new OPCode(reader, Encoding));
            }

            // TODO: Some error messages?
        }

        public class OPCode
        {
            public string Name;
            public List<OPArgument> Arguments = new List<OPArgument>();

            public OPCode(BinaryReader reader, Encoding encoding)
            {
                using (var ms = new MemoryStream())
                {
                    byte b;
                    while ((b = reader.ReadByte()) != 0)
                    {
                        ms.WriteByte(b);
                    }
                    Name = encoding.GetString(ms.ToArray());
                    
                    byte count = reader.ReadByte();
                    for (int i = 0; i < count; i++)
                    {
                        ms.SetLength(0);
                        while ((b = reader.ReadByte()) != 0)
                        {
                            ms.WriteByte(b);
                        }
                        Arguments.Add(new OPArgument()
                        {
                            Name = encoding.GetString(ms.ToArray()),
                            WTF = reader.ReadUInt16()
                        });
                    }
                }
            }

            public override string ToString() => Name + " (" + string.Join(", ", Arguments.Select(arg => arg.ToString())) + ")";
        }

        public class OPArgument
        {
            public string Name;
            public ushort WTF;

            public override string ToString() => WTF.ToString("X4") + " " + Name;
        }
    }
}
