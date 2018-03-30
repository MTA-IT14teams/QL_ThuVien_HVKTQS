using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;

namespace QL_ThuVien.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                conn.Open();

                string sql = "select *from tbl_Users where UserName = '" + txtUserName.Text.Trim() + "' and PassWord = '" + txtPassWord.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.ExecuteNonQuery();

                SqlDataReader dta = cmd.ExecuteReader();

                if (dta.Read() == true)
                {
                    if (cbSaveInfo.Checked == true)
                    {
                        using (StreamWriter wr = new StreamWriter("info.ini"))
                        {
                            wr.WriteLine(txtUserName.Text.Trim());
                            wr.WriteLine(txtPassWord.Text.Trim());
                            wr.Close();
                        }
                    }
                    else
                    {
                        File.Delete("info.ini");
                    }
                    GUI.frmMain m = new frmMain();
                    this.Hide();
                    m.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassWord.UseSystemPasswordChar = false;
        }

        private void cbSaveInfo_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists("info.ini"))
            {
                using (StreamReader re = new StreamReader("info.ini"))
                {
                    txtUserName.Text = re.ReadLine();
                    txtPassWord.Text = re.ReadLine();
                }
            }
        }

        private void lbForgetAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Liên hệ với QTV để lấy lại mật khẩu!");
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            btnLogin_Click(null, null);
        }
    }
}
