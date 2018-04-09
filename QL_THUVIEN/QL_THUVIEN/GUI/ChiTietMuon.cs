using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuVien.GUI
{
    public partial class ChiTietMuon : Form
    {
        SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
        public static string soPMT;
        public static string maDG;
        public static string ngayLap;
        public static string ngayHtra;
        public static string ngayTra;

        public  DataTable GetData(string proc)
        {
            
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(proc, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public ChiTietMuon()
        {
            InitializeComponent();
        }
        

        private DataTable xuat_CTMcuaPM(string soPMT)
        {
            return GetData("get_CTMcuaPM" + "'" + soPMT + "'");
        }
        private void ChiTietMuon_Load(object sender, EventArgs e)
        {

            labSP.Text += " " + soPMT;
            labMDG.Text += " " + maDG;
            labNgayLap.Text += " " + ngayLap;
            labNgayhTra.Text += " " + ngayHtra;
            labNgayTra.Text += " " + ngayTra;
            dgvCTM.DataSource = xuat_CTMcuaPM(soPMT);
            labTC.Text += " " + tienCoc() + " vnd";
            labTTT.Text += " " + tienThanhToan() + " vnd";
        }
        private int tienCoc()
        {
            int tien = 0;
            foreach (DataGridViewRow row in dgvCTM.Rows)
            {
                try
                {
                    tien += int.Parse(row.Cells[2].Value.ToString().Split('.')[0]);
                }
                catch
                {

                }
            }
            return tien;
        }

        private int tienThanhToan()
        {
            int tien = 0;
            foreach (DataGridViewRow row in dgvCTM.Rows)
            {
                try
                {
                    tien += int.Parse(row.Cells[3].Value.ToString().Split('.')[0]);
                }
                catch
                {

                }
            }
            return tien;
        }

        private void ChiTietMuon_FormClosing(object sender, FormClosingEventArgs e)
        {

            soPMT = null;
            maDG = null;
            ngayLap = null;
            ngayHtra = null;
            ngayTra = null;
        }
    }
}
