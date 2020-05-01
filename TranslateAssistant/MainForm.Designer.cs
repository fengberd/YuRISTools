namespace TranslateAssistant
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_current = new System.Windows.Forms.TextBox();
            this.listView_main = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_old = new System.Windows.Forms.TextBox();
            this.button_config = new System.Windows.Forms.Button();
            this.textBox_original = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_init = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_window = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_old);
            this.groupBox2.Controls.Add(this.textBox_current);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 228);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Text";
            // 
            // textBox_current
            // 
            this.textBox_current.Font = new System.Drawing.Font("宋体", 14F);
            this.textBox_current.Location = new System.Drawing.Point(6, 124);
            this.textBox_current.Multiline = true;
            this.textBox_current.Name = "textBox_current";
            this.textBox_current.Size = new System.Drawing.Size(526, 98);
            this.textBox_current.TabIndex = 1;
            this.textBox_current.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_current_KeyPress);
            // 
            // listView_main
            // 
            this.listView_main.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_main.FullRowSelect = true;
            this.listView_main.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_main.HideSelection = false;
            this.listView_main.Location = new System.Drawing.Point(556, 12);
            this.listView_main.Name = "listView_main";
            this.listView_main.Size = new System.Drawing.Size(321, 335);
            this.listView_main.TabIndex = 5;
            this.listView_main.UseCompatibleStateImageBehavior = false;
            this.listView_main.View = System.Windows.Forms.View.Details;
            this.listView_main.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_main_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Original";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "New";
            this.columnHeader3.Width = 170;
            // 
            // textBox_old
            // 
            this.textBox_old.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_old.Font = new System.Drawing.Font("宋体", 14F);
            this.textBox_old.Location = new System.Drawing.Point(8, 20);
            this.textBox_old.Multiline = true;
            this.textBox_old.Name = "textBox_old";
            this.textBox_old.ReadOnly = true;
            this.textBox_old.Size = new System.Drawing.Size(524, 98);
            this.textBox_old.TabIndex = 2;
            // 
            // button_config
            // 
            this.button_config.Location = new System.Drawing.Point(18, 243);
            this.button_config.Name = "button_config";
            this.button_config.Size = new System.Drawing.Size(69, 21);
            this.button_config.TabIndex = 8;
            this.button_config.Text = "Config";
            this.button_config.UseVisualStyleBackColor = true;
            this.button_config.Click += new System.EventHandler(this.button_config_Click);
            // 
            // textBox_original
            // 
            this.textBox_original.Location = new System.Drawing.Point(71, 20);
            this.textBox_original.Name = "textBox_original";
            this.textBox_original.Size = new System.Drawing.Size(380, 21);
            this.textBox_original.TabIndex = 2;
            this.textBox_original.Text = "D:\\Workspace\\MaggotBaits\\unpack\\bn\\ysbin_decrypted\\all.json";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Original:";
            // 
            // textBox_output
            // 
            this.textBox_output.Location = new System.Drawing.Point(71, 47);
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.Size = new System.Drawing.Size(380, 21);
            this.textBox_output.TabIndex = 4;
            this.textBox_output.Text = "D:\\Workspace\\MaggotBaits\\unpack\\bn\\ysbin_decrypted\\out.json";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(8, 76);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Search Game Window:";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "New:";
            // 
            // button_init
            // 
            this.button_init.Location = new System.Drawing.Point(457, 20);
            this.button_init.Name = "button_init";
            this.button_init.Size = new System.Drawing.Size(75, 21);
            this.button_init.TabIndex = 6;
            this.button_init.Text = "Init";
            this.button_init.UseVisualStyleBackColor = true;
            this.button_init.Click += new System.EventHandler(this.button_init_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(457, 47);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 21);
            this.button_save.TabIndex = 7;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_window);
            this.groupBox1.Controls.Add(this.button_save);
            this.groupBox1.Controls.Add(this.button_init);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_output);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_original);
            this.groupBox1.Location = new System.Drawing.Point(12, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 101);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // textBox_window
            // 
            this.textBox_window.Location = new System.Drawing.Point(152, 73);
            this.textBox_window.Name = "textBox_window";
            this.textBox_window.Size = new System.Drawing.Size(102, 21);
            this.textBox_window.TabIndex = 8;
            this.textBox_window.Text = "Maggot baits";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 359);
            this.Controls.Add(this.button_config);
            this.Controls.Add(this.listView_main);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Translate Assistant";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView_main;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox textBox_current;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox textBox_old;
        private System.Windows.Forms.Button button_config;
        private System.Windows.Forms.TextBox textBox_original;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_init;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_window;
    }
}

