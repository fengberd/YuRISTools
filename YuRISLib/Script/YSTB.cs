using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

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

        public uint Engine = 481;
        public byte[] WTFData = null;

        public List<Instruction> Instructions = new List<Instruction>();

        public YSTB(BinaryReader reader, YSCM yscm)
        {
            if (Encoding.UTF8.GetString(reader.ReadBytes(4)) != "YSTB")
            {
                throw new InvalidDataException("YSTB structure mismatch");
            }

            Engine = reader.ReadUInt32();
            if (Engine < 234 || Engine > 490)
            {
                throw new InvalidDataException("Unsupported YSTB engine version: " + Engine);
            }

            int instructionCount = reader.ReadInt32(), codeSize = reader.ReadInt32(),
                argumentSize = reader.ReadInt32(), resourceSize = reader.ReadInt32(),
                wtfSize = reader.ReadInt32();

            reader.BaseStream.Position = 32 + codeSize;

            long lastOff = 0;
            var args = new Queue<Argument>();
            for (int i = 0; i < argumentSize; i += 12)
            {
                Argument arg = new Argument()
                {
                    Index = reader.ReadUInt16(),
                    Type = reader.ReadUInt16()
                };
                uint size = reader.ReadUInt32(), offset = reader.ReadUInt32();
                if (size == 0)
                {
                    arg.RawData = new byte[0];
                }
                else
                {
                    long pos = reader.BaseStream.Position;
                    reader.BaseStream.Position = 32 + codeSize + argumentSize + offset;
                    if (lastOff != 0 && lastOff != reader.BaseStream.Position)
                    {
                        // throw new Exception("WTF");
                    }
                    arg.RawData = reader.ReadBytes((int)size);
                    lastOff = reader.BaseStream.Position;
                    reader.BaseStream.Position = pos;
                }
                args.Enqueue(arg);
            }

            reader.BaseStream.Position = 32;

            for (int i = 0; i < instructionCount; i++)
            {
                var inst = new Instruction()
                {
                    Code = reader.ReadByte(),
                    Arguments = new Argument[reader.ReadByte()],
                    WTF = reader.ReadUInt16()
                };
                inst.Meta = yscm[inst.Code];
                for (int j = 0; j < inst.Arguments.Length; j++)
                {
                    inst.Arguments[j] = args.Dequeue();
                }
                Instructions.Add(inst);
            }

            reader.BaseStream.Position = 32 + codeSize + argumentSize + resourceSize;
            WTFData = reader.ReadBytes(wtfSize);
        }

        public List<string> ExportString()
        {
            var result = new List<string>();
            foreach (var code in Instructions)
            {
                if (code.Meta.Name == "WORD")
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
                else if (code.Meta.Name == "_" && code.Arguments.Length == 1 && code.Meta.Arguments[0].WTF == 0x03 && code.Arguments[0].RawData[0] == 'M')
                {
                    if (BitConverter.ToUInt16(code.Arguments[0].RawData, 1) != code.Arguments[0].RawData.Length - 3)
                    {
                        throw new Exception("String length mismatch, there could be some control code within the call");
                    }
                    result.Add(Encoding.GetEncoding("SHIFT-JIS").GetString(code.Arguments[0].RawData).Substring(3));
                }
            }
            return result;
        }

        public int Patch(List<string> patch)
        {
            int i = 0;
            foreach (var code in Instructions)
            {
                if (code.Meta.Name == "WORD")
                {
                    if (code.Arguments.Length != 1)
                    {
                        throw new Exception("Bad argument count");
                    }
                    if (patch[i] != null)
                    {
                        code.Arguments[0].RawData = Encoding.Default.GetBytes(patch[i]);
                    }
                    if (++i >= patch.Count)
                    {
                        break;
                    }
                }
                else if (code.Meta.Name == "_" && code.Arguments.Length == 1 && code.Meta.Arguments[0].WTF == 0x03 && code.Arguments[0].RawData[0] == 'M')
                {
                    if (BitConverter.ToUInt16(code.Arguments[0].RawData, 1) != code.Arguments[0].RawData.Length - 3)
                    {
                        throw new Exception("String length mismatch, there could be some control code within the call");
                    }
                    if (patch[i] != null)
                    {
                        using (var ms = new MemoryStream())
                        using (var writer = new BinaryWriter(ms))
                        {
                            writer.Write('M');
                            writer.Write((ushort)patch[i].Length);
                            writer.Write(Encoding.GetEncoding("SHIFT-JIS").GetBytes(patch[i]));
                            code.Arguments[0].RawData = ms.ToArray();
                        }
                    }
                    if (++i >= patch.Count)
                    {
                        break;
                    }
                }
            }
            return i;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(new char[] { 'Y', 'S', 'T', 'B' });
            writer.Write(Engine);

            writer.Write(Instructions.Count);

            using (var code = new MemoryStream())
            using (var argument = new MemoryStream())
            using (var resource = new MemoryStream())
            using (var codeWriter = new BinaryWriter(code))
            using (var argumenteWriter = new BinaryWriter(argument))
            using (var resourceWriter = new BinaryWriter(resource))
            {
                foreach (var i in Instructions)
                {
                    codeWriter.Write(i.Code);
                    codeWriter.Write((byte)i.Arguments.Length);
                    codeWriter.Write(i.WTF);
                    foreach (var arg in i.Arguments)
                    {
                        argumenteWriter.Write(arg.Index);
                        argumenteWriter.Write(arg.Type);
                        argumenteWriter.Write(arg.RawData.Length);
                        if (arg.RawData.Length == 0 || (i.Meta.Name == "RETURNCODE" && arg.RawData.Length == 1 && arg.RawData[0] == 'M'))
                        {
                            argumenteWriter.Write(0);
                        }
                        else
                        {
                            argumenteWriter.Write((uint)resource.Position);
                            resourceWriter.Write(arg.RawData);
                        }
                    }
                }

                writer.Write((uint)code.Length);
                writer.Write((uint)argument.Length);
                writer.Write((uint)resource.Length);
                writer.Write((uint)WTFData.Length);

                writer.BaseStream.Position = 32;
                code.Position = argument.Position = resource.Position = 0;

                code.CopyTo(writer.BaseStream);
                argument.CopyTo(writer.BaseStream);
                resource.CopyTo(writer.BaseStream);
                writer.Write(WTFData);
            }
        }

        public string Dump()
        {
            var sb = new StringBuilder();
            string indent = "";
            foreach (var code in Instructions)
            {
                if (code.Meta.Name == "IFEND" || code.Meta.Name == "IFBLEND" || code.Meta.Name == "LOOPEND")
                {
                    indent = indent.Substring(1);
                }
                sb.Append(indent);
                if (code.Meta.Name == "GOSUB")
                {
                    sb.Append('\\').Append(code.Arguments[0].ToString().Trim('"')).Append("(");
                    for (int i = 1; i < code.Arguments.Length; i++)
                    {
                        sb.Append(code.Arguments[i].ToString()).Append(", ");
                    }
                    if (code.Arguments.Length > 1)
                    {
                        sb.Remove(sb.Length - 2, 2);
                    }
                    sb.Append(")\n");
                }
                else
                {
                    sb.Append(code.Meta.Name).Append('[');
                    for (int i = 0; i < code.Arguments.Length; i++)
                    {
                        if (code.Meta.Arguments.Count > code.Arguments[i].Index)
                        {
                            sb.Append(code.Meta.Arguments[code.Arguments[i].Index].Name).Append('=');
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
                if (code.Meta.Name == "IF" || code.Meta.Name == "ELSE" || code.Meta.Name == "LOOP")
                {
                    indent += "\t";
                }
            }
            return sb.ToString();
        }
    }
}
