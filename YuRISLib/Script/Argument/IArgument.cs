using System.IO;
using System.Linq;

namespace YuRIS.Script.Argument
{
    public class IArgument
    {
        public ushort Type;
        public ushort Index;

        public string Variable = null;
        public string StringValue = null;

        public byte[] RawData;
        public uint ResourceSize;
        public uint ResourceOffset;

        public virtual void Load(BinaryReader reader, int size) { }

        public override string ToString() => StringValue ?? string.Join(" ", RawData.Select(b => b.ToString("X2")));
    }
}
