using System;
using System.IO;
using System.Linq;

namespace YuRIS.Script.Argument
{
    public class FloatArgument : IArgument
    {
        public double Value;

        public override void Load(BinaryReader reader, int size)
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
            case 'V':
            case 'v':
            case 'H':
                Variable = reader.ReadChar() + type + string.Join("", reader.ReadBytes(length - 1).Select(b => b.ToString("X2")));
                break;
            case 'B': // 1
            case 'W': // 2
            case 'I': // 4
            case 'F': // 8
                var buffer = new byte[8];
                reader.Read(buffer, 0, length);
                Value = BitConverter.ToDouble(buffer, 0);
                break;
            default:
                throw new Exception("LOL");
            }
        }

        public override string ToString() => Value.ToString();
    }
}
