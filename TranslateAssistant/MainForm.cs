using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using fastJSON;

namespace TranslateAssistant
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        public static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetMessageExtraInfo();

        public int nextId = -1, currentId = -1;
        public string nextFile = null, currentFile = null;

        public Dictionary<string, List<string>> original = null, output = null;

        [Flags]
        public enum InputType
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2
        }

        [Flags]
        public enum MOUSEEVENTF
        {
            MOVE = 0x0001, /* mouse move */
            LEFTDOWN = 0x0002, /* left button down */
            LEFTUP = 0x0004, /* left button up */
            RIGHTDOWN = 0x0008, /* right button down */
            RIGHTUP = 0x0010, /* right button up */
            MIDDLEDOWN = 0x0020, /* middle button down */
            MIDDLEUP = 0x0040, /* middle button up */
            XDOWN = 0x0080, /* x button down */
            XUP = 0x0100, /* x button down */
            WHEEL = 0x0800, /* wheel button rolled */
            MOVE_NOCOALESCE = 0x2000, /* do not coalesce mouse moves */
            VIRTUALDESK = 0x4000, /* map to entire virtual desktop */
            ABSOLUTE = 0x8000 /* absolute move */
        }

        [Flags]
        public enum KEYEVENTF
        {
            KEYDOWN = 0,
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            UNICODE = 0x0004,
            SCANCODE = 0x0008,
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public int type;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        public IntPtr GameWindow = IntPtr.Zero;

        public MainForm()
        {
            InitializeComponent();
        }

        public IntPtr FindGame()
        {
            IntPtr hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle == textBox_window.Text)
                {
                    return pList.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }

        public void SelectText(string file, int id, bool update = true)
        {
            currentId = id;
            currentFile = file;
            textBox_old.Text = original[file][id];
            textBox_current.Text = output[file][id];
            if (update)
            {
                listView_main.SelectedItems.Clear();
                var item = listView_main.Groups[file].Items[id.ToString()];
                item.Selected = true;
                item.EnsureVisible();
            }
            if (id < output[file].Count)
            {
                nextId = id + 1;
                nextFile = file;
            }
            else
            {
                for (var i = 0; i < output.Keys.Count; i++)
                {
                    if (output.Keys.ElementAt(i) == file && output.Keys.Count > i + 1)
                    {
                        nextId = 0;
                        nextFile = output.Keys.ElementAt(i + 1);
                        return;
                    }
                }
                nextId = -1;
                nextFile = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GameWindow = FindGame();
            label1.Text = GameWindow.ToString("X");
            if (GameWindow != IntPtr.Zero)
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => timer1.Enabled = checkBox1.Checked;

        private void listView_main_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) => SelectText(e.Item.Group.Name, int.Parse(e.Item.Text), false);

        private void button_config_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;
            Height = groupBox1.Visible ? 398 : 315;
            listView_main.Height = groupBox1.Visible ? 335 : 252;
            button_config.Top = groupBox1.Visible ? 243 : 246;
        }

        private void textBox_current_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (GameWindow == IntPtr.Zero || original == null)
                {
                    return;
                }
                SetForegroundWindow(GameWindow);

                INPUT keyDown = new INPUT();
                keyDown.type = (int)InputType.INPUT_KEYBOARD;
                keyDown.ki.wVk = 0x20;
                keyDown.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
                keyDown.ki.dwExtraInfo = GetMessageExtraInfo();

                INPUT keyUp = new INPUT();
                keyUp.type = (int)InputType.INPUT_KEYBOARD;
                keyUp.ki.wVk = 0x20;
                keyUp.mi.dwFlags = (int)KEYEVENTF.KEYUP;
                keyUp.ki.dwExtraInfo = GetMessageExtraInfo();

                SendInput(2, new INPUT[] { keyDown, keyUp }, Marshal.SizeOf(keyDown));

                Thread.Sleep(100);
                SetForegroundWindow(Handle);

                listView_main.Groups[currentFile].Items[currentId].SubItems[2].Text = output[currentFile][currentId] = textBox_current.Text.Replace("\n", "").Replace("\r", "").Trim();

                if (nextId >= 0)
                {
                    SelectText(nextFile, nextId);
                }
            }
        }

        private void button_init_Click(object sender, EventArgs e)
        {
            try
            {
                if (output != null && MessageBox.Show("You will lose all unsaved work.", "Continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }
                original = JSON.ToObject<Dictionary<string, List<string>>>(File.ReadAllText(textBox_original.Text));
                output = JSON.ToObject<Dictionary<string, List<string>>>(File.ReadAllText(textBox_output.Text));
                listView_main.BeginUpdate();
                listView_main.Items.Clear();
                foreach (var kv in output)
                {
                    var group = listView_main.Groups.Add(kv.Key, kv.Key);
                    for (int i = 0; i < kv.Value.Count; i++)
                    {
                        var item = group.Items.Add(i.ToString(), i.ToString(), -1);
                        item.SubItems.Add(original[kv.Key][i]);
                        item.SubItems.Add(kv.Value[i]);
                        listView_main.Items.Add(item);
                    }
                }
                listView_main.EndUpdate();
                SelectText(output.First().Key, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(textBox_output.Text + ".out", JSON.ToNiceJSON(output, new JSONParameters()
                {
                    UseEscapedUnicode = false
                }));
                File.Delete(textBox_output.Text);
                File.Move(textBox_output.Text + ".out", textBox_output.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
