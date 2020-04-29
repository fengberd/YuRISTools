using System.IO;
using System.Text;

namespace YuRIS.Script
{
    public class YSTB
    {
        public static byte[] Cipher(BinaryReader reader, int key)
        {
            if(Encoding.UTF8.GetString(reader.ReadBytes(4)) != "YSTB")
            {
                return null;
            }

            int version = reader.ReadInt32();
            if (version < 234 || version > 490)
            {
                throw new InvalidDataException("Unsupported YSTB engine version: " + version);
            }

            reader.ReadInt32(); // Skip the wtf count

            var keyTable = new byte[] { (byte)(key >> 24), (byte)(key >> 16), (byte)(key >> 8), (byte)key };
            int[] blockSize = new int[]
            {
                reader.ReadInt32(), reader.ReadInt32(),
                reader.ReadInt32(), reader.ReadInt32()
            };
            using (var ms = new MemoryStream())
            {
                reader.BaseStream.Position = 0;
                ms.Write(reader.ReadBytes(32), 0,32);

                reader.BaseStream.Position = 32;
                foreach(int size in blockSize)
                {
                    var data = reader.ReadBytes(size);
                    for (int i = 0; i < size; i++)
                    {
                        data[i] ^= keyTable[i & 3];
                    }
                    ms.Write(data, 0, size);
                }
                return ms.ToArray();
            }
        }
    }
}
