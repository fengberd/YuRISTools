using System.Linq;

namespace YuRIS.Script
{
    public class Instruction
    {
        public byte Code;
        public ushort WTF;
        public CodeMeta Meta;

        public Argument[] Arguments;

        public override string ToString() => Code.ToString("X2") + " [" + string.Join(", ", Arguments.Select(a => a.ToString())) + "]";
    }
}
