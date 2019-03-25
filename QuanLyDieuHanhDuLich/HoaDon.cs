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
    public partial class HoaDon : Form
    { DataTable tblHD;
        public HoaDon()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Chi_tiet_hoa_don cthd = new Chi_tiet_hoa_don();
            cthd.ShowDialog();
        }

        private void bttTim_Click(object sender, EventArgs e)
        {
             string sql;
            if ((txtMaTour.Text == "") && (txtSoHD.Text == "") && (txtMaKH.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;    
            }
            sql = " Select * from HOADON$ where 1=1";
            if (txtSoHD.Text != "")
                sql += " AND SoHD LIKE N'%" + txtSoHD.Text + "%'";
            if (txtMaTour.Text != "")
                sql += "AND MaTour LIKE N'%" + txtMaTour.Text + "%'";
            if (txtMaKH.Text != "")
                sql += "AND MaKH LIKE N'%"+ txtMaKH.Text + "%'";
           
         
            tblHD = Class.Functions.GetDataToTable(sql);
            if (tblHD.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblHD.Rows.Count + " hóa  đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewdshd.DataSource = tblHD;
            Reset_Values();
        }

        private void dataGridViewdshd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dataGridViewdshd.CurrentRow.Cells["SoHD"].Value.ToString();
                Chi_tiet_hoa_don hdtk = new Chi_tiet_hoa_don();
                hdtk.txtSoHD.Text = mahd;
                hdtk.StartPosition = FormStartPosition.CenterParent;
                hdtk.ShowDialog();
        }}
        public void LoadDataGridViewHD() {

            string sql;
            sql = "Select * FROM HOADON$ ";
            tblHD = Functions.GetDataToTable(sql);
            dataGridViewdshd.DataSource = tblHD;
            dataGridViewdshd.Columns[0].HeaderText = "Số hóa đơn";
            dataGridViewdshd.Columns[1].HeaderText = "Nhân viên điều hành";
            dataGridViewdshd.Columns[2].HeaderText = "Kế toán";
            dataGridViewdshd.Columns[3].HeaderText = "Mã khách hàng";
            dataGridViewdshd.Columns[4].HeaderText = "Mã tour";
             dataGridViewdshd.Columns[5].HeaderText = "Ngày lập";
            dataGridViewdshd.AllowUserToAddRows = false;
            dataGridViewdshd.EditMode = DataGridViewEditMode.EditProgrammatically;
        
        }
        private void Reset_Values() {
            txtMaTour.Text = "";
            txtSoHD.Text = "";
            txtMaKH.Text = "";
         
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadDataGridViewHD();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        }

      

       
    }

