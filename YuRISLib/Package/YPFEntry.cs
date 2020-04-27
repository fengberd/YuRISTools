namespace YuRIS.Package
{
    public class YPFEntry
    {
        public const int EntrySize = 256;
        public static readonly byte[] PrePadding = new byte[56];
        public static readonly byte[] PostPadding = new byte[EntrySize - PrePadding.Length - 24 - 4];

        public int Size;
        public string Name;
        public byte[] Data { get; private set; }

        public YPFEntry(string name, int size)
        {
            Size = size;
            Name = name;
            Data = null;
        }

        public YPFEntry(string name, byte[] data)
        {
            Name = name;
            SetData(data);
        }

        public void SetData(byte[] data)
        {
            Data = data;
            Size = data.Length;
        }
    }
}
