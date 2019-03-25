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
    public partial class KhachHang : Form
    {
        DataTable tblKH;
        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadDataGridViewKH();
        }
        private void LoadDataGridViewKH()
        {


            string sql;
            sql = "Select * from KHACHHANG$";
            tblKH = Class.Functions.GetDataToTable(sql);
            dataGridViewKH.DataSource = tblKH;
            dataGridViewKH.Columns[0].HeaderText = "Mã khách hàng";

            dataGridViewKH.Columns[1].HeaderText = "Họ khách hàng";
            dataGridViewKH.Columns[2].HeaderText = "Tên khách hàng";
            dataGridViewKH.Columns[3].HeaderText = "Địa chỉ";
            dataGridViewKH.Columns[4].HeaderText = "Số điện thoại";
            dataGridViewKH.AllowUserToAddRows = false; //Không cho thêm dữ liệu trực tiếp
            dataGridViewKH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

        }
        private void Reset_ValuesKH() //xóa dữ liệu trên ô textbox
        {
            txtMaKH.Text = "";
            txtHoKH.Text = "";
            txtTenKH.Text = "";
            txtSDTKH.Text = "";
            txtDiaChiKH.Text = "";

        }

        private void dataGridViewKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKH.Text = dataGridViewKH.CurrentRow.Cells["MaKH"].Value.ToString();
            txtHoKH.Text = dataGridViewKH.CurrentRow.Cells["HoKH"].Value.ToString();
            txtTenKH.Text = dataGridViewKH.CurrentRow.Cells["TenKH"].Value.ToString();
            txtDiaChiKH.Text = dataGridViewKH.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSDTKH.Text = dataGridViewKH.CurrentRow.Cells["SDT"].Value.ToString();
            txtMaKH.Enabled = false;
        }

        private void bttTim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaTKKH.Text == "") && (txtTenTKKH.Text == " ") && (txtSDTTK.Text == " "))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from KHACHHANG$ WHERE 1=1";
            if (txtMaTKKH.Text != "")
                sql += " AND MaKH LIKE N'%" + txtMaTKKH.Text + "%'";
            if (txtTenTKKH.Text != "")
                sql += "AND TenKH LIKE N'%" + txtTenTKKH.Text + "%'";
            if (txtSDTTK.Text != " ")
                sql += "AND SDT='" + txtSDTTK.Text + "'";
            tblKH = Functions.GetDataToTable(sql);
            if (tblKH.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblKH.Rows.Count + " khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewKH.DataSource = tblKH;
            Reset_ValuesKH();
        }

        private void bttThemKH_Click(object sender, EventArgs e)
        {

            string sql;
            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            if (txtHoKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập họ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoKH.Focus();
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            if (txtSDTKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDTKH.Focus();
                return;
            }

            sql = "Select MaKH from KHACHHANG$ where MaKH=N'" + txtMaKH.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Khách hàng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            sql = "INSERT INTO KHACHHANG$ VALUES(N'" +
               txtMaKH.Text + "',N'" + txtHoKH.Text + "',N'" + txtTenKH.Text + "',N'" + txtDiaChiKH.Text + "','" + txtSDTKH.Text + "','"+txtCMND.Text+"')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewKH(); //Nạp lại DataGridView
            Reset_ValuesKH();
        }

        private void bttSuaKH_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            if (txtHoKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập họ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoKH.Focus();
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            if (txtSDTKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDTKH.Focus();
                return;
            }
            sql = "Update KHACHHANG$ set  HoKH=N'" + txtHoKH.Text.ToString() + "',TenKH='" + txtTenKH.Text.ToString() + "',DiaChi=N'" + txtDiaChiKH.Text.ToString() + "', SDT='" + txtSDTKH.Text.ToString() + "', CMND='"+txtCMND.Text+"'  Where MaKH=N'" + txtMaKH.Text + "'";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewKH(); //Nạp lại DataGridView
            Reset_ValuesKH();

        }

        private void bttXoaKH_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "Select MaKH from DANGKI$ where MaKH=N'" + txtMaKH.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Khách hàng này không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            sql = "Select MaKH from HOADON$ where MaKH=N'" + txtMaKH.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Khách hàng này không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            sql = "Select MaKH from PHIEUCHI$ where MSKH=N'" + txtMaKH.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Khách hàng  này không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            sql = "Select MaKH from VETHAMQUAN$ where MaKH=N'" + txtMaKH.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Khách hàng này không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE KHACHHANG$ WHERE MaKH=N'" + txtMaKH.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridViewKH();
                Reset_ValuesKH();

            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

        
    

