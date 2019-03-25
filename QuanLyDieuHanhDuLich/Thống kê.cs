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
    public partial class Thống_kê : Form
    {
        string DK;
        DataTable tbl;
        public Thống_kê()
        {
            InitializeComponent();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            DK = "A1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DK = "A2";
        }

        private void Thống_kê_Load(object sender, EventArgs e)
        {

        }

        private void bttTK_Click(object sender, EventArgs e)
        {
            string sql, sql1;
            if ((txtDay.Text == "") && (txtMonth.Text == "") && (txtYear.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DK == "A1")
            {
                sql = " SELECT COUNT(*) from DANGKI$ where NgayHuyDK IS NULL";
                //textBox1.Text = txtDay.Text;
                sql1 = "Select a.TENTOUR, COUNT(*)as SL from TOUR$ a INNER JOIN DANGKI$ b ON a.MATOUR = b.MATOUR where NgayHuyDK IS NULL";
                if (txtDay.Text!="")
                {
                    sql+= " AND DAY(NgayDK)= '" + txtDay.Text + "'";
                
                    sql1 += " AND DAY(b.NgayDK)= '" + txtDay.Text + "'";
                }
                if (txtMonth.Text!="")
                  
                { sql+= " AND MONTH(NgayDK)='" + txtMonth.Text + "'";
                    sql1 += " AND MONTH(b.NgayDK)='" + txtMonth.Text + "'";
                }
                if (txtYear.Text!= "")
                {
                    sql+= " AND YEAR(NgayDK)='" + txtYear.Text + "'";
                    sql1 += " AND YEAR(b.NgayDK)='" + txtYear.Text + "'";
                }
                sql1 += " GROUP BY a.TENTOUR ORDER BY SL DESC";
                txtTS.Text = Functions.GetFieldValues(sql);
                tbl = Functions.GetDataToTable(sql1);
                dataGridViewTK.DataSource = tbl;

            }

            if (DK == "A2")
            {
                sql = " SELECT COUNT(*) from PHIEUCHI$ where 1=1";
                sql1 = "Select a.TENTOUR, COUNT(*)as SL from TOUR$ a INNER JOIN PHIEUCHI$ b ON a.MATOUR = b.MATOUR where 1=1";
                if (txtDay.Text != "")
                {
                    sql += "AND DAY(NgayLap)='" + txtDay.Text + "'";
                    sql1 += "AND DAY(b.NgayLap)= '" + txtDay.Text + "'";
                }
                if (txtMonth.Text != "")
                {
                    sql += "AND MONTH(NgayLap)='" + txtMonth.Text + "'";
                    sql1 += "AND MONTH(b.NgayLap)='" + txtMonth.Text + "'";
                }
                if (txtYear.Text != "")
                {
                    sql += " AND YEAR(NgayLap)='" + txtYear.Text + "'";
                    sql1 += "AND YEAR(b.NgayLap)='" + txtYear.Text + "'";
                }
                sql1 += " GROUP BY a.TENTOUR ORDER BY SL DESC";
                txtTS.Text = Functions.GetFieldValues(sql);
                tbl = Functions.GetDataToTable(sql1);
                dataGridViewTK.DataSource = tbl;
            }

        }
    }
}
