namespace QuanLyDieuHanhDuLich
{
    partial class Danh_mục_phiếu_đăng_kí
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaKH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaTour = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.dataGridViewDK = new System.Windows.Forms.DataGridView();
            this.bttTK = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDK)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(245, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách phiếu đăng kí";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số thứ tự phiếu";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(170, 79);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(201, 24);
            this.txtSoPhieu.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(411, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã khách hàng";
            // 
            // MaKH
            // 
            this.MaKH.Location = new System.Drawing.Point(550, 85);
            this.MaKH.Name = "MaKH";
            this.MaKH.Size = new System.Drawing.Size(201, 24);
            this.MaKH.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(59, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mã Tour:";
            // 
            // txtMaTour
            // 
            this.txtMaTour.Location = new System.Drawing.Point(170, 125);
            this.txtMaTour.Name = "txtMaTour";
            this.txtMaTour.Size = new System.Drawing.Size(201, 24);
            this.txtMaTour.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(457, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Thời gian";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(550, 131);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(36, 24);
            this.txtDay.TabIndex = 8;
            // 
            // dataGridViewDK
            // 
            this.dataGridViewDK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDK.Location = new System.Drawing.Point(17, 214);
            this.dataGridViewDK.Name = "dataGridViewDK";
            this.dataGridViewDK.Size = new System.Drawing.Size(761, 243);
            this.dataGridViewDK.TabIndex = 9;
            this.dataGridViewDK.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDK_CellContentClick);
            // 
            // bttTK
            // 
            this.bttTK.BackColor = System.Drawing.Color.White;
            this.bttTK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bttTK.Location = new System.Drawing.Point(550, 170);
            this.bttTK.Name = "bttTK";
            this.bttTK.Size = new System.Drawing.Size(82, 38);
            this.bttTK.TabIndex = 10;
            this.bttTK.Text = "Tìm";
            this.bttTK.UseVisualStyleBackColor = false;
            this.bttTK.Click += new System.EventHandler(this.bttTK_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(23, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nháy đúp 1 dòng để xem chi tiết";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(669, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 38);
            this.button2.TabIndex = 12;
            this.button2.Text = "Thêm";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(596, 131);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(57, 24);
            this.txtMonth.TabIndex = 13;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(659, 131);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(92, 24);
            this.txtYear.TabIndex = 14;
            // 
            // Danh_mục_phiếu_đăng_kí
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(800, 469);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bttTK);
            this.Controls.Add(this.dataGridViewDK);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaTour);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MaKH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoPhieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Danh_mục_phiếu_đăng_kí";
            this.Text = "Phiếu đăng kí";
            this.Load += new System.EventHandler(this.Danh_mục_phiếu_đăng_kí_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MaKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaTour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Button bttTK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView dataGridViewDK;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtYear;
    }
}