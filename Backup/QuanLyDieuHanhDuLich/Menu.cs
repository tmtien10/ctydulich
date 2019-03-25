using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDieuHanhDuLich
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Tour t = new Tour();
            t.ShowDialog();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Tuyen tuyen = new Tuyen();
            tuyen.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Danh_mục_phiếu_đăng_kí dk = new Danh_mục_phiếu_đăng_kí();
            dk.ShowDialog();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.ShowDialog();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Phieuchi pc = new Phieuchi();
            pc.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Tour t = new Tour();
            t.ShowDialog();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Tuyen tuyen = new Tuyen();
            tuyen.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            LoaiHinhPhuongTien pt = new LoaiHinhPhuongTien();
            pt.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DoanThamQuan dtq = new DoanThamQuan();
            dtq.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.ShowDialog();

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            KeToancs kt = new KeToancs();
            kt.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            HuongDanVien hdv = new HuongDanVien();
            hdv.ShowDialog();
        }

        private void thốngKêToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Thống_kê tk = new Thống_kê();
            tk.ShowDialog();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void véThamQuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSdvetq ve = new DSdvetq();
            ve.ShowDialog();
        }

       
       

        
        

        
        
        
     

       
    }
}
