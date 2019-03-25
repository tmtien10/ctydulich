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
    public partial class Phieuchi : Form
    {
        DataTable tblPC;
        public Phieuchi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chi_tiet_phieu_chi ctpc = new Chi_tiet_phieu_chi();
            ctpc.ShowDialog();
        }

        private void bttTim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaTourTK.Text == "") && (txtPC.Text == "") && (txtKH.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = " Select * from PHIEUCHI$ where 1=1";
            if (txtPC.Text != "")
                sql += " AND SoPC LIKE N'%" + txtPC.Text + "%'";
            if (txtMaTourTK.Text != "")
                sql += "AND MaTour LIKE N'%" + txtMaTourTK.Text + "%'";
            if (txtKH.Text != "")
                sql += "AND MaKH LIKE N'%" + txtKH.Text + "%'";


            tblPC = Class.Functions.GetDataToTable(sql);
            if (tblPC.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblPC.Rows.Count + "phiếu chi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewDSPC.DataSource = tblPC;
            Reset_Values();
        }
        public void LoadDataGridViewPC()
        {

            string sql;
            sql = "Select * FROM PHIEUCHI$ ";
            tblPC = Functions.GetDataToTable(sql);
            dataGridViewDSPC.DataSource = tblPC;
            dataGridViewDSPC.Columns[0].HeaderText = "Số phiếu chi";
            dataGridViewDSPC.Columns[1].HeaderText = "Nhân viên điều hành";
            dataGridViewDSPC.Columns[2].HeaderText = "Kế toán";
            dataGridViewDSPC.Columns[3].HeaderText = "Mã khách hàng";
            dataGridViewDSPC.Columns[4].HeaderText = "Mã tour";
            dataGridViewDSPC.Columns[5].HeaderText = "Ngày lập";
            dataGridViewDSPC.Columns[6].HeaderText = "Số tiền hoàn trả";

            dataGridViewDSPC.AllowUserToAddRows = false;
            dataGridViewDSPC.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void Reset_Values()
        {
            txtMaTourTK.Text = "";
            txtPC.Text = "";
            txtKH.Text = "";

        }

        private void dataGridViewDSPC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mapc;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mapc = dataGridViewDSPC.CurrentRow.Cells["SoPC"].Value.ToString();
                Chi_tiet_phieu_chi pcpc = new Chi_tiet_phieu_chi();
                pcpc.txtSoPC.Text = mapc;
                pcpc.StartPosition = FormStartPosition.CenterParent;
                pcpc.ShowDialog();
            }
        }

        private void Phieuchi_Load(object sender, EventArgs e)
        {
            LoadDataGridViewPC();
        }
    }
}
