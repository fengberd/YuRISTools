using System;
using System.IO;
using System.Linq;
using System.Text;

namespace YuRIS.Script
{
    public class Argument
    {
        public static Encoding ArgumentEncoding = Encoding.GetEncoding("SHIFT-JIS");

        public ushort Type;
        public ushort Index;

        public string StringValue = null;

        public byte[] RawData;

        public override string ToString() => StringValue ?? string.Join(" ", RawData.Select(b => b.ToString("X2")));

        public bool EnsurePureString()
        {
            if (RawData.Length < 5 || RawData[0] != 'M')
            {
                return false;
            }
            if (BitConverter.ToUInt16(RawData, 1) != RawData.Length - 3)
            {
                throw new Exception("String length mismatch, there could be some control code within the call");
            }
            return true;
        }

        public string GetString() => Encoding.GetEncoding("SHIFT-JIS").GetString(RawData, 4, BitConverter.ToUInt16(RawData, 1) - 2);

        public void LoadString(string val)
        {
            val = '"' + val + '"';
            using (var ms = new MemoryStream())
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write('M');
                writer.Write((ushort)ArgumentEncoding.GetByteCount(val));
                writer.Write(ArgumentEncoding.GetBytes(val));
                RawData = ms.ToArray();
            }
        }
    }
}
