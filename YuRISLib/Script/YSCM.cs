using System.IO;
using System.Text;
using System.Collections.Generic;

namespace YuRIS.Script
{
    public class YSCM : List<CodeMeta>
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
                Add(new CodeMeta(reader, Encoding));
            }

            // TODO: Some error messages?
        }
    }
}
