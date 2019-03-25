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
    public partial class NhanVien : Form
    {
        DataTable tblNV;
        public NhanVien()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {//click một nv trong bảng thì nó sẽ hiển thị tt chi tiết
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNV.Text = dataGridViewNV.CurrentRow.Cells["MSNV"].Value.ToString();
            txtTenNV.Text = dataGridViewNV.CurrentRow.Cells["TenNV"].Value.ToString();
            txtCMND.Text = dataGridViewNV.CurrentRow.Cells["CMND"].Value.ToString();
            txtDiaChiNV.Text = dataGridViewNV.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtChucVu.Text = dataGridViewNV.CurrentRow.Cells["ChucVu"].Value.ToString();
            txtCongViec.Text = dataGridViewNV.CurrentRow.Cells["CongViec"].Value.ToString();
            txtMaNV.Enabled = false;//đóng băng mã nv
        }
        


        private void NhanVien_Load(object sender, EventArgs e)
        {//load form
            LoadDataGridViewNV();

        }
        private void LoadDataGridViewNV(){ //load dữ liệu lên form

            string sql;
            sql = "Select * from NHANVIEN$";
            tblNV = Class.Functions.GetDataToTable(sql);
            dataGridViewNV.DataSource = tblNV;
            dataGridViewNV.Columns[0].HeaderText = "Mã nhân viên";

            dataGridViewNV.Columns[1].HeaderText = "Tên nhân viên";
            dataGridViewNV.Columns[2].HeaderText = "CMND";
            dataGridViewNV.Columns[3].HeaderText = "Địa chỉ";
            dataGridViewNV.Columns[4].HeaderText = "Chức vụ";

            dataGridViewNV.AllowUserToAddRows = false; //Không cho thêm dữ liệu trực tiếp
            dataGridViewNV.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void Reset_ValuesNV() //xóa dữ liệu ghi trên ô text
        {
            txtMaNV.Text = "";
            txtTenNV.Text = " ";
            txtCMND.Text = " ";
            txtDiaChiNV.Text = " ";
            txtChucVu.Text = "";
            txtCongViec.Text = " ";
        }

        

        private void bttThemNV_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (txtCMND.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCMND.Focus();
                return;
            }
            
            if (txtDiaChiNV.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChiNV.Focus();
                return;
            }
            if (txtChucVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChucVu.Focus();
                return;
            }
            sql = "Select MSNV from NHANVIEN$ where MSNV=N'" + txtMaNV.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Nhân viên này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            sql = "INSERT INTO NHANVIEN$ VALUES(N'" +
               txtMaNV.Text + "',N'" + txtTenNV.Text + "','" +txtCMND.Text+ "',N'" +txtDiaChiNV.Text +"',N'"+txtChucVu.Text+"',N'" +txtCongViec.Text+"')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewNV(); //Nạp lại DataGridView
            Reset_ValuesNV();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bttSuaNV_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (txtCMND.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCMND.Focus();
                return;
            }
            if (txtDiaChiNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChiNV.Focus();
                return;
            }
            if (txtChucVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChucVu.Focus();
                return;
            }
            sql = "Update NHANVIEN$ set  TenNV=N'" + txtTenNV.Text.ToString() + "',CMND='" + txtCMND.Text.ToString() + "',DiaChi=N'" + txtDiaChiNV.Text.ToString() + "', ChucVu=N'" + txtChucVu.Text.ToString()+ "', CongViec=N'" +txtCongViec.Text.ToString()+ "'  Where MSNV=N'" + txtMaNV.Text + "'";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewNV(); //Nạp lại DataGridView
            Reset_ValuesNV();


        }

        private void bttXoaNV_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "Select MSNV from DANGKI$ where MSNV=N'" + txtMaNV.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Nhân viên này không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            sql = "Select MSNV from HOADON$ where MSNV=N'" + txtMaNV.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Nhân viên này không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            sql = "Select MSNV from PHIEUCHI$ where MSNV=N'" + txtMaNV.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Nhân viên này không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
                       
            if (MessageBox.Show("Bạn có muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NHANVIEN$ WHERE MSNV=N'" + txtMaNV.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridViewNV();
                Reset_ValuesNV();
            }
        }

        private void bttTimNV_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaNV.Text=="") && (txtTenNV.Text==" ")&& (txtChucVu.Text==" "))
            {  MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from NHANVIEN$ WHERE 1=1";//lệnh sql
            if (txtMaNV.Text != "")
                sql += " AND MSNV LIKE N'%" + txtMaNV.Text + "%'";
            if (txtTenNV.Text != "")
                sql += "AND TenNV LIKE N'%"+txtTenNV.Text+ "%'";
            if (txtChucVu.Text != " ")
                sql += "AND ChucVu LIKE N'%" + txtChucVu.Text + "%'";
            tblNV = Functions.GetDataToTable(sql);
            if (tblNV.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblNV.Rows.Count + " nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewNV.DataSource = tblNV;
            Reset_ValuesNV();
        }

        private void button1_Click(object sender, EventArgs e)
        {//đóng form
            this.Close();
        }
        }

        
        }

       
    

