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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_ypf_pack_ignore_bak = new System.Windows.Forms.CheckBox();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(588, 192);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(580, 166);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "YBN Tool";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(6, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(568, 74);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "YBN Patcher";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(568, 74);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "YBN Reader";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(580, 166);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "YPF Tool";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_ypf_pack_ignore_bak);
            this.groupBox2.Controls.Add(this.button_ypf_pack);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_ypf_pack_output);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_ypf_pack_input);
            this.groupBox2.Location = new System.Drawing.Point(6, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 74);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pack";
            // 
            // checkBox_ypf_pack_ignore_bak
            // 
            this.checkBox_ypf_pack_ignore_bak.AutoSize = true;
            this.checkBox_ypf_pack_ignore_bak.Checked = true;
            this.checkBox_ypf_pack_ignore_bak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ypf_pack_ignore_bak.Location = new System.Drawing.Point(472, 22);
            this.checkBox_ypf_pack_ignore_bak.Name = "checkBox_ypf_pack_ignore_bak";
            this.checkBox_ypf_pack_ignore_bak.Size = new System.Drawing.Size(90, 16);
            this.checkBox_ypf_pack_ignore_bak.TabIndex = 10;
            this.checkBox_ypf_pack_ignore_bak.Text = "Ignore .bak";
            this.checkBox_ypf_pack_ignore_bak.UseVisualStyleBackColor = true;
            // 
            // button_ypf_pack
            // 
            this.button_ypf_pack.Location = new System.Drawing.Point(487, 47);
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
            this.textBox_ypf_pack_output.Size = new System.Drawing.Size(422, 21);
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
            this.textBox_ypf_pack_input.Size = new System.Drawing.Size(407, 21);
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
            this.groupBox1.Size = new System.Drawing.Size(568, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unpack";
            // 
            // button_ypf_unpack
            // 
            this.button_ypf_unpack.Location = new System.Drawing.Point(487, 47);
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
            this.textBox_ypf_unpack_output.Size = new System.Drawing.Size(422, 21);
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
            this.textBox_ypf_unpack_input.Size = new System.Drawing.Size(422, 21);
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
            this.textBox_log.Location = new System.Drawing.Point(0, 193);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(588, 245);
            this.textBox_log.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 438);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "YuRIS Tools";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox_ypf_pack_ignore_bak;
    }
}

