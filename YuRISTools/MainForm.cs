using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using YuRIS.Package;
using System.Threading;

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
            if(InvokeRequired)
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
                files.AddRange(Directory.GetFiles(textBox_ypf_unpack_input.Text)
                    .Where(f => f.EndsWith(".ypf", StringComparison.CurrentCultureIgnoreCase)));
            }
            else
            {
                files.Add(textBox_ypf_unpack_input.Text);
            }
            groupBox1.Enabled = false;
            var output = textBox_ypf_unpack_output.Text;
            ThreadPool.QueueUserWorkItem(s =>
            {
                try
                {
                    foreach (var file in files)
                    {
                        Log("[YPF Unpack] Unpacking " + Path.GetFileName(file) + " ...");
                        using (var reader = new BinaryReader(File.OpenRead(file)))
                        {
                            var ypf = YPF.ReadFile(reader);
                            Log("[YPF Unpack] Found " + ypf.Entries.Count + " entries.");
                            foreach (var entry in ypf.Entries)
                            {
                                Log("[YPF Unpack] Unpacking " + entry.Name + "(" + entry.Size + ") ...");
                                var path = Path.Combine(output, Path.GetFileNameWithoutExtension(file), entry.Name);
                                Directory.CreateDirectory(Path.GetDirectoryName(path));
                                File.WriteAllBytes(path, entry.Data);
                            }
                        }
                    }
                    Log("[YPF Unpack] Complete, unpacked " + files.Count + " files.");
                }
                catch (Exception ex) { Oops(ex); }
                Invoke(new Action(() => groupBox1.Enabled = true));
            });
        }

        private void button_ypf_pack_Click(object sender, EventArgs e)
        {
            try
            {
                var ypf = new YPF();
                foreach (var file in Directory.GetFiles(textBox_ypf_pack_input.Text,"*",SearchOption.AllDirectories).OrderBy(f => f))
                {
                    if (checkBox_ypf_pack_ignore_bak.Checked && file.EndsWith(".bak"))
                    {
                        continue;
                    }
                    ypf.Entries.Add(new YPFEntry(file.Replace(Path.GetFullPath(textBox_ypf_pack_input.Text) + "\\", ""), File.ReadAllBytes(file)));
                }
                Log("[YPF Pack] Created " + ypf.Entries.Count + " entries.");
                var target = textBox_ypf_pack_output.Text;
                if (Directory.Exists(target))
                {
                    target = Path.Combine(target, Path.GetFileName(textBox_ypf_pack_input.Text) + ".ypf");
                }
                using (var writer = new BinaryWriter(File.Open(target, FileMode.Create)))
                {
                    ypf.Write(writer);
                    Log("[YPF Pack] Write success, size: " + writer.BaseStream.Position + ", target: " + target);
                }
            }
            catch (Exception ex) { Oops(ex); }
        }
    }
}
