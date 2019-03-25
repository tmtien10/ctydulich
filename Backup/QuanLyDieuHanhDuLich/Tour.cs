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
    public partial class Tour : Form
    {
        DataTable tblTour;
        public Tour()
        {
            InitializeComponent();
        }

        private void Tour_Load(object sender, EventArgs e)
        {
            string sql, sql1, sql2;
            sql = " Select MaTuyen, TenTuyen from TUYEN$";
            sql1 = "Select MaLoai, TenLoai from LOAIHINH$";
            sql2 = " select MaPhuongTien, TenPhuongTien from PHUONGTIEN$";
            Functions.FillCombo(sql, comboTuyenTK, "MaTuyen", "TenTuyen");
            Functions.FillCombo(sql1, comboLoaiHinhTK, "MaLoai", "TenLoai");
            Functions.FillCombo(sql, comboTuyen, "MaTuyen", "TenTuyen");
            Functions.FillCombo(sql1, comboLH, "MaLoai", "TenLoai");
            Functions.FillCombo(sql2, comboPT, "MaPhuongTien", "TenPhuongTien");
            
            LoadDataGridViewTour();
            comboTuyenTK.SelectedIndex = -1;
            comboLoaiHinhTK.SelectedIndex = -1;
            comboTuyen.SelectedIndex = -1;
            comboLH.SelectedIndex = -1;
            comboPT.SelectedIndex = -1;
        }

        private void LoadDataGridViewTour()
        {
            string sql;
            sql = "SElect * from TOUR$";
           
            tblTour = Functions.GetDataToTable(sql);
            dataGridViewTour.DataSource = tblTour;
            dataGridViewTour.Columns[0].HeaderText = "Mã tour";
            dataGridViewTour.Columns[1].HeaderText = "Tên tour";
            dataGridViewTour.Columns[2].HeaderText = "Tuyến";
            dataGridViewTour.Columns[3].HeaderText = "Loại hình";
            dataGridViewTour.Columns[4].HeaderText = "Chi phí";
            dataGridViewTour.Columns[5].HeaderText = "Phương tiện";
            dataGridViewTour.Columns[6].HeaderText = "Ngày khởi hành";
            dataGridViewTour.AllowUserToAddRows = false; //Không cho thêm dữ liệu trực tiếp
            dataGridViewTour.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp



        }

        private void dataGridViewTour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string matuyen, maloaihinh, phuongtien;
            string sql;

            if (tblTour.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaTour.Text = dataGridViewTour.CurrentRow.Cells["MATOUR"].Value.ToString();
            txtTenTour.Text = dataGridViewTour.CurrentRow.Cells["TENTOUR"].Value.ToString();
            matuyen = dataGridViewTour.CurrentRow.Cells["MaTuyen"].Value.ToString();
            sql = " Select TenTuyen from TUYEN$ where MaTuyen=N'" + matuyen + "'";
            comboTuyen.Text = Functions.GetFieldValues(sql);
            maloaihinh = dataGridViewTour.CurrentRow.Cells["MaLoai"].Value.ToString();
            sql = " select TenLoai from LOAIHINH$ where MaLoai=N'" + maloaihinh + "'";
            comboLH.Text = Functions.GetFieldValues(sql);
            txtChiPhi.Text = dataGridViewTour.CurrentRow.Cells["CPTOUR"].Value.ToString();
            phuongtien = dataGridViewTour.CurrentRow.Cells["MaPhuongTien"].Value.ToString();
            sql = "Select TenPhuongTien from PHUONGTIEN$ where MaPhuongTien=N'" + phuongtien + "'";
            comboPT.Text = Functions.GetFieldValues(sql);
            txtNgayKH.Text = dataGridViewTour.CurrentRow.Cells["NGAYKH"].Value.ToString();
            txtMaTour.Enabled = false;

        }
        private void Reset_ValuesTour()
        {

            txtMaTour.Text = "";
            txtTenTour.Text = "";
            comboTuyen.Text = "";
            comboLH.Text = "";
            txtChiPhi.Text = "0";
            comboPT.Text = "";
            txtNgayKH.Text = "";
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaTour.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTour.Focus();
                return;
            }
            if (txtTenTour.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTour.Focus();
                return;
            }
            if (comboTuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tuyến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboTuyen.Focus();
                return;
            }
            if (comboLH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboLH.Focus();
                return;
            }
            if (txtChiPhi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chi phí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChiPhi.Focus();
                return;
            }
            if (comboPT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboPT.Focus();
                return;
            }
            if (txtNgayKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày khởi hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChiPhi.Focus();
                return;
            }
            sql = "SELECT MATOUR FROM TOUR$ WHERE MATOUR=N'" + txtMaTour.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Tour này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTour.Focus();
                return;
            }
            sql = "INSERT INTO TOUR$(MATOUR,TENTOUR,MaTuyen,MaLoai,CPTOUR, MaPhuongTien,NGAYKH) VALUES(N'"
                + txtMaTour.Text.Trim() + "',N'" + txtTenTour.Text.Trim() +
                "',N'" + comboTuyen.SelectedValue.ToString() +
                "',N'" + comboLH.SelectedValue.ToString() + "', " + txtChiPhi.Text + ",N'" + comboPT.SelectedValue.ToString() + "','" + txtNgayKH.Text + "')";

            Functions.RunSQL(sql);
            LoadDataGridViewTour();
            Reset_ValuesTour();
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTour.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTour.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTour.Focus();
                return;
            }
            if (txtTenTour.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTour.Focus();
                return;
            }
            if (comboTuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tuyến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboTuyen.Focus();
                return;
            }
            if (comboLH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboLH.Focus();
                return;
            }
            if (txtChiPhi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chi phí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChiPhi.Focus();
                return;
            }
            if (comboPT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboPT.Focus();
                return;
            }
            if (txtNgayKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày khởi hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChiPhi.Focus();
                return;
            }
            sql = "UPDATE TOUR$ SET TENTOUR=N'" + txtTenTour.Text.Trim().ToString() + "',MaTuyen=N'" + comboTuyen.SelectedValue.ToString() + "', MaLoai=N'" + comboLH.SelectedValue.ToString() +
                "',CPTOUR= " + txtChiPhi.Text + ",MaPhuongTien=N'" + comboPT.SelectedValue.ToString() + "',NGAYKH= '" + txtNgayKH.Text + "' WHERE MATOUR=N'" + txtMaTour.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridViewTour();
            Reset_ValuesTour();

        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTour.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTour.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tour nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE TOUR$ WHERE MATOUR=N'" + txtMaTour.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridViewTour();
                Reset_ValuesTour();
            }
        }

        private void buttTim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaTourTK.Text == "") && (comboTuyenTK.Text == "") && (comboLoaiHinhTK.Text == "") && (txtchiphitk.Text == "") && (txtday.Text == "")&&(txtmonth.Text=="")&&(txtyear.Text==""))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = " Select * from TOUR$ where 1=1";
            if (txtMaTourTK.Text != "")
                sql += " AND MATOUR LIKE N'%" + txtMaTourTK.Text + "%'";
            if (comboTuyenTK.Text != "")
                sql += " AND MaTuyen LIKE N'%" + comboTuyenTK.SelectedValue + "%'";
            if (comboLoaiHinhTK.Text != "")
                sql += "AND MaLoai LIKE N'%" + comboLoaiHinhTK.SelectedValue + "%'";
            if (txtchiphitk.Text != "")
                sql += "AND CPTOUR <= " +txtchiphitk.Text+ "";
            if (txtday.Text!="")
                sql += "AND DAY(NGAYKH) <='" + txtday.Text + "'";
            if(txtmonth.Text!="")
                sql+="AND MONTH(NGAYKH)='" +txtmonth.Text+"'";
            if (txtyear.Text != "")
                sql += "AND YEAR(NGAYKH)='" + txtyear.Text + "'";
             tblTour = Class.Functions.GetDataToTable(sql);
            if (tblTour.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblTour.Rows.Count + " tour!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewTour.DataSource = tblTour;
            Reset_ValuesTour();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        }

    }

