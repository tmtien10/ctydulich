using System;

namespace QuanLyDieuHanhDuLich
{
    partial class NhanVien
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
            this.dataGridViewNV = new System.Windows.Forms.DataGridView();
            this.bttTimNV = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCongViec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiaChiNV = new System.Windows.Forms.TextBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bttThemNV = new System.Windows.Forms.Button();
            this.bttSuaNV = new System.Windows.Forms.Button();
            this.bttXoaNV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách nhân viên";
            // 
            // dataGridViewNV
            // 
            this.dataGridViewNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNV.Location = new System.Drawing.Point(14, 65);
            this.dataGridViewNV.Name = "dataGridViewNV";
            this.dataGridViewNV.Size = new System.Drawing.Size(372, 341);
            this.dataGridViewNV.TabIndex = 1;
            this.dataGridViewNV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // bttTimNV
            // 
            this.bttTimNV.BackColor = System.Drawing.Color.White;
            this.bttTimNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttTimNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bttTimNV.Location = new System.Drawing.Point(440, 405);
            this.bttTimNV.Name = "bttTimNV";
            this.bttTimNV.Size = new System.Drawing.Size(84, 37);
            this.bttTimNV.TabIndex = 3;
            this.bttTimNV.Text = "Tìm kiếm";
            this.bttTimNV.UseVisualStyleBackColor = false;
            this.bttTimNV.Click += new System.EventHandler(this.bttTimNV_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Controls.Add(this.txtCongViec);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDiaChiNV);
            this.groupBox1.Controls.Add(this.txtChucVu);
            this.groupBox1.Controls.Add(this.txtCMND);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenNV);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(440, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 313);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết nhân viên";
            // 
            // txtCongViec
            // 
            this.txtCongViec.Location = new System.Drawing.Point(137, 256);
            this.txtCongViec.Name = "txtCongViec";
            this.txtCongViec.Size = new System.Drawing.Size(236, 26);
            this.txtCongViec.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Công việc";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Địa chỉ:";
            // 
            // txtDiaChiNV
            // 
            this.txtDiaChiNV.Location = new System.Drawing.Point(137, 157);
            this.txtDiaChiNV.Name = "txtDiaChiNV";
            this.txtDiaChiNV.Size = new System.Drawing.Size(236, 26);
            this.txtDiaChiNV.TabIndex = 8;
            this.txtDiaChiNV.TextChanged += new System.EventHandler(this.txtDiaChiNV_TextChanged);
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(137, 210);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(236, 26);
            this.txtChucVu.TabIndex = 7;
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(205, 115);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(139, 26);
            this.txtCMND.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Chứng minh nhân dân:";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(141, 76);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(233, 26);
            this.txtTenNV.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Chức vụ:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(138, 36);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(236, 26);
            this.txtMaNV.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã nhân viên:";
            // 
            // bttThemNV
            // 
            this.bttThemNV.BackColor = System.Drawing.Color.White;
            this.bttThemNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttThemNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bttThemNV.Location = new System.Drawing.Point(537, 405);
            this.bttThemNV.Name = "bttThemNV";
            this.bttThemNV.Size = new System.Drawing.Size(91, 37);
            this.bttThemNV.TabIndex = 5;
            this.bttThemNV.Text = "Thêm";
            this.bttThemNV.UseVisualStyleBackColor = false;
            this.bttThemNV.Click += new System.EventHandler(this.bttThemNV_Click);
            // 
            // bttSuaNV
            // 
            this.bttSuaNV.BackColor = System.Drawing.Color.White;
            this.bttSuaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttSuaNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bttSuaNV.Location = new System.Drawing.Point(645, 405);
            this.bttSuaNV.Name = "bttSuaNV";
            this.bttSuaNV.Size = new System.Drawing.Size(91, 37);
            this.bttSuaNV.TabIndex = 6;
            this.bttSuaNV.Text = "Sửa";
            this.bttSuaNV.UseVisualStyleBackColor = false;
            this.bttSuaNV.Click += new System.EventHandler(this.bttSuaNV_Click);
            // 
            // bttXoaNV
            // 
            this.bttXoaNV.BackColor = System.Drawing.Color.White;
            this.bttXoaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttXoaNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bttXoaNV.Location = new System.Drawing.Point(752, 405);
            this.bttXoaNV.Name = "bttXoaNV";
            this.bttXoaNV.Size = new System.Drawing.Size(91, 37);
            this.bttXoaNV.TabIndex = 7;
            this.bttXoaNV.Text = "Xóa";
            this.bttXoaNV.UseVisualStyleBackColor = false;
            this.bttXoaNV.Click += new System.EventHandler(this.bttXoaNV_Click);
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(855, 463);
            this.Controls.Add(this.bttXoaNV);
            this.Controls.Add(this.bttSuaNV);
            this.Controls.Add(this.bttThemNV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bttTimNV);
            this.Controls.Add(this.dataGridViewNV);
            this.Controls.Add(this.label1);
            this.Name = "NhanVien";
            this.Text = "NhanVien";
            this.Load += new System.EventHandler(this.NhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewNV;
        private System.Windows.Forms.Button bttTimNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiaChiNV;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Button bttThemNV;
        private System.Windows.Forms.Button bttSuaNV;
        private System.Windows.Forms.Button bttXoaNV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCongViec;

        public EventHandler txtDiaChiNV_TextChanged { get; private set; }
    }
}