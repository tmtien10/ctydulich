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
    public partial class Danh_mục_phiếu_đăng_kí : Form
    {
        DataTable tblDK;
        public Danh_mục_phiếu_đăng_kí()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Chi_tiet_dang_ki ctdk = new Chi_tiet_dang_ki();
            ctdk.ShowDialog();
        }

        private void Danh_mục_phiếu_đăng_kí_Load(object sender, EventArgs e)
        {
            LoadDataGridViewDK();
            Reset_Values();
        }
        public void LoadDataGridViewDK() {

            string sql;
            sql = "Select SoPhieuDK, MaKH, MATOUR, NgayDK, NgayHuyDK FROM DANGKI$ ";
            tblDK = Functions.GetDataToTable(sql);
            dataGridViewDK.DataSource = tblDK;
            dataGridViewDK.Columns[0].HeaderText = "Số thứ tự";
            dataGridViewDK.Columns[1].HeaderText = "Mã khách hàng";
            dataGridViewDK.Columns[2].HeaderText = "Mã tour";
            dataGridViewDK.Columns[3].HeaderText = "Ngày đăng kí";
            dataGridViewDK.Columns[4].HeaderText = "Ngày hủy đăng kí";
            dataGridViewDK.AllowUserToAddRows = false;
            dataGridViewDK.EditMode = DataGridViewEditMode.EditProgrammatically;
        
        }
        private void Reset_Values() {
            txtMaTour.Text = "";
            txtSoPhieu.Text = "";
            txtDay.Text = "";
            MaKH.Text = "";
        }

        private void dataGridViewDK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string maphieudk;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                maphieudk = dataGridViewDK.CurrentRow.Cells["SoPhieuDK"].Value.ToString();
                 Chi_tiet_dang_ki dk = new Chi_tiet_dang_ki();
                dk.txtSoPhieu.Text = maphieudk;
                dk.txtSoPhieu.Enabled = false;
                dk.StartPosition = FormStartPosition.CenterParent;
                dk.ShowDialog();
            }
        }

        private void bttTK_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaTour.Text == "") && (txtSoPhieu.Text == "") && (txtDay.Text == "") && (txtDay.Text == "") & (txtMonth.Text == "") && (txtYear.Text==""))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;    
            }
            sql = " Select * from DANGKI$ where 1=1";
            if (txtSoPhieu.Text != "")
                sql += " AND SoPhieuDK LIKE N'%" + txtSoPhieu.Text + "%'";
            if (txtMaTour.Text != "")
                sql += "AND MaTour LIKE N'%" + txtMaTour.Text + "%'";
            if (MaKH.Text != "")
                sql += "AND MaKH LIKE N'%"+ MaKH.Text + "%'";
            if (txtDay.Text != "")
                sql += "AND DAY(NgayDK) <='" + txtDay.Text + "'";
            if (txtMonth.Text != "")
                sql += "AND MONTH(NgayDK)='" + txtMonth.Text + "'";
            if (txtYear.Text != "")
                sql += "AND YEAR(NgayDK)='" + txtYear.Text + "'";
            tblDK = Class.Functions.GetDataToTable(sql);
            if (tblDK.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblDK.Rows.Count + " phiếu đăng kí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewDK.DataSource = tblDK;
            Reset_Values();

        }
    }
}
