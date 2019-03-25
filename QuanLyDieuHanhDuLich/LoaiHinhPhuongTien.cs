using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyDieuHanhDuLich.Class;

namespace QuanLyDieuHanhDuLich
{
    public partial class LoaiHinhPhuongTien : Form
    {
        DataTable tblPT, tblLH;
        public LoaiHinhPhuongTien()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTim.Text=="")
            {  MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from LOAIHINH$ WHERE 1=1";
            if (txtTim.Text != "")
                sql += " AND MaLoai LIKE N'%" + txtTim.Text + "%'";
            tblLH = Functions.GetDataToTable(sql);
            if (tblLH.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblLH.Rows.Count + "  loại hình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = tblLH;
            Reset_Values();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoaiHinhPhuongTien_Load(object sender, EventArgs e)
        {
            LoadDataGridViewLoaiHinh();
            LoadDataGridViewPhuongTien();
        }
        //Dành cho tab loại hình
        private void LoadDataGridViewLoaiHinh()
        {
            string sql;
            sql = "Select * from LOAIHINH$";
            tblLH = Class.Functions.GetDataToTable(sql);
            dataGridView1.DataSource = tblLH;
            dataGridView1.Columns[0].HeaderText = "Mã loại hình";

            dataGridView1.Columns[1].HeaderText = "Tên loại hình";
            dataGridView1.Columns[2].HeaderText = "Số ngày";
            dataGridView1.Columns[3].HeaderText = "Số đêm";

            dataGridView1.AllowUserToAddRows = false; //Không cho thêm dữ liệu trực tiếp
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLoaiHinh.Enabled = false;
            if (tblLH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaLoaiHinh.Text = dataGridView1.CurrentRow.Cells["MaLoai"].Value.ToString();
            txtTenLoaiHinh.Text = dataGridView1.CurrentRow.Cells["TenLoai"].Value.ToString();
            txtSoNgay.Text = dataGridView1.CurrentRow.Cells["SoNgay"].Value.ToString();
            txtSoDem.Text = dataGridView1.CurrentRow.Cells["SoDem"].Value.ToString();
        }
        private void Reset_Values() //xóa dữ liệu trên ô textbox
        {
            txtMaLoaiHinh.Text = "";
            txtTenLoaiHinh.Text = " ";
            txtSoNgay.Text = " ";
            txtSoDem.Text = " ";
        }
        private void bttThem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaLoaiHinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã loại hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoaiHinh.Focus();
                return;
            }
            if (txtTenLoaiHinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên loại hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLoaiHinh.Focus();
                return;
            }
            if (txtSoNgay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoNgay.Focus();
                return;
            }
            if (txtSoDem.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số đêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDem.Focus();
                return;
            }
            sql = "Select MaLoai from LOAIHINH$ where MaLoai=N'" + txtMaLoaiHinh.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Loại hình này đã có sẵn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiHinh.Focus();
                return;
            }
            sql = "INSERT INTO LOAIHINH$ VALUES(N'" +
               txtMaLoaiHinh.Text + "',N'" + txtTenLoaiHinh.Text + "','" +txtSoNgay.Text+ "','" +txtSoDem.Text +"')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewLoaiHinh(); //Nạp lại DataGridView
            Reset_Values();

        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaLoaiHinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã loại hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoaiHinh.Focus();
                return;
            }
            if (txtTenLoaiHinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên loại hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLoaiHinh.Focus();
                return;
            }
            if (txtSoNgay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoNgay.Focus();
                return;
            }
            if (txtSoDem.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số đêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDem.Focus();
                return;
            }
           
            sql = "Update LOAIHINH$ set  TenLoai=N'" + txtTenLoaiHinh.Text.ToString() + "',SoNgay='" + txtSoNgay.Text.ToString() + "',SoDem='" + txtSoDem.Text.ToString() + "'  Where MaLoai=N'" + txtMaLoaiHinh.Text + "'";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewLoaiHinh(); //Nạp lại DataGridView
            Reset_Values();


        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblLH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLoaiHinh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn loại hình muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE LOAIHINH$ WHERE MaLoai=N'" + txtMaLoaiHinh.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridViewLoaiHinh();
                Reset_Values();
            }
        }
        //Dành cho tab phương tiện
        private void LoadDataGridViewPhuongTien()
        {
            string sql;
            sql = "Select * from PHUONGTIEN$";
            tblPT = Class.Functions.GetDataToTable(sql);
            dataGridView2.DataSource = tblPT;
            dataGridView2.Columns[0].HeaderText = "Mã phương tiện";

            dataGridView2.Columns[1].HeaderText = "Tên phương tiện";

            dataGridView2.Columns[2].HeaderText = "Sức chứa";

            dataGridView2.AllowUserToAddRows = false; //Không cho thêm dữ liệu trực tiếp
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPT.Enabled = false;
            if (tblPT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaPT.Text = dataGridView2.CurrentRow.Cells["MaPhuongTien"].Value.ToString();
            txtTenPT.Text = dataGridView2.CurrentRow.Cells["TenPhuongTien"].Value.ToString();
            txtSucChua.Text = dataGridView2.CurrentRow.Cells["SucChua"].Value.ToString();
        }
        private void Reset_ValuesPT() //xóa dữ liệu trên ô textbox
        {
            txtMaPT.Text = "";
            txtTenPT.Text = " ";
            txtSucChua.Text = " ";
          
        }
        private void bttThempt_Click(object sender, EventArgs e)
        {
             string sql;
            if (txtMaPT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPT.Focus();
                return;
            }
            if (txtTenPT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenPT.Focus();
                return;
            }
            if (txtSucChua.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập sức chứa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSucChua.Focus();
                return;
            }
           
            sql = "Select MaPhuongTien from PHUONGTIEN$ where MaPhuongTien=N'" + txtMaPT.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Phương tiện này đã có sẵn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPT.Focus();
                return;
            }
            sql = "INSERT INTO PHUONGTIEN$ VALUES(N'" +
               txtMaPT.Text + "',N'" + txtTenPT.Text + "','" +txtSucChua.Text+ "')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewPhuongTien(); //Nạp lại DataGridView
            Reset_ValuesPT();
        }

        private void bttSuaPT_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaPT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPT.Focus();
                return;
            }
            if (txtTenPT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenPT.Focus();
                return;
            }
            if (txtSucChua.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập sức chứa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSucChua.Focus();
                return;
            }
            sql = "Update PHUONGTIEN$ set  TenPhuongTien=N'" + txtTenPT.Text.ToString() + "',SucChua='" + txtSucChua.Text.ToString() + "'  Where MaPhuongTien=N'" + txtMaPT.Text + "'";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewPhuongTien(); //Nạp lại DataGridView
            Reset_ValuesPT();

        }

        private void bttXoaPT_Click(object sender, EventArgs e)
        {
             string sql;
            if (tblPT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaPT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn phương tiện muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE PHUONGTIEN$ WHERE MaPhuongTien=N'" + txtMaPT.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridViewPhuongTien();
                Reset_ValuesPT();
            }
        
        }

        private void bttTimPT_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTimPT.Text=="")
            {  MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from PHUONGTIEN$ WHERE 1=1";
            if (txtTimPT.Text != "")
                sql += " AND MaPhuongTien LIKE N'%" + txtTimPT.Text + "%'";
            tblPT = Functions.GetDataToTable(sql);
            if (tblPT.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblPT.Rows.Count + " phương tiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView2.DataSource = tblPT;
            Reset_ValuesPT();
        }
        

        }
    }


