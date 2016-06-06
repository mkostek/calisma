namespace iskambilOyun
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        	this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        	this.yeniOyunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.denemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.timer1 = new System.Windows.Forms.Timer(this.components);
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.dataGridView1 = new System.Windows.Forms.DataGridView();
        	this.birinci = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ikinci = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.üçüncü = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dördüncü = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.label6 = new System.Windows.Forms.Label();
        	this.label7 = new System.Windows.Forms.Label();
        	this.button1 = new System.Windows.Forms.Button();
        	this.menuStrip1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// menuStrip1
        	// 
        	this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.yeniOyunToolStripMenuItem});
        	this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        	this.menuStrip1.Name = "menuStrip1";
        	this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
        	this.menuStrip1.TabIndex = 0;
        	this.menuStrip1.Text = "menuStrip1";
        	// 
        	// yeniOyunToolStripMenuItem
        	// 
        	this.yeniOyunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.denemeToolStripMenuItem});
        	this.yeniOyunToolStripMenuItem.Name = "yeniOyunToolStripMenuItem";
        	this.yeniOyunToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
        	this.yeniOyunToolStripMenuItem.Text = "Yeni Oyun";
        	this.yeniOyunToolStripMenuItem.Click += new System.EventHandler(this.yeniOyunToolStripMenuItem_Click);
        	// 
        	// denemeToolStripMenuItem
        	// 
        	this.denemeToolStripMenuItem.Name = "denemeToolStripMenuItem";
        	this.denemeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
        	this.denemeToolStripMenuItem.Text = "deneme";
        	this.denemeToolStripMenuItem.Click += new System.EventHandler(this.denemeToolStripMenuItem_Click);
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
        	this.pictureBox1.Location = new System.Drawing.Point(0, 558);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(2, 2);
        	this.pictureBox1.TabIndex = 1;
        	this.pictureBox1.TabStop = false;
        	this.pictureBox1.Visible = false;
        	// 
        	// timer1
        	// 
        	this.timer1.Enabled = true;
        	this.timer1.Interval = 1000;
        	this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
        	// 
        	// label1
        	// 
        	this.label1.Location = new System.Drawing.Point(658, 558);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(100, 23);
        	this.label1.TabIndex = 2;
        	// 
        	// label2
        	// 
        	this.label2.Location = new System.Drawing.Point(29, 53);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(133, 23);
        	this.label2.TabIndex = 3;
        	this.label2.Text = "label2";
        	// 
        	// dataGridView1
        	// 
        	this.dataGridView1.AllowUserToAddRows = false;
        	this.dataGridView1.AllowUserToDeleteRows = false;
        	this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.birinci,
        	        	        	this.ikinci,
        	        	        	this.üçüncü,
        	        	        	this.dördüncü});
        	this.dataGridView1.Location = new System.Drawing.Point(718, 595);
        	this.dataGridView1.Name = "dataGridView1";
        	this.dataGridView1.ReadOnly = true;
        	this.dataGridView1.Size = new System.Drawing.Size(266, 123);
        	this.dataGridView1.TabIndex = 4;
        	// 
        	// birinci
        	// 
        	this.birinci.HeaderText = "birinci";
        	this.birinci.Name = "birinci";
        	this.birinci.ReadOnly = true;
        	this.birinci.Width = 55;
        	// 
        	// ikinci
        	// 
        	this.ikinci.HeaderText = "ikinci";
        	this.ikinci.Name = "ikinci";
        	this.ikinci.ReadOnly = true;
        	this.ikinci.Width = 55;
        	// 
        	// üçüncü
        	// 
        	this.üçüncü.HeaderText = "üçüncü";
        	this.üçüncü.Name = "üçüncü";
        	this.üçüncü.ReadOnly = true;
        	this.üçüncü.Width = 55;
        	// 
        	// dördüncü
        	// 
        	this.dördüncü.HeaderText = "dördüncü";
        	this.dördüncü.Name = "dördüncü";
        	this.dördüncü.ReadOnly = true;
        	this.dördüncü.Width = 55;
        	// 
        	// label3
        	// 
        	this.label3.Location = new System.Drawing.Point(29, 76);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(102, 23);
        	this.label3.TabIndex = 5;
        	this.label3.Text = "label3";
        	// 
        	// label4
        	// 
        	this.label4.BackColor = System.Drawing.Color.Aqua;
        	this.label4.Location = new System.Drawing.Point(156, 389);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(102, 23);
        	this.label4.TabIndex = 6;
        	this.label4.Text = "0";
        	// 
        	// label5
        	// 
        	this.label5.BackColor = System.Drawing.Color.Yellow;
        	this.label5.Location = new System.Drawing.Point(441, 558);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(102, 23);
        	this.label5.TabIndex = 7;
        	this.label5.Text = "0";
        	// 
        	// label6
        	// 
        	this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        	this.label6.Location = new System.Drawing.Point(718, 389);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(102, 23);
        	this.label6.TabIndex = 8;
        	this.label6.Text = "0";
        	// 
        	// label7
        	// 
        	this.label7.BackColor = System.Drawing.Color.Lime;
        	this.label7.Location = new System.Drawing.Point(441, 176);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(102, 23);
        	this.label7.TabIndex = 9;
        	this.label7.Text = "0";
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(210, 27);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(75, 23);
        	this.button1.TabIndex = 10;
        	this.button1.Text = "skor göster";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.Button1Click);
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(1008, 730);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.label7);
        	this.Controls.Add(this.label6);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.dataGridView1);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.pictureBox1);
        	this.Controls.Add(this.menuStrip1);
        	this.MainMenuStrip = this.menuStrip1;
        	this.Name = "Form1";
        	this.Text = "Form1";
        	this.Load += new System.EventHandler(this.Form1_Load);
        	this.menuStrip1.ResumeLayout(false);
        	this.menuStrip1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dördüncü;
        private System.Windows.Forms.DataGridViewTextBoxColumn üçüncü;
        private System.Windows.Forms.DataGridViewTextBoxColumn ikinci;
        private System.Windows.Forms.DataGridViewTextBoxColumn birinci;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniOyunToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem denemeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

