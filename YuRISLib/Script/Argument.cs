using System.Linq;

namespace YuRIS.Script
{
    public class Argument
    {
        public ushort Type;
        public ushort Index;

        public string StringValue = null;

        public byte[] RawData;

        public override string ToString() => StringValue ?? string.Join(" ", RawData.Select(b => b.ToString("X2")));
    }
}
