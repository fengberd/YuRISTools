using System;
using System.IO;
using System.Linq;
using System.Text;

namespace YuRIS.Script.Argument
{
    public class ExpressionArgument : IArgument
    {
        public string Value;

        public override void Load(BinaryReader reader, int size)
        {
            var sb = new StringBuilder();
            while (size > 0)
            {
                var type = reader.ReadChar();
                int length = reader.ReadUInt16();
                size -= 3;

                if (length > size)
                {
                    length = size;
                }
                size -= length;

                switch (type)
                {
                case 'v':
                case 'V':
                case 'H':
                    sb.Append(reader.ReadChar()).Append(type);
                    if (length > 0)
                    {
                        sb.Append(string.Join("", reader.ReadBytes(length - 1).Select(b => b.ToString("X2"))));
                    }
                    break;
                case 'B': // 1
                case 'W': // 2
                case 'I': // 4
                case 'L': // 8
                    var buffer = new byte[8];
                    reader.Read(buffer, 0, length);
                    sb.Append(" ").Append(BitConverter.ToInt64(buffer, 0).ToString());
                    break;
                case '+':
                case '-':
                case '*':
                case '/':
                case '%':
                case '=':
                case '!':
                case '>':
                case '<':
                case '&':
                case '|':
                    if(length != 0)
                    {
                        throw new Exception("WTF");
                    }
                    sb.Append(type);
                    break;
                case ',':
                case 's':
                case 'S':
                case 'A':
                case 'R':
                case 'F':
                case 'Z':
                case ')':
                    if(length > 0)
                    {
                        sb.Append(' ').Append('[').Append(type).Append('=').Append(string.Join("", reader.ReadBytes(length).Select(b => b.ToString("X2")))).Append(']');
                    }
                    break;
                case 'M':
                    if (length > 0)
                    {
                        sb.Append(' ').Append(Encoding.GetEncoding("SHIFT-JIS").GetString(reader.ReadBytes(length)));
                    }
                    break;
                default:
                    throw new Exception("LOL");
                }
            }
            Value = sb.ToString();
        }

        public override string ToString() => Value;
    }
}
