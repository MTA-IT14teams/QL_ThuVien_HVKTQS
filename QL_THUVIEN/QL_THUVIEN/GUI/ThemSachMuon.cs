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
    public partial class ThemSachMuon : Form
    {
        public ThemSachMuon()
        {
            InitializeComponent();
        }

        private void txtMCS_TextChanged(object sender, EventArgs e)
        {

        }

        public void LoadDataGrid()
        {
            SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("select *from ChiTietMuon", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCTM.DataSource = dt;
        }

        private void ThemSachMuon_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           try
            {
                SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                conn.Open();
                string sql = "insert into ChiTietMuon values (@SoPMT, @MaCS, @TienCoc, @TienTT)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@SoPMT", DTO.MuonSach.SoPMT);
                cmd.Parameters.Add("@MaCS", txtMCS.Text.Trim());
                cmd.Parameters.Add("@TienCoc", txtTienCoc.Text.Trim());
                cmd.Parameters.Add("@TienTT", txtTienTra.Text.Trim());

                int temp = cmd.ExecuteNonQuery();

                if(temp != 0)
                {
                    MessageBox.Show("Mượn thành công!");
                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("Lỗi!");
                }

                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       
    }
}
