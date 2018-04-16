﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QL_ThuVien.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            GUI.Intro it = new Intro();
            it.MdiParent = this;
            it.WindowState = FormWindowState.Maximized;
            it.Show();

            lblTen.Text = "Chào bạn: " +DTO.ConnectDatabase.NameLogin;
        }

        private void btnDauSach_Click(object sender, EventArgs e)
        {
            GUI.frmDauSach ds = new frmDauSach();
            ds.MdiParent = this;
            ds.WindowState = FormWindowState.Maximized;
            ds.Show();
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            GUI.frmDocGia dg = new frmDocGia();
            dg.MdiParent = this;
            dg.WindowState = FormWindowState.Maximized;
            dg.Show();
        }

        private void btnMuonTra_Click(object sender, EventArgs e)
        {
          
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.Intro it = new Intro();
            it.MdiParent = this;
            it.WindowState = FormWindowState.Maximized;
            it.Show();
        }

        private void btnXoaThongTin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa thông tin tài khoản đã lưu? \nBạn sẽ phải thiết đặt lại thông tin trong lần đăng nhập tới!", "Xóa thông tin đã lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                File.Delete("config");
                File.Delete("info.ini");
                MessageBox.Show("Đã xóa thông tin tài khoản!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
    }
}
