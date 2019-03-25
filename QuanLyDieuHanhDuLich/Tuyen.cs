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
    public partial class Tuyen : Form
    {
        DataTable tblTuyen;
        public Tuyen()
        {
            InitializeComponent();
        }

        private void Tuyen_Load(object sender, EventArgs e)
        {
            string sql, sql1;

            sql = " Select MATINH, TENTINH from TINH$ ";
            sql1 = " Select MaLoai , TenLoai from LOAIHINH$";
            LoadDataGridViewTuyen();
            Functions.FillCombo(sql, comboTinh1, "MATINH", "TENTINH");
            Functions.FillCombo(sql, comboTinh2, "MATINH", "TENTINH");
            Functions.FillCombo(sql, comboTinhKH, "MATINH", "TENTINH");
            Functions.FillCombo(sql, comboTinhDD, "MATINH", "TENTINH");
            Functions.FillCombo(sql, comboTinhKT, "MATINH", "TENTINH");
            Functions.FillCombo(sql1, comboLH, "MaLoai", "TenLoai");
            comboTinh1.SelectedIndex = -1;
            comboTinh2.SelectedIndex = -1;
            comboTinhKH.SelectedIndex = -1;
            comboTinhDD.SelectedIndex = -1;
            comboTinhKT.SelectedIndex = -1;
            comboLH.SelectedIndex = -1;
        }
        private void LoadDataGridViewTuyen()
        {


            string sql;
            sql = "Select * from TUYEN$";
            tblTuyen = Class.Functions.GetDataToTable(sql);
            dataGridViewTuyen.DataSource = tblTuyen;
            dataGridViewTuyen.Columns[0].HeaderText = "Mã tuyến";
            dataGridViewTuyen.Columns[1].HeaderText = "Tên tuyến";
            dataGridViewTuyen.AllowUserToAddRows = false; //Không cho thêm dữ liệu trực tiếp
            dataGridViewTuyen.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void Reset_ValuesTuyen()
        {
            txtMaTuyenTK.Text = "";
            comboTinh1.Text = "";
            comboTinh2.Text = "";
            txtMaTuyen.Text = "";
            txtTentuyen.Text = "";
            comboTinhKH.Text = "";
            comboTinhDD.Text = "";
            comboTinhKT.Text = "";
            comboLH.Text = "";

        }

        private void bttTim2_Click(object sender, EventArgs e)
        {
            string sql;
            if ((comboTinh1.Text == "") && (comboTinh2.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT  b.MaTuyen ,b.TenTuyen FROM DIQUA$ AS a INNER JOIN TUYEN$ AS b ON a.MaTuyen = b.MaTuyen where a.MATINH like N'%" + comboTinh1.SelectedValue + "%'";
            if (comboTinh2.Text != "")
            {
                sql += "INTERSECT SELECT  b.MaTuyen ,b.TenTuyen FROM DIQUA$ AS a INNER JOIN TUYEN$ AS b ON a.MaTuyen = b.MaTuyen where a.MATINH like N'%" + comboTinh2.SelectedValue + "%'";
            }
                tblTuyen = Class.Functions.GetDataToTable(sql);
                if (tblTuyen.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Đã tìm thấy " + tblTuyen.Rows.Count + " tuyến !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewTuyen.DataSource = tblTuyen;
                Reset_ValuesTuyen();
            }
        

        private void dataGridViewTuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql, sql1, sql2, sql3;

            txtMaTuyen.Enabled = false;
            if (tblTuyen.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaTuyen.Text = dataGridViewTuyen.CurrentRow.Cells["MaTuyen"].Value.ToString();
            
            txtTentuyen.Text = dataGridViewTuyen.CurrentRow.Cells["TenTuyen"].Value.ToString();

            sql = "Select b.TENTINH from DIQUA$ a, TINH$ b where a.MATINH=b.MATINH and  a.IDTuyen='1' AND a.MaTuyen=N'" + txtMaTuyen.Text + "'";
            comboTinhKH.Text = Functions.GetFieldValues(sql);

            sql1 = "Select b.TENTINH from DIQUA$ a, TINH$ b where a.MATINH=b.MATINH and  a.IDTuyen='2' AND a.MaTuyen=N'" + txtMaTuyen.Text + "'";
            comboTinhDD.Text = Functions.GetFieldValues(sql1);

            sql2 = "Select b.TENTINH from DIQUA$ a, TINH$ b where a.MATINH=b.MATINH and  a.IDTuyen='3' AND a.MaTuyen=N'" + txtMaTuyen.Text + "'";
            comboTinhKT.Text = Functions.GetFieldValues(sql2);

            sql3 = "Select b.TenLoai from COTUYEN$ AS a INNER JOIN LOAIHINH$ AS b ON a.MaLoai = b.MaLoai where  a.MaTuyen=N'" + txtMaTuyen.Text + "'";
            //comboLH.Text = Functions.GetFieldValues(sql3);
            Functions.FillCombo(sql3, comboLH, "MaLoai", "TenLoai");
        }

        private void bttTim1_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaTuyenTK.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = " Select * from TUYEN$ where 1=1";
            if (txtMaTuyenTK.Text != "")
                sql += " AND MaTuyen LIKE N'%" + txtMaTuyenTK.Text + "%'";
            tblTuyen = Class.Functions.GetDataToTable(sql);
            if (tblTuyen.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Đã tìm thấy " + tblTuyen.Rows.Count + " đoàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewTuyen.DataSource = tblTuyen;
            Reset_ValuesTuyen();
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            string sql, sql1, sql2,sql3, sql4;
            if (txtMaTuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã tuyến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTuyen.Focus();
                return;
            }
            if (txtTentuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên đoàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTentuyen.Focus();
                return;
            }
            if (comboTinhKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn điểm khởi hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboTinhKH.Focus();
                return;
            }
           

            sql = "Select MaTuyen from TUYEN$ where MaTuyen=N'" + txtMaTuyen.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Tuyến này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTuyen.Focus();
                return;
            }
            sql = "INSERT INTO TUYEN$ VALUES(N'" +
               txtMaTuyen.Text + "',N'" + txtTentuyen.Text + "')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            sql1 = " INSERT INTO DIQUA$ VALUES(N'" + txtMaTuyen.Text + "', N'" + comboTinhKH.SelectedValue.ToString() + "','1')";
            Functions.RunSQL(sql1);
            if ((comboTinhDD.Text != ""))
            {
                sql2 = " INSERT INTO DIQUA$ VALUES(N'" + txtMaTuyen.Text + "', N'" + comboTinhDD.SelectedValue.ToString() + "','2')";
                Functions.RunSQL(sql2);
            }
            sql3 = "INSERT INTO DIQUA$ VALUES(N'" + txtMaTuyen.Text + "', N'" + comboTinhKT.SelectedValue.ToString() + "', '3')";
            Functions.RunSQL(sql3);
            sql4 = "INSERT INTO COTUYEN$ VALUES(N'" + txtMaTuyen.Text + "', N'" + comboLH.SelectedValue.ToString() + "')";
            Functions.RunSQL(sql4);
            LoadDataGridViewTuyen(); //Nạp lại DataGridView
            Reset_ValuesTuyen();
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sql, sql1, sql2, sql3, sql4;
            if (txtMaTuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã tuyến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTuyen.Focus();
                return;
            }
            if (txtTentuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên đoàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTentuyen.Focus();
                return;
            }
            if (comboTinhKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn điểm khởi hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboTinhKH.Focus();
                return;
            }
            sql = "UPDATE TUYEN$ set TenTuyen=N'" + txtTentuyen.Text + "' Where MaTuyen=N'" + txtMaTuyen.Text + "'";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            sql1 = "DELETE from DIQUA$ where MaTuyen=N'" + txtMaTuyen.Text + "'";
            Functions.RunSqlDel(sql1);
            sql1 = " INSERT INTO DIQUA$ VALUES(N'" + txtMaTuyen.Text + "', N'" + comboTinhKH.SelectedValue.ToString() + "','1')";
            Functions.RunSQL(sql1);
            if ((comboTinhDD.Text != ""))
            {
                sql2 = " INSERT INTO DIQUA$ VALUES(N'" + txtMaTuyen.Text + "', N'" + comboTinhDD.SelectedValue.ToString() + "','2')";
                Functions.RunSQL(sql2);
            }
            sql3 = "INSERT INTO DIQUA$ VALUES(N'" + txtMaTuyen.Text + "', N'" + comboTinhKT.SelectedValue.ToString() + "', '3')";
            Functions.RunSQL(sql3);
            sql = "Select MaLoai from COTUYEN$ where MaTuyen=N'" + txtMaTuyen.Text.Trim() + "' AND MaLoai=N'"+comboLH.SelectedValue.ToString()+"'";
            if (Class.Functions.CheckKey(sql) == false)
            {
                sql4 = "INSERT INTO COTUYEN$ VALUES(N'" + txtMaTuyen.Text + "', N'" + comboLH.SelectedValue.ToString() + "')";
                Functions.RunSQL(sql4);
            }
          
            LoadDataGridViewTuyen(); //Nạp lại DataGridView
            Reset_ValuesTuyen();
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            
            string sql;
            if (tblTuyen.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTuyen.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn đoàn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE COTUYEN$ WHERE MaTuyen=N'" + txtMaTuyen.Text + "'";
                
                Functions.RunSqlDel(sql);
                sql="DELETE DIQUA$ WHERE MaTuyen=N'" + txtMaTuyen.Text + "'";
                Functions.RunSqlDel(sql);
                sql = "DELETE TUYEN$ WHERE MaTuyen=N'" + txtMaTuyen.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridViewTuyen();

                Reset_ValuesTuyen();
            }
        }

        private void comboTinhKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void hidden_txtMaTuyen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}