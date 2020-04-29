namespace YuRISTools
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox_ypf_verify = new System.Windows.Forms.CheckBox();
            this.radioButton_ypf_murmur2 = new System.Windows.Forms.RadioButton();
            this.radioButton_ypf_crc32 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_ypf_pack_no_packing = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ypf_pack_no_compress = new System.Windows.Forms.TextBox();
            this.button_ypf_pack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ypf_pack_output = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_ypf_pack_input = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_ypf_unpack = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ypf_unpack_output = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_ypf_unpack_input = new System.Windows.Forms.TextBox();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox_ypf_engine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_ystb_cipher = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_ystb_cipher_output = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_ystb_cipher_input = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_ystb_cipher_key = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_ystb_magic = new System.Windows.Forms.TextBox();
            this.button_ystb_magic = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 246);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(618, 220);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "YPF Tool";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox_ypf_verify);
            this.groupBox5.Controls.Add(this.radioButton_ypf_murmur2);
            this.groupBox5.Controls.Add(this.radioButton_ypf_crc32);
            this.groupBox5.Location = new System.Drawing.Point(504, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(108, 98);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Checksum";
            // 
            // checkBox_ypf_verify
            // 
            this.checkBox_ypf_verify.AutoSize = true;
            this.checkBox_ypf_verify.Location = new System.Drawing.Point(6, 76);
            this.checkBox_ypf_verify.Name = "checkBox_ypf_verify";
            this.checkBox_ypf_verify.Size = new System.Drawing.Size(60, 16);
            this.checkBox_ypf_verify.TabIndex = 16;
            this.checkBox_ypf_verify.Text = "Verify";
            this.checkBox_ypf_verify.UseVisualStyleBackColor = true;
            // 
            // radioButton_ypf_murmur2
            // 
            this.radioButton_ypf_murmur2.AutoSize = true;
            this.radioButton_ypf_murmur2.Checked = true;
            this.radioButton_ypf_murmur2.Location = new System.Drawing.Point(6, 20);
            this.radioButton_ypf_murmur2.Name = "radioButton_ypf_murmur2";
            this.radioButton_ypf_murmur2.Size = new System.Drawing.Size(65, 16);
            this.radioButton_ypf_murmur2.TabIndex = 1;
            this.radioButton_ypf_murmur2.TabStop = true;
            this.radioButton_ypf_murmur2.Text = "Murmur2";
            this.radioButton_ypf_murmur2.UseVisualStyleBackColor = true;
            // 
            // radioButton_ypf_crc32
            // 
            this.radioButton_ypf_crc32.AutoSize = true;
            this.radioButton_ypf_crc32.Location = new System.Drawing.Point(6, 42);
            this.radioButton_ypf_crc32.Name = "radioButton_ypf_crc32";
            this.radioButton_ypf_crc32.Size = new System.Drawing.Size(95, 28);
            this.radioButton_ypf_crc32.TabIndex = 15;
            this.radioButton_ypf_crc32.Text = "Name CRC32\r\nData Adler32";
            this.radioButton_ypf_crc32.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_ypf_pack_no_packing);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox_ypf_pack_no_compress);
            this.groupBox2.Controls.Add(this.button_ypf_pack);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_ypf_pack_output);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_ypf_pack_input);
            this.groupBox2.Location = new System.Drawing.Point(6, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(492, 128);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pack";
            // 
            // textBox_ypf_pack_no_packing
            // 
            this.textBox_ypf_pack_no_packing.AllowDrop = true;
            this.textBox_ypf_pack_no_packing.Location = new System.Drawing.Point(161, 101);
            this.textBox_ypf_pack_no_packing.Name = "textBox_ypf_pack_no_packing";
            this.textBox_ypf_pack_no_packing.Size = new System.Drawing.Size(325, 21);
            this.textBox_ypf_pack_no_packing.TabIndex = 14;
            this.textBox_ypf_pack_no_packing.Text = "exe/dll/mpg/avi/swf/yst/txt/bat/sd/db/vix/bak";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "Non-Packing Extensions:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "Non-Compress Extensions:";
            // 
            // textBox_ypf_pack_no_compress
            // 
            this.textBox_ypf_pack_no_compress.AllowDrop = true;
            this.textBox_ypf_pack_no_compress.Location = new System.Drawing.Point(161, 74);
            this.textBox_ypf_pack_no_compress.Name = "textBox_ypf_pack_no_compress";
            this.textBox_ypf_pack_no_compress.Size = new System.Drawing.Size(325, 21);
            this.textBox_ypf_pack_no_compress.TabIndex = 11;
            this.textBox_ypf_pack_no_compress.Text = "png/gif/wav/ogg/psb";
            // 
            // button_ypf_pack
            // 
            this.button_ypf_pack.Location = new System.Drawing.Point(411, 20);
            this.button_ypf_pack.Name = "button_ypf_pack";
            this.button_ypf_pack.Size = new System.Drawing.Size(75, 21);
            this.button_ypf_pack.TabIndex = 9;
            this.button_ypf_pack.Text = "Pack";
            this.button_ypf_pack.UseVisualStyleBackColor = true;
            this.button_ypf_pack.Click += new System.EventHandler(this.button_ypf_pack_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Output:";
            // 
            // textBox_ypf_pack_output
            // 
            this.textBox_ypf_pack_output.AllowDrop = true;
            this.textBox_ypf_pack_output.Location = new System.Drawing.Point(59, 47);
            this.textBox_ypf_pack_output.Name = "textBox_ypf_pack_output";
            this.textBox_ypf_pack_output.Size = new System.Drawing.Size(427, 21);
            this.textBox_ypf_pack_output.TabIndex = 7;
            this.textBox_ypf_pack_output.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBox_ypf_pack_output.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox_DragOver);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Input:";
            // 
            // textBox_ypf_pack_input
            // 
            this.textBox_ypf_pack_input.AllowDrop = true;
            this.textBox_ypf_pack_input.Location = new System.Drawing.Point(59, 20);
            this.textBox_ypf_pack_input.Name = "textBox_ypf_pack_input";
            this.textBox_ypf_pack_input.Size = new System.Drawing.Size(346, 21);
            this.textBox_ypf_pack_input.TabIndex = 5;
            this.textBox_ypf_pack_input.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBox_ypf_pack_input.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox_DragOver);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_ypf_unpack);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_ypf_unpack_output);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_ypf_unpack_input);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unpack";
            // 
            // button_ypf_unpack
            // 
            this.button_ypf_unpack.Location = new System.Drawing.Point(411, 20);
            this.button_ypf_unpack.Name = "button_ypf_unpack";
            this.button_ypf_unpack.Size = new System.Drawing.Size(75, 21);
            this.button_ypf_unpack.TabIndex = 14;
            this.button_ypf_unpack.Text = "Unpack";
            this.button_ypf_unpack.UseVisualStyleBackColor = true;
            this.button_ypf_unpack.Click += new System.EventHandler(this.button_ypf_unpack_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Output:";
            // 
            // textBox_ypf_unpack_output
            // 
            this.textBox_ypf_unpack_output.AllowDrop = true;
            this.textBox_ypf_unpack_output.Location = new System.Drawing.Point(59, 47);
            this.textBox_ypf_unpack_output.Name = "textBox_ypf_unpack_output";
            this.textBox_ypf_unpack_output.Size = new System.Drawing.Size(427, 21);
            this.textBox_ypf_unpack_output.TabIndex = 12;
            this.textBox_ypf_unpack_output.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBox_ypf_unpack_output.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox_DragOver);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "Input:";
            // 
            // textBox_ypf_unpack_input
            // 
            this.textBox_ypf_unpack_input.AllowDrop = true;
            this.textBox_ypf_unpack_input.Location = new System.Drawing.Point(59, 20);
            this.textBox_ypf_unpack_input.Name = "textBox_ypf_unpack_input";
            this.textBox_ypf_unpack_input.Size = new System.Drawing.Size(346, 21);
            this.textBox_ypf_unpack_input.TabIndex = 10;
            this.textBox_ypf_unpack_input.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBox_ypf_unpack_input.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox_DragOver);
            // 
            // textBox_log
            // 
            this.textBox_log.BackColor = System.Drawing.Color.Black;
            this.textBox_log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_log.Font = new System.Drawing.Font("Consolas", 10F);
            this.textBox_log.ForeColor = System.Drawing.Color.Silver;
            this.textBox_log.Location = new System.Drawing.Point(0, 244);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(626, 194);
            this.textBox_log.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.textBox_ypf_engine);
            this.groupBox6.Location = new System.Drawing.Point(504, 110);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(108, 47);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Packing";
            // 
            // textBox_ypf_engine
            // 
            this.textBox_ypf_engine.Location = new System.Drawing.Point(59, 20);
            this.textBox_ypf_engine.Name = "textBox_ypf_engine";
            this.textBox_ypf_engine.Size = new System.Drawing.Size(43, 21);
            this.textBox_ypf_engine.TabIndex = 0;
            this.textBox_ypf_engine.Text = "490";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Engine:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(618, 220);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "YSTB Tool";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_ystb_cipher_key);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.button_ystb_cipher);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBox_ystb_cipher_output);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox_ystb_cipher_input);
            this.groupBox3.Location = new System.Drawing.Point(6, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(492, 74);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "YSTB Cipher";
            // 
            // button_ystb_cipher
            // 
            this.button_ystb_cipher.Location = new System.Drawing.Point(392, 47);
            this.button_ystb_cipher.Name = "button_ystb_cipher";
            this.button_ystb_cipher.Size = new System.Drawing.Size(94, 21);
            this.button_ystb_cipher.TabIndex = 14;
            this.button_ystb_cipher.Text = "XOR";
            this.button_ystb_cipher.UseVisualStyleBackColor = true;
            this.button_ystb_cipher.Click += new System.EventHandler(this.button_ystb_cipher_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "Output:";
            // 
            // textBox_ystb_cipher_output
            // 
            this.textBox_ystb_cipher_output.AllowDrop = true;
            this.textBox_ystb_cipher_output.Location = new System.Drawing.Point(59, 47);
            this.textBox_ystb_cipher_output.Name = "textBox_ystb_cipher_output";
            this.textBox_ystb_cipher_output.Size = new System.Drawing.Size(327, 21);
            this.textBox_ystb_cipher_output.TabIndex = 12;
            this.textBox_ystb_cipher_output.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBox_ystb_cipher_output.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox_DragOver);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "Input:";
            // 
            // textBox_ystb_cipher_input
            // 
            this.textBox_ystb_cipher_input.AllowDrop = true;
            this.textBox_ystb_cipher_input.Location = new System.Drawing.Point(59, 20);
            this.textBox_ystb_cipher_input.Name = "textBox_ystb_cipher_input";
            this.textBox_ystb_cipher_input.Size = new System.Drawing.Size(327, 21);
            this.textBox_ystb_cipher_input.TabIndex = 10;
            this.textBox_ystb_cipher_input.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBox_ystb_cipher_input.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox_DragOver);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(392, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "Key:";
            // 
            // textBox_ystb_cipher_key
            // 
            this.textBox_ystb_cipher_key.AllowDrop = true;
            this.textBox_ystb_cipher_key.Location = new System.Drawing.Point(427, 20);
            this.textBox_ystb_cipher_key.Name = "textBox_ystb_cipher_key";
            this.textBox_ystb_cipher_key.Size = new System.Drawing.Size(59, 21);
            this.textBox_ystb_cipher_key.TabIndex = 16;
            this.textBox_ystb_cipher_key.Text = "76033B26";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_ystb_magic);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.textBox_ystb_magic);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(492, 47);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Magic32 Compute";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "Input:";
            // 
            // textBox_ystb_magic
            // 
            this.textBox_ystb_magic.AllowDrop = true;
            this.textBox_ystb_magic.Location = new System.Drawing.Point(53, 20);
            this.textBox_ystb_magic.Name = "textBox_ystb_magic";
            this.textBox_ystb_magic.Size = new System.Drawing.Size(333, 21);
            this.textBox_ystb_magic.TabIndex = 12;
            // 
            // button_ystb_magic
            // 
            this.button_ystb_magic.Location = new System.Drawing.Point(392, 20);
            this.button_ystb_magic.Name = "button_ystb_magic";
            this.button_ystb_magic.Size = new System.Drawing.Size(94, 21);
            this.button_ystb_magic.TabIndex = 17;
            this.button_ystb_magic.Text = "Magic && Fill";
            this.button_ystb_magic.UseVisualStyleBackColor = true;
            this.button_ystb_magic.Click += new System.EventHandler(this.button_ystb_magic_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 438);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "YuRIS Tools";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_ypf_pack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ypf_pack_output;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_ypf_pack_input;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_ypf_unpack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ypf_unpack_output;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_ypf_unpack_input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ypf_pack_no_compress;
        private System.Windows.Forms.TextBox textBox_ypf_pack_no_packing;
        private System.Windows.Forms.RadioButton radioButton_ypf_crc32;
        private System.Windows.Forms.RadioButton radioButton_ypf_murmur2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox_ypf_verify;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ypf_engine;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_ystb_cipher;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_ystb_cipher_output;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_ystb_cipher_input;
        private System.Windows.Forms.TextBox textBox_ystb_cipher_key;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_ystb_magic;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_ystb_magic;
    }
}

