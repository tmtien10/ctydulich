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
    public partial class DoanThamQuan : Form
    {
        DataTable tblDTQ,tblDS;
        public DoanThamQuan()
        {
            InitializeComponent();
        }

        private void DoanThamQuan_Load(object sender, EventArgs e)
        {
            string sql, sql1;
            sql = "Select MATOUR  from TOUR$";
            sql1 = "Select MaHDV from HUONGDANVIEN$";
            LoadDataGridViewDTQ();
            Functions.FillCombo(sql, comboTourTk, "MATOUR", "TENTOUR");
            Functions.FillCombo(sql, comboMaTour, "MATOUR", "TENTOUR");
            Functions.FillCombo(sql, comboMaTourIn, "MATOUR", "TENTOUR");
            Functions.FillCombo(sql1, comboHDV, "MaHDV", "TenHDV");
            //Functions.FillCombo(sql, comboMaTourIn, "MATOUR", "MATOUR");
            textBox1.Text = DateTime.Now.ToString();
            comboTourTk.SelectedIndex = -1;
            comboHDV.SelectedIndex = -1;
            comboMaTour.SelectedIndex = -1;
            comboMaTourIn.SelectedIndex = -1;
        }
        private void LoadDataGridViewDTQ()
        {

            string sql;
            sql = "Select * from DOANTHAMQUAN$";
            tblDTQ = Class.Functions.GetDataToTable(sql);
            dataGridViewDTQ.DataSource = tblDTQ;
            dataGridViewDTQ.Columns[0].HeaderText = "Mã đoàn";
            dataGridViewDTQ.Columns[1].HeaderText = "Tên đoàn";
            dataGridViewDTQ.Columns[2].HeaderText = "Mã tour";
            dataGridViewDTQ.Columns[3].HeaderText = "Hướng dẫn viên";
            dataGridViewDTQ.AllowUserToAddRows = false; //Không cho thêm dữ liệu trực tiếp
            dataGridViewDTQ.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

        }
        private void Reset_ValuesDTQ() //xóa dữ liệu trên ô textbox
        {
            txtMaDoan.Text = "";
            txtTenDoan.Text = "";
            comboHDV.Text = "";
            comboMaTour.Text = "";
            txtMaDoanTK.Text = "";
            comboTourTk.Text = "";
            txtMaDoanTK.Text = "";
            comboMaDoanIn.Text = "";
            comboMaTourIn.Text = "";
            comboMaHDVIn.Text = "";
        }


        private void dataGridViewDTQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDoan.Enabled = false;
            if (tblDTQ.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaDoan.Text = dataGridViewDTQ.CurrentRow.Cells["MaDoan"].Value.ToString();
            txtTenDoan.Text = dataGridViewDTQ.CurrentRow.Cells["TenDoan"].Value.ToString();
            comboHDV.Text = dataGridViewDTQ.CurrentRow.Cells["MaHDV"].Value.ToString();
            comboMaTour.Text = dataGridViewDTQ.CurrentRow.Cells["MATOUR"].Value.ToString();
        }

        private void bttTK_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaDoanTK.Text == "") && (comboTourTk.Text == "") && (txtHDVTK.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = " Select * from DOANTHAMQUAN$ where 1=1";
            if (txtMaDoanTK.Text != "")
                sql += " AND MaDoan LIKE N'%" + txtMaDoanTK.Text + "%'";
            if (comboTourTk.Text != "")
                sql += "AND MATOUR LIKE N'%" + comboTourTk.SelectedValue + "%'";
            if (txtHDVTK.Text != "")
                sql += "AND MaHDV LIKE N'%" + txtHDVTK.Text + "%'";
            tblDTQ = Class.Functions.GetDataToTable(sql);
            if (tblDTQ.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblDTQ.Rows.Count + " đoàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewDTQ.DataSource = tblDTQ;
            Reset_ValuesDTQ();
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaDoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã đoàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDoan.Focus();
                return;
            }
            if (txtTenDoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên đoàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDoan.Focus();
                return;
            }
            if (comboHDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn hướng dẫn viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboHDV.Focus();
                return;
            }
            if (comboMaTour.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboMaTour.Focus();
                return;
            }

            sql = "Select MaDoan from DOANTHAMQUAN$ where MaDoan=N'" + txtMaDoan.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Đoàn này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDoan.Focus();
                return;
            }
            sql = "INSERT INTO DOANTHAMQUAN$ VALUES(N'" +
               txtMaDoan.Text + "',N'" + txtTenDoan.Text + "',N'" + comboMaTour.SelectedValue.ToString() + "',N'" + comboHDV.SelectedValue.ToString() + "')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewDTQ(); //Nạp lại DataGridView
            Reset_ValuesDTQ();
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaDoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã đoàn ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDoan.Focus();
                return;
            }
            if (txtTenDoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên đoàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDoan.Focus();
                return;
            }
            if (comboHDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn hướng dẫn viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboHDV.Focus();
                return;
            }
            if (comboMaTour.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboMaTour.Focus();
                return;
            }
            sql = "Update DOANTHAMQUAN$ set  TenDoan='" + txtTenDoan.Text.ToString() + "',MATOUR=N'" + comboMaTour.SelectedValue.ToString() + "', MaHDV=N'" + comboHDV.SelectedValue.ToString() + "'  Where MaDoan=N'" + txtMaDoan.Text + "'";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridViewDTQ(); //Nạp lại DataGridView
            Reset_ValuesDTQ();
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {

            string sql;
            if (tblDTQ.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDoan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn đoàn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE DOANTHAMQUAN$ WHERE MaDoan=N'" + txtMaDoan.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridViewDTQ();
                Reset_ValuesDTQ();

            }




        }

        private void comboMaTourIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaDoan from DOANTHAMQUAN$  where MATOUR=N'" + comboMaTourIn.SelectedValue + "'";
            Functions.FillCombo(sql, comboMaDoanIn, "MaDoan", "MaDoan");
            sql = "SELECT MaHDV from DOANTHAMQUAN$ where MATOUR=N'" + comboMaTourIn.SelectedValue + "'";
            Functions.FillCombo(sql, comboMaHDVIn, "MaHDV", "MaHDV");
            comboMaDoanIn.SelectedIndex = -1;
            
        }
        private void LoadDataGridViewDSKH() {
            string sql;
            sql = "SELECT  a.MaKH, a.HoKH, a.TenKH FROM  KHACHHANG$ a ,VETHAMQUAN$ b, DOANTHAMQUAN$ c where a.MaKH = b.MaKH AND b.MaDoan = c.MaDoan AND c.MaDoan=N'" +
                comboMaDoanIn.SelectedValue + "'";
            tblDS = Class.Functions.GetDataToTable(sql);
            dataGridViewDS.DataSource = tblDS;
            dataGridViewDS.Columns[0].HeaderText = "Mã khách hàng";
            dataGridViewDS.Columns[1].HeaderText = "Họ khách hàng";
            dataGridViewDS.Columns[2].HeaderText = "Tên khách hàng";
            dataGridViewDS.AllowUserToAddRows = false; //Không cho thêm dữ liệu trực tiếp
            dataGridViewDS.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        
        
        }

        private void comboMaDoanIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridViewDSKH();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang, cot;
            DataTable tblDSI, tblTT, tblHDV ;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = (Microsoft.Office.Interop.Excel.Worksheet)exBook.Worksheets[1];
            //

            exRange = (Microsoft.Office.Interop.Excel.Range)exSheet.Cells[1, 1];
            exRange.get_Range("A1", "Z100").Font.Name = "Time New roman";//font chữ
            exRange.get_Range("C2", "I2").Font.Size = 18;
            exRange.get_Range("C2", "I2").Font.Bold = true;
            exRange.get_Range("C2", "I2").MergeCells = true;
            exRange.get_Range("C2", "I2").HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.get_Range("C2", "I2").Value2 = " DANH SÁCH KHÁCH THAM QUAN";
            exRange.get_Range("C2", "I2").MergeCells = true;
            exRange.get_Range("C4", "D4").Value2 = "Ngày khởi hành:";
            exRange.get_Range("C4", "D4").MergeCells = true;
            exRange.get_Range("E4", "F4").EntireColumn.NumberFormat = "MM/DD/YYYY";
            exRange.get_Range("E4", "F4").Value2 = textBox1.Text;
            exRange.get_Range("E4", "F4").MergeCells = true;
            //
            sql = "Select MaDoan,TenDoan from DOANTHAMQUAN$ where MaDoan='" + comboMaDoanIn.Text + "'";
            tblTT = Functions.GetDataToTable(sql);
            exRange.get_Range("C5", "D5").Value2 = "Đoàn";
            exRange.get_Range("C5", "D5").MergeCells = true;
            exRange.get_Range("E5", "F5").Value2 = tblTT.Rows[0][0].ToString();
            exRange.get_Range("E5", "F5").MergeCells = true;
            exRange.get_Range("G5", "K5").Value2 = tblTT.Rows[0][1].ToString();
            exRange.get_Range("G5", "K5").MergeCells = true;
            //
            sql = "Select HoHDV,TenHDV from HUONGDANVIEN$ where MaHDV='" + comboMaHDVIn.Text + "'";
            tblHDV = Functions.GetDataToTable(sql);
            exRange.get_Range("C6", "D6").Value2 = "Hướng dẫn viên";
            exRange.get_Range("C6", "D6").MergeCells = true;
            exRange.get_Range("E6", "E6").Value2 = tblHDV.Rows[0][0].ToString();
            exRange.get_Range("F6", "F6").Value2 = tblHDV.Rows[0][1].ToString();
           
            //Danh sách khách hàng
            sql = "SELECT  a.MaKH, a.HoKH, a.TenKH FROM  KHACHHANG$ a ,VETHAMQUAN$ b, DOANTHAMQUAN$ c where a.MaKH = b.MaKH AND b.MaDoan = c.MaDoan AND c.MaDoan=N'" +
                comboMaDoanIn.SelectedValue + "'";
            tblDSI = Class.Functions.GetDataToTable(sql);
            // Biểu diễn tiêu đề cột
            exRange.get_Range("C8","F8").Font.Bold = true;
            exRange.get_Range("C8","F8").HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            
            exRange.get_Range("C8","C8").Value2 = "STT";
            exRange.get_Range("D8", "D8").Value2 = "Mã KH";
            exRange.get_Range("E8", "E8").Value2 = "Họ";
            exRange.get_Range("F8", "F8").Value2 = "Tên";
            //
            for (hang = 0; hang < tblDSI.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 3 từ dòng 9
                exSheet.Cells[hang + 9,3] = hang + 1;
                for (cot = 0; cot < tblDSI.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 4, dòng 9
                {   
                    exSheet.Cells[hang + 9,cot + 4] = tblDSI.Rows[hang][cot].ToString();
                  
                }
            }
           
            exSheet.Name = "Danh sách tham  quan";
            exApp.Visible = true;
        }
    }
}