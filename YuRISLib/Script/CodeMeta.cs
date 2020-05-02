using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace YuRIS.Script
{
    public class CodeMeta
    {
        public string Name;
        public List<ArgumentMeta> Arguments = new List<ArgumentMeta>();

        public CodeMeta(BinaryReader reader, Encoding encoding)
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
                    Arguments.Add(new ArgumentMeta()
                    {
                        Name = encoding.GetString(ms.ToArray()),
                        WTF = reader.ReadUInt16()
                    });
                }
            }
        }

        public override string ToString() => Name + " (" + string.Join(", ", Arguments.Select(arg => arg.ToString())) + ")";
    }
}
