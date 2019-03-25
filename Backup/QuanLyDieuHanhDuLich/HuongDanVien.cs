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
    public partial class HuongDanVien : Form
    {
        DataTable tblHDV;
        public HuongDanVien()
        {
            InitializeComponent();
        }

        private void HuongDanVien_Load(object sender, EventArgs e)
        {
            LoadDataGridViewHDV();
        }
        private void LoadDataGridViewHDV()
        {

            string sql;
            sql = "Select * from HUONGDANVIEN$";
            tblHDV = Class.Functions.GetDataToTable(sql);
            dataGridViewHDV.DataSource = tblHDV;
            dataGridViewHDV.Columns[0].HeaderText = "Mã HDV";

            dataGridViewHDV.Columns[1].HeaderText = "Họ HDV";
            dataGridViewHDV.Columns[2].HeaderText = "Tên HDV";
            dataGridViewHDV.Columns[3].HeaderText = "Chức vụ";
            dataGridViewHDV.Columns[4].HeaderText = "Địa chỉ";
            dataGridViewHDV.Columns[5].HeaderText = "Số điện thoại";
            dataGridViewHDV.AllowUserToAddRows = false; //Không cho thêm dữ liệu trực tiếp
            dataGridViewHDV.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

        }
        private void Reset_ValuesHDV() //xóa dữ liệu trên ô textbox
        {
            txtMaHDV.Text = "";
            txtHoHDV.Text = "";
            txtTenHDV.Text = "";
            txtChucVuHDV.Text = "";
            txtDiaChiHDV.Text = "";
            txtSDTHDV.Text = "";

        }

        private void dataGridViewHDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblHDV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHDV.Text = dataGridViewHDV.CurrentRow.Cells["MaHDV"].Value.ToString();
            txtHoHDV.Text = dataGridViewHDV.CurrentRow.Cells["HoHDV"].Value.ToString();
            txtTenHDV.Text = dataGridViewHDV.CurrentRow.Cells["TenHDV"].Value.ToString();
            txtChucVuHDV.Text = dataGridViewHDV.CurrentRow.Cells["ChucVu"].Value.ToString();
            txtDiaChiHDV.Text = dataGridViewHDV.CurrentRow.Cells["DiaChiHDV"].Value.ToString();
            txtSDTHDV.Text = dataGridViewHDV.CurrentRow.Cells["SDT"].Value.ToString();
            if (txtChucVuHDV.Text == "")
                radioButton2.Checked = true;
            else radioButton1.Checked = true;
            
            txtMaHDV.Enabled = false;

        }

        private void bttTim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaTKHDV.Text == "") && (txtTenTKHDV.Text == " ") && (txtChucVuTK.Text == " "))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from HUONGDANVIEN$ WHERE 1=1";
            if (txtMaTKHDV.Text != "")
                sql += " AND MSNV LIKE N'%" + txtMaTKHDV.Text + "%'";
            if (txtTenTKHDV.Text != "")
                sql += "AND TenHDV LIKE N'%" + txtTenTKHDV.Text + "%'";
            if (txtChucVuTK.Text != " ")
                sql += "AND ChucVu LIKE N'%" + txtChucVuTK.Text + "%'";
            tblHDV = Functions.GetDataToTable(sql);
            if (tblHDV.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblHDV.Rows.Count + " hướng dẫn viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewHDV.DataSource = tblHDV;
            Reset_ValuesHDV();

        }

        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtChucVuHDV.Text = "";
            txtChucVuHDV.Enabled = false;
        }

        private void bttThemHDV_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaHDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã hướng dẫn viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHDV.Focus();
                return;
            }
            if (txtHoHDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập họ hướng dẫn viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoHDV.Focus();
                return;
            }
            if (txtTenHDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên hướng dẫn viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHDV.Focus();
                return;
            }
            if (txtSDTHDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChucVuHDV.Focus();
                return;
            }
            if (txtDiaChiHDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChucVuHDV.Focus();
                return;
            }
            sql = "Select MaHDV from HUONGDANVIEN$ where MaHDV=N'" + txtMaHDV.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Hướng dẫn viên này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHDV.Focus();
                return;
            }
            sql = "INSERT INTO HUONGDANVIEN$ VALUES(N'" +
               txtMaHDV.Text + "',N'" + txtHoHDV.Text + "',N'" + txtTenHDV.Text + "',N'" + txtChucVuHDV.Text + "',N'" + txtDiaChiHDV.Text + "','" + txtSDTHDV.Text + "')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewHDV(); //Nạp lại DataGridView
            Reset_ValuesHDV();
        }

        private void bttSuaHDV_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaHDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHDV.Focus();
                return;
            }
            if (txtHoHDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập họ hướng dẫn viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoHDV.Focus();
                return;
            }
            if (txtTenHDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên hướng dẫn viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHDV.Focus();
                return;
            }
            
            
            sql = "Update HUONGDANVIEN$ set  HoHDV=N'" + txtHoHDV.Text.ToString() + "',TenHDV='" + txtTenHDV.Text.ToString() + "',ChucVu=N'" + txtChucVuHDV.Text.ToString() + "', DiaChiHDV=N'" + txtDiaChiHDV.Text.ToString() + "', SDT='" + txtSDTHDV.Text.ToString() + "'  Where MaHDV=N'" + txtMaHDV.Text + "'";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewHDV(); //Nạp lại DataGridView
            Reset_ValuesHDV();


        }

        private void bttXoaHDV_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHDV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHDV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn hướng dẫn viên muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "Select MaHDV from DOANTHAMQUAN$ where MaHDV=N'" + txtMaHDV.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Nhân viên này không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHDV.Focus();
                return;
            }
           
            if (MessageBox.Show("Bạn có muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE HUONGDANVIEN$ WHERE MaHDV=N'" + txtMaHDV.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridViewHDV();
                Reset_ValuesHDV();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtChucVuHDV.Enabled = true;

        }

       


    }
}
