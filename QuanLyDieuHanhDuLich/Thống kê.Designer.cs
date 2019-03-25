namespace QuanLyDieuHanhDuLich
{
    partial class Thống_kê
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
            this.label1 = new System.Windows.Forms.Label();
            this.Ngày = new System.Windows.Forms.Label();
            this.Tháng = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.bttTK = new System.Windows.Forms.Button();
            this.txtTS = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTK = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.Năm = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTK)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(421, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê";
            // 
            // Ngày
            // 
            this.Ngày.AutoSize = true;
            this.Ngày.ForeColor = System.Drawing.Color.White;
            this.Ngày.Location = new System.Drawing.Point(97, 81);
            this.Ngày.Name = "Ngày";
            this.Ngày.Size = new System.Drawing.Size(46, 16);
            this.Ngày.TabIndex = 1;
            this.Ngày.Text = "Ngày";
            // 
            // Tháng
            // 
            this.Tháng.AutoSize = true;
            this.Tháng.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tháng.ForeColor = System.Drawing.Color.White;
            this.Tháng.Location = new System.Drawing.Point(235, 78);
            this.Tháng.Name = "Tháng";
            this.Tháng.Size = new System.Drawing.Size(54, 18);
            this.Tháng.TabIndex = 2;
            this.Tháng.Text = "Tháng";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(150, 78);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(45, 22);
            this.txtDay.TabIndex = 5;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(305, 78);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(43, 22);
            this.txtMonth.TabIndex = 6;
            // 
            // bttTK
            // 
            this.bttTK.BackColor = System.Drawing.Color.White;
            this.bttTK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bttTK.Location = new System.Drawing.Point(454, 173);
            this.bttTK.Name = "bttTK";
            this.bttTK.Size = new System.Drawing.Size(90, 37);
            this.bttTK.TabIndex = 7;
            this.bttTK.Text = "Thống kê";
            this.bttTK.UseVisualStyleBackColor = false;
            this.bttTK.Click += new System.EventHandler(this.bttTK_Click);
            // 
            // txtTS
            // 
            this.txtTS.Location = new System.Drawing.Point(210, 21);
            this.txtTS.Name = "txtTS";
            this.txtTS.Size = new System.Drawing.Size(183, 22);
            this.txtTS.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Controls.Add(this.dataGridViewTK);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTS);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(49, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(887, 302);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết quả";
            // 
            // dataGridViewTK
            // 
            this.dataGridViewTK.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridViewTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTK.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewTK.Location = new System.Drawing.Point(23, 88);
            this.dataGridViewTK.Name = "dataGridViewTK";
            this.dataGridViewTK.Size = new System.Drawing.Size(849, 198);
            this.dataGridViewTK.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(126, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tổng số";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(440, 78);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(91, 22);
            this.txtYear.TabIndex = 11;
            // 
            // Năm
            // 
            this.Năm.AutoSize = true;
            this.Năm.ForeColor = System.Drawing.Color.White;
            this.Năm.Location = new System.Drawing.Point(385, 78);
            this.Năm.Name = "Năm";
            this.Năm.Size = new System.Drawing.Size(41, 16);
            this.Năm.TabIndex = 12;
            this.Năm.Text = "Năm";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(164, 131);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(108, 22);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tour đăng kí";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(367, 131);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(99, 22);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Tour bị hủy";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Thống_kê
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(959, 547);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Năm);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bttTK);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.Tháng);
            this.Controls.Add(this.Ngày);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Thống_kê";
            this.Text = "Thống_kê";
            this.Load += new System.EventHandler(this.Thống_kê_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Ngày;
        private System.Windows.Forms.Label Tháng;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Button bttTK;
        private System.Windows.Forms.TextBox txtTS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label Năm;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.DataGridView dataGridViewTK;
    }
}