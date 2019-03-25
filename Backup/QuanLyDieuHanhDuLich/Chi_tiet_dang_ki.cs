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
using COMExcel = Microsoft.Office.Interop.Excel;


namespace QuanLyDieuHanhDuLich
{
    public partial class Chi_tiet_dang_ki : Form
    {
        public Chi_tiet_dang_ki()
        {
            InitializeComponent();
        }

        private static string creakeyDK()
        {
            int i;
            string ma, sql;

            sql = "SELECT TOP (1) SoPhieuDK FROM DANGKI$ ORDER BY SoPhieuDK DESC";
            ma = Functions.GetFieldValues(sql);
            if (ma =="") i = 0;
            else i = int.Parse(ma);
            i += 1;
            ma = Convert.ToString(i);
            return ma;
        }

        private void Chi_tiet_dang_ki_Load(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaKH, TenKH FROM KHACHHANG$", comboMaKH, "MaKH", "MaKH");
            comboMaKH.SelectedIndex = -1;
            Functions.FillCombo("SELECT MSNV  from NHANVIEN$", comboMaNV, "MSNV", "MSNV");
            comboMaNV.SelectedIndex = -1;
            Functions.FillCombo("SELECT MATOUR FROM TOUR$", comboMaTour, "MATOUR", "MATOUR");
            comboMaTour.SelectedIndex = -1;
            //Từ form danh mục
            if (txtSoPhieu.Text != "")
            {
                txtSoPhieu.Enabled = false;
                comboMaKH.Enabled = false;
                comboMaTour.Enabled = false;
                comboMaNV.Enabled = false;
                LoadInforDK();
            }
        }
        private void LoadInforDK()
        {

            string sql;
            sql = "select MaKH from DANGKI$ where SoPhieuDK=N'" + txtSoPhieu.Text + "'";
            comboMaKH.SelectedValue = Functions.GetFieldValues(sql);
            sql = "select MATOUR from DANGKI$ where SoPhieuDK=N'" + txtSoPhieu.Text + "'";
            comboMaTour.Text = Functions.GetFieldValues(sql);
            sql = "select MSNV from DANGKI$ where SoPhieuDK=N'" + txtSoPhieu.Text + "'";
            comboMaNV.SelectedValue = Functions.GetFieldValues(sql);
            sql = "select NgayDK from DANGKI$ where SoPhieuDK=N'" + txtSoPhieu.Text + "'";
            txtNgayDK.Text = Functions.GetFieldValues(sql);
            sql = "select NgayHuyDK from DANGKI$ where SoPhieuDK=N'" + txtSoPhieu.Text + "'";
            txtNgayHuyDK.Text = Functions.GetFieldValues(sql);

        }
        private void Reset_ValuesDK()
        {
            comboMaKH.Text = "";
            txtHoKH.Text = "";
            txtTenKH.Text = "";
            txtSoPhieu.Text="";
            txtNgayKH.Text = "";
            txtSDT.Text = "";
            comboMaNV.Text = "";
            comboMaTour.Text = "";
            txtTenTour.Text = "";
            txtNgayKH.Text = "";
            txtLH.Text = "";
            txtMaTuyen.Text = "";
            txtNgayDK.Text = "";
            txtNgayHuyDK.Text = "";
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            txtSoPhieu.Text = creakeyDK();
            txtSoPhieu.Enabled = false;
            bttSua.Enabled = false;
            bttXoa.Enabled = false;
            txtNgayDK.Text = DateTime.Now.ToString().Trim();
        }

