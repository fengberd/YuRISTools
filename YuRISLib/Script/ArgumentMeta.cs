namespace YuRIS.Script
{
    public class ArgumentMeta
    {
        public string Name;
        public ushort WTF;

        public override string ToString() => WTF.ToString("X4") + " " + Name;
    }
}
