using System.IO;
using System.Linq;

namespace YuRIS.Script.Argument
{
    public class StringArgument : IArgument
    {
        public byte[] Value;

        public override void Load(BinaryReader reader, int size)
        {
            Value = reader.ReadBytes(size);
        }

        public override string ToString() => string.Join(" ", Value.Select(b => b.ToString("X2")));
    }
}
