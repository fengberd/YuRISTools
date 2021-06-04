using System;

namespace YuRIS
{
    public static class CheckSum
    {
        private static readonly uint[] CRC32_Table = new uint[256];

        static CheckSum()
        {
            for (uint i = 0; i < CRC32_Table.Length; i++)
            {
                uint k = i;
                for (int j = 8; j > 0; --j)
                {
                    if ((k & 1) == 1)
                    {
                        k >>= 1;
                        k ^= 0xEDB88320;
                    }
                    else
                    {
                        k >>= 1;
                    }
                }
                CRC32_Table[i] = k;
            }
        }

        public static uint CRC32(byte[] data)
        {
            uint crc = 0xffffffff;
            for (int i = 0; i < data.Length; i++)
            {
                crc = (crc >> 8) ^ CRC32_Table[(byte)((crc & 0xff) ^ data[i])];
            }
            return ~crc;
        }

        public static uint Adler32(byte[] data)
        {
            const int mod = 65521;
            uint a = 1, b = 0;
            foreach (byte c in data)
            {
                a = (a + c) % mod;
                b = (b + a) % mod;
            }
            return (b << 16) | a;
        }

        public static uint MurmurHash2(byte[] data) => MurmurHash2(data, 0);

        public static uint MurmurHash2(byte[] data, uint seed)
        {
            // https://github.com/abrandoned/murmur2/blob/master/MurmurHash2.c
            const uint m = 0x5bd1e995;
            const int r = 24;

            int len = data.Length;
            uint h = seed ^ (uint)len;

            int index = 0;
            while (len >= 4)
            {
                uint k = BitConverter.ToUInt32(data, index);

                k *= m;
                k ^= k >> r;
                k *= m;

                h *= m;
                h ^= k;

                index += 4;
                len -= 4;
            }

            if (len != 0)
            {
                if (len > 2)
                {
                    h ^= (uint)(data[index + 2] << 16);
                }
                if (len > 1)
                {
                    h ^= (uint)(data[index + 1] << 8);
                }
                h ^= data[index];
                h *= m;
            }

            h ^= h >> 13;
            h *= m;
            h ^= h >> 15;

            return h;
        }
    }
}
