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

namespace QL_ThuVien.GUI
{
    public partial class frmMuontra : Form
    {
        public frmMuontra()
        {
            InitializeComponent();
        }
        public static DataTable GetData(string proc)
        {
            SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(proc, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static DataTable xuat_DGcoMa(string maDG)
        {
            return GetData("get_DGcoMa" + "'" + maDG + "'");
            return xuat_DGcoMa(maDG);
        }

        //lấy ra dữ liệu  phiếu mượn trả của độc giả
        public static DataTable xuat_PMTcuaDG(string maDG)
        {
            return GetData("get_PMTcuaDG" + "'" + maDG + "'");
            return xuat_PMTcuaDG(maDG);
        }

        // lấy ra dữ liệu chi tiết mượn của phiếu mượn
        public static DataTable xuat_CTMcuaPM(string soPMT)
        {
            return GetData("get_CTMcuaPM" + "'" + soPMT + "'");
            return xuat_CTMcuaPM(soPMT);
        }
        private void LoadDG()
        {

            if (txtMDG1.Text == "")
            {
                MessageBox.Show(" Nhập vào mã độc giả!");

            }
            else
            {
                DataTable dt = xuat_DGcoMa(txtMDG1.Text.Trim());
                txtTenDG.Text = Convert.ToString(dt.Rows[0].ItemArray[1]);
                if (Convert.ToString(dt.Rows[0].ItemArray[2]) == "Nam") rdbNam.Checked = true;
                else rdbNu.Checked = true;
                txtNgaySinh.Text = Convert.ToDateTime(dt.Rows[0].ItemArray[3]).ToShortDateString();
                txtSDT.Text = Convert.ToString(dt.Rows[0].ItemArray[5]);
                txtLoai.Text = Convert.ToString(dt.Rows[0].ItemArray[6]);
            }

        }
        private void LoadPMT()
        {
            dgvChiTietMuon.DataSource = xuat_PMTcuaDG(txtMDG1.Text.Trim());
        }
        private void LoadCTM()
        {
            dgvChiTietMuon.DataSource = xuat_CTMcuaPM(txtSoPMT.Text.Trim());
        }


        //Xem
        private void btnXem_Click_1(object sender, EventArgs e)
        {
            LoadDG();
            LoadPMT();
        }


        public void khoa_PMT()
        {
            // khóa các txt của phiếu mượn trả
            txtSoPMT.Enabled = false;
            txtMDG2.Enabled = false;
            txtMTT.Enabled = false;
            dateHtra.Enabled = false;
            dateLap.Enabled = false;
            dateTra.Enabled = false;
        }
        public void mo_PMT()
        {
            // mở các date của phiếu mượn trả
            dateHtra.Enabled = true;
            dateLap.Enabled = true;
            dateTra.Enabled = true;
        }

        private void LoadTxtPMT()
        {
            txtSoPMT.Text = dgvChiTietMuon.CurrentRow.Cells[0].Value.ToString().Trim();
            dateLap.Value = Convert.ToDateTime(dgvChiTietMuon.CurrentRow.Cells[1].Value);
            dateHtra.Value = Convert.ToDateTime(dgvChiTietMuon.CurrentRow.Cells[2].Value);
            try
            {
                dateTra.Value = Convert.ToDateTime(dgvChiTietMuon.CurrentRow.Cells[3].Value);
                dateTra.Format = DateTimePickerFormat.Short;
            }
            catch
            {
                dateTra.Value = dateLap.Value;
                dateTra.Format = DateTimePickerFormat.Custom;
            }
            txtMDG2.Text = dgvChiTietMuon.CurrentRow.Cells[4].Value.ToString().Trim();
            txtMTT.Text = dgvChiTietMuon.CurrentRow.Cells[5].Value.ToString().Trim();
        }
        private void dgvPhieuMuonTra_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            //btnXoa.Active = true;
            khoa_PMT();
            LoadTxtPMT();
            LoadCTM();
        }

        private void frmMuontra_Load_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            khoa_PMT();

        }



        private void btnSua_Click_1(object sender, EventArgs e)
        {
            btnXoa.Text = "Hủy";
            mo_PMT();
        }

       
    }
}
