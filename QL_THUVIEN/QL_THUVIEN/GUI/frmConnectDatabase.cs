using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QL_THUVIEN.GUI
{
    public partial class frmConnectDatabase : Form
    {
        public frmConnectDatabase()
        {
            InitializeComponent();
        }

        private void frmConnectDatabase_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Enabled = false;
            txtMK.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbxChonTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChonTaiKhoan.SelectedIndex == 0)
            {
                CONNECT.ConnectString.WinAuthentication = true;
                txtTenDangNhap.Enabled = false;
                txtMK.Enabled = false;
            }
            if (cbxChonTaiKhoan.SelectedIndex == 1)
            {
                CONNECT.ConnectString.WinAuthentication = false;
                txtTenDangNhap.Enabled = true;
                txtMK.Enabled = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenMayChu.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập tên máy chủ!");
                    ActiveControl = txtTenMayChu;
                    return;
                }
                else if (txtTenCSDL.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập tên CSDL!");
                    ActiveControl = txtTenCSDL;
                    return;
                }

                CONNECT.ConnectString.ServerName = txtTenMayChu.Text.Trim();
                CONNECT.ConnectString.DatabaseName = txtTenCSDL.Text.Trim();

                if (cbxChonTaiKhoan.SelectedIndex == 0)
                {
                    CONNECT.ConnectString.WinAuthentication = true;
                    CONNECT.ConnectString.TaoChuoiKetNoi();
                }
                else
                {
                    CONNECT.ConnectString.WinAuthentication = false;
                    CONNECT.ConnectString.TaoChuoiKetNoi();
                }


                CONNECT.Connect.myconnect = new SqlConnection(CONNECT.ConnectString.StringConnect);
                CONNECT.Connect.openConnect();

                if (CONNECT.Connect.myconnect.State == ConnectionState.Open)
                {
                    MessageBox.Show("Bạn đã kết nối thành công đến cơ sở dữ liệu " + txtTenCSDL.Text);
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Không kết nối được đến cơ sở dữ liệu!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTenCSDL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
