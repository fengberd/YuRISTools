using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

using YuRIS;
using YuRIS.Script;
using YuRIS.Package;

namespace YuRISTools
{
    public partial class MainForm : Form
    {
        public IDictionary<string, object> SCX_Patch = null;

        public MainForm()
        {
            InitializeComponent();
        }

        public void Log(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Log(data)));
                return;
            }
            textBox_log.AppendText(DateTime.Now.ToString("t") + " " + data + "\n");
        }

        public void Oops(Exception e)
        {
            Log(e.ToString());
            MessageBox.Show(e.ToString(), "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            var box = sender as TextBox;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                box.Text = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
            }
            else if (e.Data.GetDataPresent(DataFormats.Text))
            {
                box.Text = e.Data.GetData(DataFormats.Text) as string;
            }
        }

        private void button_ypf_unpack_Click(object sender, EventArgs e)
        {
            var files = new List<string>();
            if (Directory.Exists(textBox_ypf_unpack_input.Text))
            {
                files.AddRange(Directory.GetFiles(textBox_ypf_unpack_input.Text, "*.ypf"));
            }
            else
            {
                files.Add(textBox_ypf_unpack_input.Text);
            }
            groupBox1.Enabled = false;
            Func<byte[], uint> hashName = null, hashData = null;
            if (checkBox_ypf_verify.Checked)
            {
                if (radioButton_ypf_crc32.Checked)
                {
                    hashName = CheckSum.CRC32;
                    hashData = CheckSum.Adler32;
                }
                else
                {
                    hashData = hashName = CheckSum.MurmurHash2;
                }
            }
            var output = textBox_ypf_unpack_output.Text;
            ThreadPool.QueueUserWorkItem(s =>
            {
                int success = 0;
                foreach (var file in files)
                {
                    try
                    {
                        Log("[YPF Unpack] Unpacking " + Path.GetFileName(file) + " ...");
                        using (var reader = new BinaryReader(File.OpenRead(file)))
                        {
                            var ypf = YPF.ReadFile(reader, hashName, hashData);
                            Log("[YPF Unpack] Found " + ypf.Entries.Count + " entries.");
                            foreach (var entry in ypf.Entries)
                            {
                                Log("[YPF Unpack] Unpacking " + entry.Name + "(" + entry.Size + ") ...");
                                var path = Path.Combine(output, Path.GetFileNameWithoutExtension(file), entry.Name);
                                Directory.CreateDirectory(Path.GetDirectoryName(path));
                                File.WriteAllBytes(path, entry.Data);
                            }
                        }
                        success++;
                    }
                    catch (Exception ex) { Oops(ex); }
                }
                Log("[YPF Unpack] Complete, unpacked " + success + "/" + files.Count + " files.");
                Invoke(new Action(() => groupBox1.Enabled = true));
            });
        }

        private void button_ypf_pack_Click(object sender, EventArgs e)
        {
            try
            {
                var ypf = new YPF();
                var baseName = Path.GetFullPath(textBox_ypf_pack_input.Text).TrimEnd('\\') + "\\";
                HashSet<string> non_compress = new HashSet<string>(textBox_ypf_pack_no_compress.Text.ToLower().Split('/').Where(s => s.Trim() != "")),
                    non_packing = new HashSet<string>(textBox_ypf_pack_no_packing.Text.ToLower().Split('/').Where(s => s.Trim() != ""));
                foreach (var file in Directory.GetFiles(textBox_ypf_pack_input.Text, "*", SearchOption.AllDirectories).OrderBy(f => f))
                {
                    if (non_packing.Contains(Path.GetExtension(file).ToLower()))
                    {
                        continue;
                    }
                    ypf.Entries.Add(new YPFEntry(file.Replace(baseName, ""), File.ReadAllBytes(file))
                    {
                        Compressed = !non_compress.Contains(Path.GetExtension(file).ToLower())
                    });
                }
                Log("[YPF Pack] Created " + ypf.Entries.Count + " entries.");
                var target = textBox_ypf_pack_output.Text;
                if (Directory.Exists(target))
                {
                    target = Path.Combine(target, Path.GetFileName(textBox_ypf_pack_input.Text) + ".ypf");
                }
                using (var writer = new BinaryWriter(File.Open(target, FileMode.Create)))
                {
                    Func<byte[], uint> hashName = CheckSum.MurmurHash2, hashData = CheckSum.MurmurHash2;
                    if (radioButton_ypf_crc32.Checked)
                    {
                        hashName = CheckSum.CRC32;
                        hashData = CheckSum.Adler32;
                    }
                    ypf.Write(writer, int.Parse(textBox_ypf_engine.Text), hashName, hashData);
                    Log("[YPF Pack] Write success, size: " + writer.BaseStream.Position + ", target: " + target);
                }
            }
            catch (Exception ex) { Oops(ex); }
        }

        private void button_ystb_magic_Click(object sender, EventArgs e)
        {
            textBox_ystb_cipher_key.Text = CheckSum.Magic32(textBox_ystb_magic.Text).ToString("X8");
        }

        private void button_ystb_cipher_Click(object sender, EventArgs e)
        {
            try
            {
                var key = int.Parse(textBox_ystb_cipher_key.Text, NumberStyles.HexNumber);
                var files = new List<string>();
                var baseName = Path.GetFullPath(textBox_ystb_cipher_input.Text);
                int counter = 0;
                if (Directory.Exists(textBox_ystb_cipher_input.Text))
                {
                    files.AddRange(Directory.GetFiles(textBox_ystb_cipher_input.Text, "*.ybn", SearchOption.AllDirectories));
                }
                else
                {
                    files.Add(textBox_ystb_cipher_input.Text);
                    baseName = Path.GetDirectoryName(baseName);
                }
                baseName = baseName.TrimEnd('\\') + "\\";
                foreach (var file in files)
                {
                    var name = file.Replace(baseName , "");
                    using (var reader = new BinaryReader(File.OpenRead(file)))
                    {
                        var data = YSTB.Cipher(reader, key);
                        if (data != null)
                        {
                            reader.Close();
                            Log("[YSTB Cipher] Processed: " + name);
                            var path = Path.Combine(textBox_ystb_cipher_output.Text, name);
                            Directory.CreateDirectory(Path.GetDirectoryName(path));
                            File.WriteAllBytes(path, data);
                            counter++;
                        }
                    }
                }
                Log("[YSTB Cipher] Complete: " + counter + "/" + files.Count + " files.");
            }
            catch (Exception ex) { Oops(ex); }
        }
    }
}
