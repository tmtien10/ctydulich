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
    public partial class KeToancs : Form
    {
        DataTable tblKT;
        public KeToancs()
        {
            InitializeComponent();
        }

        private void KeToancs_Load(object sender, EventArgs e)
        {
            LoadDataGridViewKT();
        }
        private void LoadDataGridViewKT()
        {

            string sql;
            sql = "Select * from KETOAN$";
            tblKT = Class.Functions.GetDataToTable(sql);
            dataGridViewKT.DataSource = tblKT;
            dataGridViewKT.Columns[0].HeaderText = "Mã nhân viên";

            dataGridViewKT.Columns[1].HeaderText = "Tên nhân viên";
            dataGridViewKT.Columns[2].HeaderText = "CMND";
            dataGridViewKT.Columns[3].HeaderText = "Địa chỉ";
            dataGridViewKT.Columns[4].HeaderText = "Chức vụ";

            dataGridViewKT.AllowUserToAddRows = false; //Không cho thêm dữ liệu trực tiếp
            dataGridViewKT.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void Reset_ValuesKT() //xóa dữ liệu trên ô textbox
        {
            txtMaKT.Text = "";
            txtTenKT.Text = " ";
            txtCMND.Text = " ";
            txtDiaChiKT.Text = " ";
            txtChucVu.Text = "";
            txtCongViec.Text = " ";
        }

        private void dataGridViewKT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (tblKT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKT.Text = dataGridViewKT.CurrentRow.Cells["MaKT"].Value.ToString();
            txtTenKT.Text = dataGridViewKT.CurrentRow.Cells["HoTenKT"].Value.ToString();
            txtCMND.Text = dataGridViewKT.CurrentRow.Cells["CMND"].Value.ToString();
            txtDiaChiKT.Text = dataGridViewKT.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtChucVu.Text = dataGridViewKT.CurrentRow.Cells["ChucVu"].Value.ToString();
            txtCongViec.Text = dataGridViewKT.CurrentRow.Cells["CongViec"].Value.ToString();
            txtMaKT.Enabled = false;
        }

        private void bttThemNV_Click(object sender, EventArgs e)
        {
        string sql;
            if (txtMaKT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKT.Focus();
                return;
            }
            if (txtTenKT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKT.Focus();
                return;
            }
            if (txtCMND.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCMND.Focus();
                return;
            }
            
            if (txtDiaChiKT.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChiKT.Focus();
                return;
            }
            if (txtChucVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChucVu.Focus();
                return;
            }
            sql = "Select MaKT from KETOAN$ where MaKT=N'" + txtMaKT.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Nhân viên này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKT.Focus();
                return;
            }
            sql = "INSERT INTO KETOAN$ VALUES(N'" +
               txtMaKT.Text + "',N'" + txtTenKT.Text + "','" +txtCMND.Text+ "',N'" +txtDiaChiKT.Text +"',N'"+txtChucVu.Text+"',N'" +txtCongViec.Text+"')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewKT(); //Nạp lại DataGridView
            Reset_ValuesKT();

        }

        private void bttSuaNV_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKT.Focus();
                return;
            }
            if (txtTenKT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKT.Focus();
                return;
            }
            if (txtCMND.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCMND.Focus();
                return;
            }
            if (txtDiaChiKT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChiKT.Focus();
                return;
            }
            if (txtChucVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChucVu.Focus();
                return;
            }
            sql = "Update KETOAN$ set  HoTenKT=N'" + txtTenKT.Text.ToString() + "',CMND='" + txtCMND.Text.ToString() + "',DiaChi=N'" + txtDiaChiKT.Text.ToString() + "', ChucVu=N'" + txtChucVu.Text.ToString() + "', CongViec=N'" + txtCongViec.Text.ToString() + "'  Where MaKT=N'" + txtMaKT.Text + "'";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewKT(); //Nạp lại DataGridView
            Reset_ValuesKT();
        }

        private void bttXoaNV_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            sql = "Select MSKT from HOADON$ where MSNV=N'" + txtMaKT.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Nhân viên này không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKT.Focus();
                return;
            }
            sql = "Select MSKT from PHIEUCHI$ where MSNV=N'" + txtMaKT.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Nhân viên này không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKT.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE KETOAN$ WHERE MaKT=N'" + txtMaKT.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridViewKT();
                Reset_ValuesKT();
            }
        }

        private void bttTimNV_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaKT.Text == "") && (txtTenKT.Text == " ") && (txtChucVu.Text == " "))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from KETOAN$ WHERE 1=1";
            if (txtMaKT.Text != "")
                sql += " AND MaKT LIKE N'%" + txtMaKT.Text + "%'";
            if (txtTenKT.Text != "")
                sql += "AND HoTenKT LIKE N'%" + txtTenKT.Text + "%'";
            if (txtChucVu.Text != " ")
                sql += "AND ChucVu LIKE N'%" + txtChucVu.Text + "%'";
            tblKT = Functions.GetDataToTable(sql);
            if (tblKT.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblKT.Rows.Count + " nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewKT.DataSource = tblKT;
            Reset_ValuesKT();
        }
        }
    }


