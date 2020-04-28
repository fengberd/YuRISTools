namespace YuRIS.Package
{
    public class YPFEntry
    {
        public int Size;
        public string Name;
        public byte[] Data { get; private set; }

        public uint Hash = 0;
        public bool Compressed = false;
        public int CompressedSize = 0;

        public YPFEntryType Type;

        public YPFEntry() { }

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
