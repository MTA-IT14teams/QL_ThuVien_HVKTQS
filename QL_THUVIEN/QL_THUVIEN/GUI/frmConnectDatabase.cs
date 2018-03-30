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
using System.IO;

namespace QL_ThuVien.GUI
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

        private void cbxChonTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChonTaiKhoan.SelectedIndex == 0)
            {
                DTO.ConnectDatabase.WindowAuthentication = true;
                txtTenDangNhap.Enabled = false;
                txtMK.Enabled = false;
            }
            else
            {
                DTO.ConnectDatabase.WindowAuthentication = false;
                txtTenDangNhap.Enabled = true;
                txtMK.Enabled = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            if (txtTenMayChu.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên máy chủ");
                ActiveControl = txtTenMayChu;
                return;
            }

            if (txtTenCSDL.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên CSDL");
                ActiveControl = txtTenCSDL;
                return;
            }
            
            string connect="";

            DTO.ConnectDatabase.SeverName = txtTenMayChu.Text.Trim();
            DTO.ConnectDatabase.DatabaseName = txtTenCSDL.Text.Trim();

            //using (StreamWriter write = new StreamWriter("config"))
            //{
            //    write.WriteLine(DTO.ConnectDatabase.SeverName);
            //    write.WriteLine(DTO.ConnectDatabase.DatabaseName);
            //}

            if (DTO.ConnectDatabase.WindowAuthentication == true)
            {
                DTO.ConnectDatabase.TaoChuoiKetNoi();
                connect = DTO.ConnectDatabase.ConnectionString;
            }
            else
            {
                if (txtTenDangNhap.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập tên đăng nhập");
                    ActiveControl = txtTenDangNhap;
                    return;
                }
                if (txtMK.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập mật khẩu");
                    ActiveControl = txtMK;
                    return;
                }
                DTO.ConnectDatabase.UserName = txtTenDangNhap.Text.Trim();
                DTO.ConnectDatabase.PassWord = txtMK.Text.Trim();
                DTO.ConnectDatabase.TaoChuoiKetNoi();
                
                connect = DTO.ConnectDatabase.ConnectionString;
            }

            //MessageBox.Show(connect);
            try
            {
                SqlConnection conn = new SqlConnection(connect);
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("Kết nối thành công");
                    using (StreamWriter write = new StreamWriter("config"))
                    {
                        write.WriteLine(DTO.ConnectDatabase.SeverName);
                        write.WriteLine(DTO.ConnectDatabase.DatabaseName);
                        write.WriteLine(DTO.ConnectDatabase.UserName);
                        write.WriteLine(DTO.ConnectDatabase.PassWord);
                    }

                    GUI.frmLogin lg = new GUI.frmLogin();
                    this.Hide();
                    lg.ShowDialog();
                    

                }
                else
                {
                    MessageBox.Show("Kết nối thất bại");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmConnectDatabase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
