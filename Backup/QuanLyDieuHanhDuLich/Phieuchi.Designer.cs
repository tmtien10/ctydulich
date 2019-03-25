namespace QuanLyDieuHanhDuLich
{
    partial class Phieuchi
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
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bttTim = new System.Windows.Forms.Button();
            this.dataGridViewDSPC = new System.Windows.Forms.DataGridView();
            this.txtMaTourTK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSPC)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(937, 146);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 40);
            this.button2.TabIndex = 36;
            this.button2.Text = "Thêm";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 184);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Nháy đúp 1 dòng để xem chi tiết";
            // 
            // bttTim
            // 
            this.bttTim.BackColor = System.Drawing.Color.White;
            this.bttTim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bttTim.Location = new System.Drawing.Point(757, 146);
            this.bttTim.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.bttTim.Name = "bttTim";
            this.bttTim.Size = new System.Drawing.Size(105, 40);
            this.bttTim.TabIndex = 34;
            this.bttTim.Text = "Tìm";
            this.bttTim.UseVisualStyleBackColor = false;
            this.bttTim.Click += new System.EventHandler(this.bttTim_Click);
            // 
            // dataGridViewDSPC
            // 
            this.dataGridViewDSPC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDSPC.Location = new System.Drawing.Point(21, 215);
            this.dataGridViewDSPC.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewDSPC.Name = "dataGridViewDSPC";
            this.dataGridViewDSPC.Size = new System.Drawing.Size(1098, 336);
            this.dataGridViewDSPC.TabIndex = 33;
            this.dataGridViewDSPC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDSPC_CellContentClick);
            // 
            // txtMaTourTK
            // 
            this.txtMaTourTK.Location = new System.Drawing.Point(277, 140);
            this.txtMaTourTK.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMaTourTK.Name = "txtMaTourTK";
            this.txtMaTourTK.Size = new System.Drawing.Size(297, 24);
            this.txtMaTourTK.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(163, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "Mã Tour:";
            // 
            // txtKH
            // 
            this.txtKH.Location = new System.Drawing.Point(757, 85);
            this.txtKH.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtKH.Name = "txtKH";
            this.txtKH.Size = new System.Drawing.Size(333, 24);
            this.txtKH.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(621, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "Mã khách hàng";
            // 
            // txtPC
            // 
            this.txtPC.Location = new System.Drawing.Point(277, 91);
            this.txtPC.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPC.Name = "txtPC";
            this.txtPC.Size = new System.Drawing.Size(297, 24);
            this.txtPC.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(144, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Số phiếu chi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(438, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 29);
            this.label1.TabIndex = 26;
            this.label1.Text = "Danh sách phiếu chi";
            // 
            // Phieuchi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1187, 585);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bttTim);
            this.Controls.Add(this.dataGridViewDSPC);
            this.Controls.Add(this.txtMaTourTK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Phieuchi";
            this.Text = "Phieuchi";
            this.Load += new System.EventHandler(this.Phieuchi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSPC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bttTim;
        private System.Windows.Forms.DataGridView dataGridViewDSPC;
        private System.Windows.Forms.TextBox txtMaTourTK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}