using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDieuHanhDuLich.Class
{
    class Functions
    {
          
        public static SqlConnection Con;  //Khai báo đối tượng kết nối        

        public static void Connect()
        {
            Con = new SqlConnection();   //Khởi tạo đối tượng
            Con.ConnectionString = @"Data Source=TRANTIEN-PC\SQLEXPRESS;AttachDbFilename=D:\DemoQuanLyDieuHanhDuLich\QuanLyDieuHanhDuLich\dulieu.mdf;Integrated Security=True;User Instance=True";

            Con.Open();                  //Mở kết nối
            //Kiểm tra kết nối
            if (Con.State == ConnectionState.Open)
                MessageBox.Show("Đã kết nối với dữ liệu");
            else MessageBox.Show("Không thể kết nối với dữ liệu");

        }
         public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();   	//Đóng kết nối
                Con.Dispose(); 	//Giải phóng tài nguyên
                Con = null;
            }
        }

  
             //Lấy dữ liệu vào bảng
        public static DataTable GetDataToTable(string sql)
        {
            Con = new SqlConnection();   //Khởi tạo đối tượng
            Con.ConnectionString = @"Data Source=TRANTIEN-PC\SQLEXPRESS;AttachDbFilename=D:\code\demo\DemoQuanLyDieuHanhDuLich\QuanLyDieuHanhDuLich\dulieu.mdf;Integrated Security=True;User Instance=True";

            Con.Open();                  //Mở kết nối
            //Tạo đối tượng thuộc lớp SqlCommand
            SqlCommand sqlCmd = new SqlCommand(sql,Con);
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter MyData = new SqlDataAdapter(sqlCmd); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            MyData.Fill(table);
            Con.Close();  // đóng kết nối
         
            return table;
        }
        public static void RunSQL(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            SqlConnection cnn = new SqlConnection(@"Data Source=TRANTIEN-PC\SQLEXPRESS;AttachDbFilename=D:\code\demo\DemoQuanLyDieuHanhDuLich\QuanLyDieuHanhDuLich\dulieu.mdf;Integrated Security=True;User Instance=True";
            cnn.Open();
            cmd.Connection = cnn; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
            cnn.Close();
  
        }
        public static void RunSqlDel(string sql)
        {   SqlCommand cmd;
            cmd = new SqlCommand();
            SqlConnection cnn = new SqlConnection(@"Data Source=TRANTIEN-PC\SQLEXPRESS;AttachDbFilename=D:\code\demo\DemoQuanLyDieuHanhDuLich\QuanLyDieuHanhDuLich\dulieu.mdf;Integrated Security=True;User Instance=True";
            cnn.Open();
            cmd.Connection = cnn; //Gán kết nối
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Dữ liệu đang được dùng, không thể xoá...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
            cnn.Close();
        }
        
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            Con = new SqlConnection();   //Khởi tạo đối tượng
            Con.ConnectionString = @"Data Source=TRANTIEN-PC\SQLEXPRESS;AttachDbFilename=D:\code\demo\DemoQuanLyDieuHanhDuLich\QuanLyDieuHanhDuLich\dulieu.mdf;Integrated Security=True;User Instance=True";

            Con.Open();                  //Mở kết nối
            //Tạo đối tượng thuộc lớp SqlCommand
            SqlCommand sqlCmd = new SqlCommand(sql, Con);
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten;//Trường hiển thị
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }

        public static string GetFieldValues(string sql)// nhận giá trị từ câu sql
        {
            Con = new SqlConnection();   //Khởi tạo đối tượng
            Con.ConnectionString = @"Data Source=TRANTIEN-PC\SQLEXPRESS;AttachDbFilename=D:\code\demo\DemoQuanLyDieuHanhDuLich\QuanLyDieuHanhDuLich\dulieu.mdf;Integrated Security=True;User Instance=True";

            Con.Open();
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
          
            reader.Close();
            return ma;
        }
        


    }
    }

