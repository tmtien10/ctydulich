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
    public partial class Chi_tiet_hoa_don : Form
    {
        DataTable tblHD;
        public Chi_tiet_hoa_don()
        {
            InitializeComponent();
        }

        private static string creakeyDK()
        {
            int i;
            string ma, sql;

            sql = "SELECT TOP (1) SoHD FROM HOADON$ ORDER BY SoHD DESC";
            ma = Functions.GetFieldValues(sql);
            if (ma !="")
            {
                i = int.Parse(ma);
                i += 1;
            }
            else i = 1;
            ma = Convert.ToString(i);
            return ma;
        }

        private void Chi_tiet_hoa_don_Load(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaKH, TenKH FROM KHACHHANG$", comboMaKH, "MaKH", "MaKH");
            comboMaKH.SelectedIndex = -1;
            Functions.FillCombo("SELECT MSNV  from NHANVIEN$", comboNVT, "MSNV", "MSNV");
            comboNVT.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaKT  from KETOAN$", comboKT, "MaKT", "MaKT");
            comboKT.SelectedIndex = -1;
            Functions.FillCombo("SELECT MATOUR FROM TOUR$", comboMaTour, "MATOUR", "MATOUR");
            comboMaTour.SelectedIndex = -1;
            //Từ form danh mục
            if (txtSoHD.Text != "")
            {
                txtSoHD.Enabled = false;
                comboMaKH.Enabled = false;
                comboMaTour.Enabled = false;
                bttThem.Enabled = false;
                comboKT.Enabled = false;
                comboNVT.Enabled = false;
                LoadInforDK();
            }
        }
        private void LoadInforDK()
        {
            string sql;
            txtSoHD.Enabled = false;
            sql = "select MaKH from HOADON$ where SoHD=N'" + txtSoHD.Text + "'";
            comboMaKH.SelectedValue = Functions.GetFieldValues(sql);
            sql = "select MATOUR from HOADON$ where SoHD=N'" + txtSoHD.Text + "'";
            comboMaTour.Text = Functions.GetFieldValues(sql);
            sql = "select MSNV from HOADON$ where SoHD=N'" + txtSoHD.Text + "'";
            comboNVT.Text = Functions.GetFieldValues(sql);
            sql = "select MaKT from HOADON$ where SoHD=N'" + txtSoHD.Text + "'";
            comboKT.Text = Functions.GetFieldValues(sql);
            sql = "Select NgayLap from HOADON$ where SoHD=N'" + txtSoHD.Text + "'";
            txtNgayLapHD.Text = Functions.GetFieldValues(sql);
            

        }
        private void Reset_ValuesDK()
        {
            comboMaKH.Text = "";
            txtHoKH.Text = "";
            txtTenKH.Text = "";
            txtSoHD.Text = "";
            txtNgayKH.Text = "";
            txtSDT.Text = "";
            comboNVT.Text = "";
            comboKT.Text = "";
            comboMaTour.Text = "";
            txtMaTuyen.Text = "";
            txtNgayKH.Text = "";
            txtLH.Text = "";
            txtMaTuyen.Text = "";
            txtNgayLapHD.Text = "";
            txtDC.Text = "";
            txtTT.Text = "";


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

                txtMaTuyen.Text = "";
                txtNgayKH.Text = "";
                txtLH.Text = "";
            }

            sql = "SELECT MaTuyen from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            txtMaTuyen.Text = Functions.GetFieldValues(sql);
            sql = "SELECT NGAYKH from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            txtNgayKH.Text = Functions.GetFieldValues(sql);
            sql = "SELECT MaLoai from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            txtLH.Text = Functions.GetFieldValues(sql);
            sql = "SELECT CPTOUR from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";
            txtDonGia.Text = Functions.GetFieldValues(sql);
            txtTT.Text = txtDonGia.Text;
            LoadDataGridViewTour();
        }
        private void LoadDataGridViewTour()
        {
            string sql;
            sql = "select MATOUR, TENTOUR, MaTuyen, MaLoai, CPTOUR, MaPhuongTien, NGAYKH from TOUR$ where MATOUR=N'" + comboMaTour.SelectedValue + "'";

            tblHD = Functions.GetDataToTable(sql);
            dataGridViewHD.DataSource = tblHD;
            dataGridViewHD.Columns[0].HeaderText = "Mã tour";
            dataGridViewHD.Columns[1].HeaderText = "Tên tour";
            dataGridViewHD.Columns[2].HeaderText = "Mã tuyến";
            dataGridViewHD.Columns[3].HeaderText = "Mã loại hình";
            dataGridViewHD.Columns[4].HeaderText = "Chi phí";
            dataGridViewHD.Columns[5].HeaderText = "Mã phương tiện";
            dataGridViewHD.Columns[6].HeaderText = "Ngày khởi hành";
            dataGridViewHD.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dataGridViewHD.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp



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
            txtNgayLapHD.Text = DateTime.Now.ToString();
            txtSoHD.Text = creakeyDK();

            sql = "INSERT INTO HOADON$ (SoHD,MSNV,MaKT,MaKH,MATOUR,NgayLap) values(" + txtSoHD.Text + ", N'" + comboNVT.SelectedValue + "',N'" +
                comboKT.SelectedValue + "',N'" + comboMaKH.SelectedValue + "',N'" + comboMaTour.SelectedValue + "','" + txtNgayLapHD.Text + "')";
            Functions.RunSQL(sql);
            HoaDon hd = new HoaDon();
            hd.LoadDataGridViewHD();
            hd.StartPosition = FormStartPosition.CenterParent;
            hd.ShowDialog();
            Reset_ValuesDK();
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            string sql;


            if (txtSoHD.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM HOADON$ WHERE SoHD=N'" + txtSoHD.Text + "'";
                Functions.RunSqlDel(sql);

                HoaDon hd = new HoaDon();
                hd.LoadDataGridViewHD();
                hd.StartPosition = FormStartPosition.CenterParent;
                hd.ShowDialog();
                Reset_ValuesDK();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttIn_Click(object sender, EventArgs e)
        {

            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            string NV, KT;
            DataTable  tblTTT;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = (Microsoft.Office.Interop.Excel.Worksheet)exBook.Worksheets[1];
            //

            exRange = (Microsoft.Office.Interop.Excel.Range)exSheet.Cells[1, 1];
            exRange.get_Range("A1", "Z100").Font.Name = "Time New roman";//font chữ
            exRange.get_Range("A1", "A1").ColumnWidth = 18;
            exRange.get_Range("B1", "B1").ColumnWidth = 24.57;
            exRange.get_Range("C1", "C1").ColumnWidth = 14;
            exRange.get_Range("D1", "D1").ColumnWidth = 15.5;
            exRange.get_Range("B2", "B2").Font.Size = 18;
            exRange.get_Range("B2", "B2").Font.Bold = true;
            exRange.get_Range("B2", "B2").MergeCells = true;
            exRange.get_Range("B2", "B2").HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.get_Range("B2", "B2").Value2 = " HÓA ĐƠN SỐ";
            exRange.get_Range("B2", "B2").MergeCells = true;
            exRange.get_Range("C2", "C2").Value2 = txtSoHD.Text;
            exRange.get_Range("C4", "D4").MergeCells = true;
            exRange.get_Range("B3", "B3").Value2 = "Ngày lập";
            exRange.get_Range("C3", "C3").EntireRow.NumberFormat = "MM/DD/YYYY";
            exRange.get_Range("C3", "C3").Value2 = txtNgayLapHD.Text;
            exRange.get_Range("E4", "F4").MergeCells = true;
            //Thông tin khách 
            exRange.get_Range("A5", "A5").Value2 = " Mã số khách hàng";
            exRange.get_Range("A5", "A5").MergeCells = true;
            exRange.get_Range("B5", "B5").Value2 = comboMaKH.Text;
            exRange.get_Range("A6", "A6").Value2 = " Họ khách hàng";
            exRange.get_Range("A6", "A6").MergeCells = true;
            exRange.get_Range("B6", "B6").Value2 = txtHoKH.Text;
            exRange.get_Range("A7", "A7").Value2 = " Tên khách hàng";
            exRange.get_Range("A7", "A7").MergeCells = true;
            exRange.get_Range("B7", "B7").Value2 = txtTenKH.Text;
            exRange.get_Range("A8", "A8").Value2 = " Địa chỉ liên lạc ";
            exRange.get_Range("A8", "A8").MergeCells = true;
            exRange.get_Range("B8", "B8").Value2 = txtDC.Text;
            exRange.get_Range("A9", "A9").Value2 = " Số điện thoại ";
            exRange.get_Range("A9", "A9").MergeCells = true;
            exRange.get_Range("B9", "B9").Value2 = txtSDT.Text;
          
            //Thông tin tour
            exRange.get_Range("A11", "A11").Value2 = " Tour ";
            exRange.get_Range("A11", "A11").MergeCells = true;
            exRange.get_Range("A12", "A12").Value2 = comboMaTour.Text;
            exRange.get_Range("B11", "B11").Value2 = " Tuyến ";
            exRange.get_Range("B11", "B11").MergeCells = true;
            exRange.get_Range("C11", "C11").Value2 = " Loại hình ";
            exRange.get_Range("C11", "C11").MergeCells = true;
            exRange.get_Range("D11", "D11").Value2 = " Ngày khởi hành ";
            exRange.get_Range("D11", "D11").MergeCells = true;
            exRange.get_Range("D12", "D12").EntireColumn.NumberFormat = "M/D/YYYY HH:MM";
            exRange.get_Range("D12", "D12").Value2 = txtNgayKH.Text;
            exRange.get_Range("E11", "E11").Value2 = " Giá tiền ";
            exRange.get_Range("E11", "E11").MergeCells = true;
            exRange.get_Range("E12", "E12").Value2 = txtTT.Text;

            sql = "Select a.TenTuyen,b.TenLoai from TUYEN$ a, LOAIHINH$ b where a.MaTuyen=N'" + txtMaTuyen.Text + "' AND b.MaLoai=N'" + txtLH.Text + "'";
            tblTTT = Functions.GetDataToTable(sql);
            exRange.get_Range("B12", "B12").Value2 = tblTTT.Rows[0][0].ToString();
            exRange.get_Range("B12", "B12").MergeCells = true;
            exRange.get_Range("C12", "C12").Value2 = tblTTT.Rows[0][1].ToString();
            exRange.get_Range("C12", "C12").MergeCells = true;
            exRange.get_Range("D13", "D13").MergeCells = true;
            exRange.get_Range("D13", "D13").Value2 = "Tổng tiền";
            exRange.get_Range("E13", "E13").MergeCells = true;
            exRange.get_Range("E13", "E13").Value2 = txtTT.Text;
            //
            exRange.get_Range("A15", "A15").Value2 = "Nhân viên điều hành";
            exRange.get_Range("A15", "A15").MergeCells = true;
            sql = "Select TenNV from NHANVIEN$ where MSNV=N'" + comboNVT.Text + "'";
            NV = Functions.GetFieldValues(sql);
            exRange.get_Range("A16", "A16").Value2 = NV;
            exRange.get_Range("B15", "B15").Value2 = "Kế toán";
            exRange.get_Range("B15", "B15").MergeCells = true;
            sql = "Select HoTenKT from KETOAN$ where MaKT=N'" + comboKT.Text + "'";
            KT = Functions.GetFieldValues(sql);
            exRange.get_Range("B16", "B16").Value2 = KT;
            exRange.get_Range("C15", "C15").Value2 = "Khách hàng";
            exRange.get_Range("C15", "C15").MergeCells = true;
            exRange.get_Range("C16", "C16").Value2 = txtHoKH.Text;
            exRange.get_Range("D16", "D16").Value2 = txtTenKH.Text;


            //
            exSheet.Name = "Hóa đơn";
            exApp.Visible = true;
        }

       
    }
}