        private void comboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (comboMaKH.Text == "")
            {
                txtHoKH.Text = "";
                txtTenKH.Text = "";
                txtSDT.Text = "";
                txtDC.Text = "";
            }
            sql = "SELECT HoKH from KHACHHANG$ where MaKH=N'" + comboMaKH.SelectedValue + "'";
            txtHoKH.Text = Functions.GetFieldValues(sql);
            sql = "SELECT TenKH from KHACHHANG$ where MaKH=N'" + comboMaKH.SelectedValue + "'";
            txtTenKH.Text = Functions.GetFieldValues(sql);
            sql = "SELECT TenKH from KHACHHANG$ where MaKH=N'" + comboMaKH.SelectedValue + "'";
            txtTenKH.Text = Functions.GetFieldValues(sql);
            sql = "SELECT SDT from KHACHHANG$ where MaKH=N'" + comboMaKH.SelectedValue + "'";
            txtSDT.Text = Functions.GetFieldValues(sql);
            sql = "SELECT DiaChi from KHACHHANG$ where MaKH=N'" + comboMaKH.SelectedValue + "'";
            txtDC.Text = Functions.GetFieldValues(sql);
            sql = "SELECT CMND from KHACHHANG$ where MaKH=N'" + comboMaKH.SelectedValue + "'";
            txtCMND.Text = Functions.GetFieldValues(sql);


        }

        private void comboMaTour_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (comboMaTour.Text == "")
            {
                txtTenTour.Text = "";
                txtMaTuyen.Text = "";
                txtNgayKH.Text = "";
                txtLH.Text = "";
            }
           
            sql = "SELECT TENTOUR from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            txtTenTour.Text = Functions.GetFieldValues(sql);
            sql = "SELECT MaTuyen from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            txtMaTuyen.Text = Functions.GetFieldValues(sql);
            sql = "SELECT NGAYKH from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            txtNgayKH.Text = Functions.GetFieldValues(sql);
            sql = "SELECT MaLoai from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            txtLH.Text = Functions.GetFieldValues(sql);

        }

        private void comboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (comboMaNV.Text == "")
            {
                txtTenNV.Text = "";
            }
            sql = "SELECT TenNV from NHANVIEN$ where MSNV=N'" + comboMaNV.SelectedValue + "'";
            txtTenNV.Text = Functions.GetFieldValues(sql);
        }

        private void bttLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (comboMaTour.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboMaTour.Focus();
                return;
            }
            if (comboMaKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboMaKH.Focus();
                return;
            }

            sql = "Select SoPhieuDK from DANGKI$ where SoPhieuDK='" + txtSoPhieu.Text + "'";
            if (Functions.CheckKey(sql))
            {

                MessageBox.Show("Không thể sửa thông tin đã đăng kí. Vui lòng tạo một đăng kí mới hoặc xóa đăng kí cũ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;

            }
            sql = "INSERT INTO DANGKI$ (SoPhieuDK, MaKH, MATOUR, MSNV , NgayDK, NgayHuyDK) Values (N'" + txtSoPhieu.Text + "', N'" + comboMaKH.SelectedValue +
                "', N'" + comboMaTour.SelectedValue + "', '" +comboMaNV.Text+"', '"+ txtNgayDK.Text + "',NULL)";
            Functions.RunSQL(sql);
            Danh_mục_phiếu_đăng_kí dkp = new Danh_mục_phiếu_đăng_kí();
            dkp.StartPosition = FormStartPosition.CenterParent;
            dkp.ShowDialog();
            dkp.LoadDataGridViewDK();

            Reset_ValuesDK();
        }



        private void bttXoa_Click(object sender, EventArgs e)
        {
            string sql;


            if (txtSoPhieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM DANGKI$ WHERE SoPhieuDK=N'" + txtSoPhieu.Text + "'";
                Functions.RunSqlDel(sql);
         
                Danh_mục_phiếu_đăng_kí dkp = new Danh_mục_phiếu_đăng_kí();
                dkp.StartPosition = FormStartPosition.CenterParent;
                dkp.ShowDialog();
                dkp.LoadDataGridViewDK();
                Reset_ValuesDK();

            }


        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sql;
            txtNgayHuyDK.Text = DateTime.Now.ToString().Trim();
            sql = "UPDATE DANGKI$ SET  NgayHuyDK='" + txtNgayHuyDK.Text + "' where SoPhieuDK=N'" + txtSoPhieu.Text + "'";
            Functions.RunSQL(sql);
            Reset_ValuesDK();
            Danh_mục_phiếu_đăng_kí dkp = new Danh_mục_phiếu_đăng_kí();
            dkp.StartPosition = FormStartPosition.CenterParent;
            dkp.ShowDialog();
            dkp.LoadDataGridViewDK();

            Reset_ValuesDK();

        }

        

        

        
    }
}