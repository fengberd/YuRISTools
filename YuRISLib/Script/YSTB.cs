using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using YuRIS.Script.Argument;

namespace YuRIS.Script
{
    public class YSTB
    {
        public static byte[] Cipher(BinaryReader reader, int key)
        {
            if (Encoding.UTF8.GetString(reader.ReadBytes(4)) != "YSTB")
            {
                return null;
            }

            int version = reader.ReadInt32();
            if (version < 234 || version > 490)
            {
                throw new InvalidDataException("Unsupported YSTB engine version: " + version);
            }

            reader.ReadInt32(); // Skip the code count

            var keyTable = new byte[] { (byte)(key >> 24), (byte)(key >> 16), (byte)(key >> 8), (byte)key };
            int[] blockSize = new int[]
            {
                reader.ReadInt32(), reader.ReadInt32(),
                reader.ReadInt32(), reader.ReadInt32()
            };
            using (var ms = new MemoryStream())
            {
                reader.BaseStream.Position = 0;
                ms.Write(reader.ReadBytes(32), 0, 32);

                reader.BaseStream.Position = 32;
                foreach (int size in blockSize)
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

        public List<Instruction> Instructions = new List<Instruction>();

        public YSTB(BinaryReader reader)
        {
            if (Encoding.UTF8.GetString(reader.ReadBytes(4)) != "YSTB")
            {
                throw new InvalidDataException("YSTB structure mismatch");
            }

            int version = reader.ReadInt32();
            if (version < 234 || version > 490)
            {
                throw new InvalidDataException("Unsupported YSTB engine version: " + version);
            }

            int instructionCount = reader.ReadInt32(), codeSize = reader.ReadInt32(),
                argumentSize = reader.ReadInt32(), resourceSize = reader.ReadInt32(),
                wtfSize = reader.ReadInt32();

            reader.BaseStream.Position = 32 + codeSize;

            var args = new Queue<IArgument>();
            for (int i = 0; i < argumentSize; i += 12)
            {
                IArgument arg = new IArgument()
                {
                    Index = reader.ReadUInt16(),
                    Type = reader.ReadUInt16()
                };
                uint size = reader.ReadUInt32();

                long pos = reader.BaseStream.Position;

                reader.BaseStream.Position = 32 + codeSize + argumentSize + reader.ReadUInt32();
                arg.RawData = reader.ReadBytes((int)size);
                reader.BaseStream.Position = pos + 4;
                /*
                switch (type)
                {
                case 0:

                    break;
                case 1:
                    arg = new IntArgument();
                    break;
                case 2:
                    arg = new FloatArgument();
                    break;
                case 3:
                    arg = new MayStringArgument();
                    break;
                default:
                    arg = new RawArgument();
                    //reader.BaseStream.Position -= 2;
                    //Console.WriteLine("Unknown argument type: " + reader.ReadUInt16());
                    break;
                }
                */
                args.Enqueue(arg);
            }

            foreach (var arg in args)
            {
                reader.BaseStream.Position = 32 + codeSize + argumentSize + arg.ResourceOffset;
                arg.Load(reader, (int)arg.ResourceSize);
            }

            reader.BaseStream.Position = 32;

            for (int i = 0; i < instructionCount; i++)
            {
                var inst = new Instruction()
                {
                    Code = reader.ReadByte(),
                    Arguments = new IArgument[reader.ReadByte()]
                };
                reader.ReadBytes(2);
                for (int j = 0; j < inst.Arguments.Length; j++)
                {
                    inst.Arguments[j] = args.Dequeue();
                }
                Instructions.Add(inst);
            }
        }

        public List<string> ExportString(YSCM OPCodes)
        {
            var result = new List<string>();
            foreach (var code in Instructions)
            {
                var op = OPCodes[code.Code];
                if (op.Name == "WORD")
                {
                    if (code.Arguments.Length != 1)
                    {
                        throw new Exception("Bad argument count");
                    }
                    if (code.Arguments[0].Type == 0 && code.Arguments[0].RawData.Length > 0 && code.Arguments[0].RawData[0] > 0x80)
                    {
                        code.Arguments[0].StringValue = Encoding.GetEncoding("SHIFT-JIS").GetString(code.Arguments[0].RawData);
                    }
                    result.Add(code.Arguments[0].ToString());
                }
            }
            return result;
        }

        public string Dump(YSCM OPCodes)
        {
            var sb = new StringBuilder();
            string indent = "";
            foreach (var code in Instructions)
            {
                var op = OPCodes[code.Code];
                if (op.Name == "IFEND" || op.Name == "IFBLEND" || op.Name == "LOOPEND")
                {
                    indent = indent.Substring(1);
                }
                sb.Append(indent);
                if (op.Name == "GOSUB")
                {
                    sb.Append('\\').Append(code.Arguments[0].ToString().Trim('"')).Append("(");
                    for (int i = 1; i < code.Arguments.Length; i++)
                    {
                        if (code.Arguments[i].Variable != null)
                        {
                            sb.Append(code.Arguments[i].Variable);
                        }
                        else
                        {
                            sb.Append(code.Arguments[i].ToString());
                        }
                        sb.Append(", ");
                    }
                    if (code.Arguments.Length > 1)
                    {
                        sb.Remove(sb.Length - 2, 2);
                    }
                    sb.Append(")\n");
                }
                else
                {
                    sb.Append(op.Name).Append('[');
                    for (int i = 0; i < code.Arguments.Length; i++)
                    {
                        if (op.Arguments.Count > code.Arguments[i].Index)
                        {
                            sb.Append(op.Arguments[code.Arguments[i].Index].Name).Append('=');
                        }
                        if (code.Arguments[i].Variable != null)
                        {
                            sb.Append(code.Arguments[i].Variable);
                        }
                        else
                        {
                            sb.Append(code.Arguments[i].ToString());
                        }
                        sb.Append(", ");
                    }
                    if (code.Arguments.Length > 0)
                    {
                        sb.Remove(sb.Length - 2, 2);
                    }
                    sb.Append("]\n");
                }
                if (op.Name == "IF" || op.Name == "ELSE" || op.Name == "LOOP")
                {
                    indent += "\t";
                }
            }
            return sb.ToString();
        }

        public class Instruction
        {
            public byte Code;
            public IArgument[] Arguments;

            public override string ToString() => Code.ToString("X2") + " [" + string.Join(", ", Arguments.Select(a => a.ToString())) + "]";
        }
    }
}
