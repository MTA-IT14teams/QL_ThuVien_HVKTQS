using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QL_ThuVien.GUI
{

   

    public partial class PhieuMuon : Form
    {
        public static string maDG = null;
        public PhieuMuon()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                conn.Open();
                string sql = "insert into PhieuMuonTra values (@SoPMT, @NgayLap, @NgayHenTra, @NgayTra, @MaDG, @MaTT)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@SoPMT", txtSoPMT.Text.Trim());
                cmd.Parameters.Add("@NgayLap", dtpNgayLap.Text);
                cmd.Parameters.Add("@NgayHenTra", dtpNgayHenTra.Text);
                cmd.Parameters.Add("@NgayTra", dtpNgayTra.Text);
                cmd.Parameters.Add("@MaDG", txtMDG.Text.Trim());
                cmd.Parameters.Add("@MaTT", txtMTT.Text.Trim());

                
                DTO.MuonSach.SoPMT = txtSoPMT.Text.Trim();

                int tmp = cmd.ExecuteNonQuery();
                if(tmp != 0)
                {
                    ThemSachMuon tpm = new ThemSachMuon();
                    this.Hide();
                    tpm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Lỗi! Không thêm được!");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void PhieuMuon_Load(object sender, EventArgs e)
        {
            
            txtMDG.Text =DTO.MuonSach.MaDG;
        }
    }
}
