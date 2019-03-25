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
    public partial class DSdvetq : Form
    {
        DataTable tblVe;
        public DSdvetq()
        {
            InitializeComponent();
        }

        private void DSdvetq_Load(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaKH, TenKH FROM KHACHHANG$", comboMaKH, "MaKH", "MaKH");
            comboMaKH.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaDoan  from DOANTHAMQUAN$ ", comboMaDoan, "MaDoan", "MaDoan");
            comboMaDoan.SelectedIndex = -1;
            Functions.FillCombo("SELECT MATOUR FROM TOUR$", comboMaTour, "MATOUR", "MATOUR");
            comboMaTour.SelectedIndex = -1;
            LoaDataGridView();
            Reset_Values();

        }
        private static string creakeyDK()
        {
            int i;
            string ma, sql;

            sql = "SELECT TOP (1) STTVE FROM VETHAMQUAN$ ORDER BY STTVE DESC";
            ma = Functions.GetFieldValues(sql);
            if (ma =="") i = 0;
            else i = int.Parse(ma);
            i += 1;
            ma = Convert.ToString(i);
            return ma;
        }
        private void Reset_Values()
        {
            comboMaKH.Text = "";
            txtHoKH.Text = "";
            txtTenKH.Text = "";
            comboMaTour.Text = "";
            txtTenTour.Text = "";
            txtNgayKH.Text = "";
            txtDoan.Text = "";
            comboMaDoan.Text = "";
        }
        private void LoaDataGridView()
        {
            string sql;
            sql = "Select * FROM VETHAMQUAN$ ";
            tblVe = Functions.GetDataToTable(sql);
            dataGridViewVe.DataSource = tblVe;
            dataGridViewVe.Columns[0].HeaderText = "Số thứ tự";
            dataGridViewVe.Columns[1].HeaderText = "Mã khách hàng";
            dataGridViewVe.Columns[2].HeaderText = "Mã tour";
            dataGridViewVe.Columns[3].HeaderText = "Mã đoàn";

            dataGridViewVe.AllowUserToAddRows = false;
            dataGridViewVe.EditMode = DataGridViewEditMode.EditProgrammatically;


        }

        private void comboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sql;
            if (comboMaKH.Text == "")
            {
                txtHoKH.Text = "";
                txtTenKH.Text = "";

            }
            sql = "SELECT HoKH from KHACHHANG$ where MaKH=N'" + comboMaKH.SelectedValue + "'";
            txtHoKH.Text = Functions.GetFieldValues(sql);
            sql = "SELECT TenKH from KHACHHANG$ where MaKH=N'" + comboMaKH.SelectedValue + "'";
            txtTenKH.Text = Functions.GetFieldValues(sql);

        }

        private void comboMaTour_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (comboMaTour.Text == "")
            {
                txtTenTour.Text = "";

                txtNgayKH.Text = "";

            }
            sql = "SELECT TENTOUR from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            txtTenTour.Text = Functions.GetFieldValues(sql);

            sql = "SELECT NGAYKH from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            txtNgayKH.Text = Functions.GetFieldValues(sql);
            sql = "SELECT MaDoan from DOANTHAMQUAN$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            Functions.FillCombo(sql, comboMaDoan, "MaDoan", "MaDoan");
        }

        private void comboMaDoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (comboMaDoan.Text == "")
            {
                txtDoan.Text = "";
            }
            sql = "SELECT TenDoan from DOANTHAMQUAN$ where MaDoan=N'" + comboMaDoan.SelectedValue + "'";
            txtDoan.Text = Functions.GetFieldValues(sql);
        }

        private void bttThem_Click(object sender, EventArgs e)
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

            if (comboMaDoan.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã đoàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboMaDoan.Focus();
                return;
            }

            txtVe.Text = creakeyDK();
            sql = "INSERT INTO VETHAMQUAN$  (STTVE, MaKH, MATOUR , MaDoan) Values (N'" + txtVe.Text + "', N'" + comboMaKH.SelectedValue +
                "', N'" + comboMaTour.SelectedValue + "', N'" + comboMaDoan.SelectedValue + "')";
            Functions.RunSQL(sql);


            LoaDataGridView();
            Reset_Values();
        }

        private void dataGridViewVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVe.Enabled = false;
            txtDoan.Enabled = false;
            if (tblVe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtVe.Text = dataGridViewVe.CurrentRow.Cells["STTVE"].Value.ToString();
            comboMaKH.Text = dataGridViewVe.CurrentRow.Cells["MaKH"].Value.ToString();
            comboMaTour.Text = dataGridViewVe.CurrentRow.Cells["MATOUR"].Value.ToString();
            comboMaDoan.Text = dataGridViewVe.CurrentRow.Cells["MaDoan"].Value.ToString();
            //comboMaTour.Text = dataGridViewDTQ.CurrentRow.Cells["MATOUR"].Value.ToString();
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblVe.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtVe.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn vé muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE VETHAMQUAN$ WHERE STTVE=N'" + txtVe.Text + "'";
                Functions.RunSqlDel(sql);
                LoaDataGridView();
                Reset_Values();
            }
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (comboMaDoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã đoàn ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboMaDoan.Focus();
                return;
            }

            if (comboMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboMaKH.Focus();
                return;
            }
            if (comboMaTour.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboMaTour.Focus();
                return;
            }
            sql = "Update VETHAMQUAN$ set  MaKH=N'" + comboMaKH.Text.ToString() + "',MATOUR=N'" + comboMaTour.SelectedValue.ToString() + "', MaDoan=N'" + comboMaDoan.SelectedValue.ToString() + "'  Where STTVE=N'" + txtVe.Text + "'";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoaDataGridView(); //Nạp lại DataGridView
            Reset_Values();
        }

        private void bttTim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((comboMaDoan.Text == "") && (comboMaTour.Text == "") && (comboMaKH.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = " Select * from VETHAMQUAN$ where 1=1";
            if (comboMaDoan.Text != "")
                sql += " AND MaDoan LIKE N'%" + comboMaDoan.Text + "%'";
            if (comboMaTour.Text != "")
                sql += "AND MATOUR LIKE N'%" + comboMaTour.SelectedValue + "%'";
            if (comboMaKH.Text != "")
                sql += "AND MaKH LIKE N'%" + comboMaKH.Text + "%'";
            if (txtVe.Text != "")
                sql += "AND STTVE LIKE N'%" + txtVe.Text + "%'";
            tblVe = Class.Functions.GetDataToTable(sql);
            if (tblVe.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblVe.Rows.Count + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewVe.DataSource = tblVe;
            Reset_Values();
        }

        private void bttIn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
           
            DataTable tblThongtinKH, tblLH;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = (Microsoft.Office.Interop.Excel.Worksheet)exBook.Worksheets[1];
            //
            exRange = (Microsoft.Office.Interop.Excel.Range)exSheet.Cells[1, 1];
            exRange.get_Range("A1","Z100").Font.Name="Time New roman";//font chữ
            exRange.get_Range("G2","J2").Font.Size = 24;
            exRange.get_Range("G2", "J2").Font.Bold = true;
            exRange.get_Range("G2", "J2").MergeCells = true;
            exRange.get_Range("G2", "J2").HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.get_Range("G2", "J2").Value2 = " VÉ THAM QUAN";
            //Thông tin 
            sql = " SELECT a.MaKH,a.HoKH, a.TenKH, b.MATOUR , b.TENTOUR, b.NGAYKH, c.MaDoan , c.TenDoan from KHACHHANG$ a, TOUR$ b, DOANTHAMQUAN$ c, VETHAMQUAN$ d where d.STTVE=N'" 
                + txtVe.Text + 
                "' AND  a.MaKH=d.MaKH AND b.MATOUR=d.MATOUR AND c.MaDoan=d.MaDoan ";
            tblThongtinKH = Functions.GetDataToTable(sql);
            exRange.get_Range("E4", "M15").Font.Size = 14;
            exRange.get_Range("E4", "E4").Value2 = " Mã số khách hàng :";
            exRange.get_Range("E4", "E4").MergeCells = true;
            exRange.get_Range("H4", "J4").Value2 = tblThongtinKH.Rows[0][0].ToString();
            exRange.get_Range("H4", "J4").MergeCells = true;
            exRange.get_Range("E5", "E5").Value2 = " Họ khách hàng :";
            exRange.get_Range("E5", "E5").MergeCells = true;
            exRange.get_Range("H5", "J5").Value2 = tblThongtinKH.Rows[0][1].ToString();
            exRange.get_Range("H5", "J5").MergeCells = true;
            exRange.get_Range("E6", "E6").Value2 = " Tên khách hàng :";
            exRange.get_Range("E6", "E6").MergeCells = true;
            exRange.get_Range("H6", "J6").Value2 = tblThongtinKH.Rows[0][2].ToString();
            exRange.get_Range("H6", "J6").MergeCells = true;
            exRange.get_Range("E7", "E7").Value2 = " Tour :";
            exRange.get_Range("E7", "E7").MergeCells = true;
            exRange.get_Range("H7", "H7").Value2 = tblThongtinKH.Rows[0][3].ToString();
            exRange.get_Range("I7", "M7").Value2 = tblThongtinKH.Rows[0][4].ToString();
            exRange.get_Range("I7", "M7").MergeCells = true;
            exRange.get_Range("E8", "E8").Value2 = " Ngày khởi hành :";
            exRange.get_Range("E8", "E8").MergeCells = true;
            exRange.get_Range("H8", "J8").Value2 = tblThongtinKH.Rows[0][5].ToString();
            exRange.get_Range("H8", "J8").MergeCells = true;
            exRange.get_Range("E9", "E9").Value2 = " Đoàn :";
            exRange.get_Range("E9", "E9").MergeCells = true;
            exRange.get_Range("H9", "H9").Value2 = tblThongtinKH.Rows[0][6].ToString();
            exRange.get_Range("I9", "N9").Value2 = tblThongtinKH.Rows[0][7].ToString();
            exRange.get_Range("I9", "N9").MergeCells = true;
            //
            sql = "Select a.TenLoai from LOAIHINH$ a, TOUR$ b ,VETHAMQUAN$ c where c.STTVE=N'" + txtVe.Text +
                "' AND b.MATOUR=c.MATOUR AND a.MaLoai=b.MaLoai";
            tblLH = Functions.GetDataToTable(sql);
            exRange.get_Range("N7", "N7").Value2 = tblLH.Rows[0][0].ToString();
            exRange.get_Range("N7", "N7").MergeCells = true;
            //


            //
            exSheet.Name = "Vé tham  quan";
            exApp.Visible = true;

        }

     

       

    }
}

