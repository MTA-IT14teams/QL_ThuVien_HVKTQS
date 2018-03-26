using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;


namespace QL_THUVIEN.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void KiemTra()
        {
            //MessageBox.Show("test");
            try
            {
                if (txtUsername.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập tên đăng nhập!");
                    ActiveControl = txtUsername;
                    return;
                }
                if (txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập mật khẩu!");
                    ActiveControl = txtPassword;
                    return;
                }

                SqlConnection conn = new SqlConnection(CONNECT.ConnectString.StringConnect);
                conn.Open();
                string sql = "select *from tblUser where Username = '" + txtUsername.Text.Trim() + "' and  Password = '" + txtPassword.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();

                if (dta.Read() == true)
                {
                    frmMain m = new frmMain();
                    this.Hide();
                    m.ShowDialog();
                    this.Show();
                    //MessageBox.Show("Hoàn thành công việc của mình trước 26/3/2018", "Deadline");
                }
                else
                {
                    MessageBox.Show("Không đăng nhập được! Kiểm tra lại thông tin tài khoản!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đăng nhập được! Kiểm tra lại thông tin tài khoản!" + ex.Message);
            }
        }

        
        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbLuuTK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMK.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void cbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMK.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
