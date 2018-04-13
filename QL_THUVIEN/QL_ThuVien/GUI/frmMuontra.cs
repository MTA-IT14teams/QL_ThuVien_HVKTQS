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

        private int nhay = -1;
        private string SoPMT;
        private string NgayLap;
        private string NgayHTra;
        private string NgayTra;
        private string MaDG;
        private string MaTT;
        SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);

        public frmMuontra()
        {
            InitializeComponent();
        }

         // Lấy dữ liệu và đổ vào bảng
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

        // thực thi thủ tục lấy ra độc giả có mã
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

        // hiển thị đôc giả đã mượn sách 
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
            dgvPhieuMuonTra.DataSource = xuat_PMTcuaDG(txtMDG1.Text.Trim());
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
            txtSoPMT.Text = dgvPhieuMuonTra.CurrentRow.Cells[0].Value.ToString().Trim();
            dateLap.Value = Convert.ToDateTime(dgvPhieuMuonTra.CurrentRow.Cells[1].Value);
            dateHtra.Value = Convert.ToDateTime(dgvPhieuMuonTra.CurrentRow.Cells[2].Value);
            try
            {
                dateTra.Value = Convert.ToDateTime(dgvPhieuMuonTra.CurrentRow.Cells[3].Value);
                dateTra.Format = DateTimePickerFormat.Short;
            }
            catch
            {
                dateTra.Value = dateLap.Value;
                dateTra.Format = DateTimePickerFormat.Custom;
            }
            txtMDG2.Text = dgvPhieuMuonTra.CurrentRow.Cells[4].Value.ToString().Trim();
            txtMTT.Text = dgvPhieuMuonTra.CurrentRow.Cells[5].Value.ToString().Trim();
        }
        private void dgvPhieuMuonTra_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            //btnXoa.Active = true;
            khoa_PMT();
            //mo_PMT();
            LoadTxtPMT();
            LoadCTM();
        }

        private void frmMuontra_Load_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            khoa_PMT();

        }

        private void XoaDG()
        {
            txtTenDG.Clear();
            txtNgaySinh.Clear();
            txtSDT.Clear();
            rdbNam.Checked = true;
            txtLoai.Clear();
        }

        private void XoaPMT()
        {
            dgvPhieuMuonTra.DataSource = null;
        }
        private void XoaCTM()
        {
            dgvChiTietMuon.DataSource = null;
        }
        private void XoaTxtPMT()
        {
            txtSoPMT.Clear();
            txtMDG2.Clear();
            txtMTT.Clear();
            dateLap.Format = DateTimePickerFormat.Short;
            dateHtra.Format = DateTimePickerFormat.Short;
            dateTra.Format = DateTimePickerFormat.Short;
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            if (txtMDG1.Text.Trim() != "")
            {
                DTO.MuonSach.MaDG = txtMDG1.Text.Trim();
                PhieuMuon pm = new PhieuMuon();
                pm.ShowDialog();
            }
            else
                MessageBox.Show("Mã độc giả sai hoặc độc giả không được mượn sách!");
        }

        // định dạng cho ngày
        private void dateTra_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dateLap.Value, dateTra.Value) == 0)
                dateTra.Format = DateTimePickerFormat.Custom;
            else
                dateTra.Format = DateTimePickerFormat.Short;
        }

        private void dateLap_ValueChanged(object sender, EventArgs e)
        {
            if (dateTra.Text == "")
                dateTra.Value = dateLap.Value;
        }
        private void clearCTM()
        {
            dgvPhieuMuonTra.DataSource = null;
        }
        private void clearTxtPMT()
        {
            txtSoPMT.Clear();
            txtMDG2.Clear();
            txtMTT.Clear();
            dateLap.Format = DateTimePickerFormat.Short;
            dateHtra.Format = DateTimePickerFormat.Short;
            dateTra.Format = DateTimePickerFormat.Short;
        }
        private void disablePMT()
        {
            txtSoPMT.Enabled = false;
            txtMDG2.Enabled = false;
            txtMTT.Enabled = false;
            dateHtra.Enabled = false;
            dateLap.Enabled = false;
            dateTra.Enabled = false;
        }
        private int ExecuteNonQuery1(string proc, SqlParameter[] para)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);

                int val = cmd.ExecuteNonQuery();
                conn.Close();
                return val;
            }
            catch (SqlException)
            {
                return 0;
            }
        }

        private void tinhTien_PMT(string SoPMT)
        {
            ExecuteNonQuery1("tinhTien_PMT", new SqlParameter[] { new SqlParameter("@soPMT", SoPMT) });
        }
        private int sua_PMT()
        {
            SoPMT = txtSoPMT.Text.Trim();
            MaDG = txtMDG2.Text.Trim();
            MaTT = txtMTT.Text.Trim();
            NgayLap = dateLap.Value.Year.ToString() + "-" +
                dateLap.Value.Month.ToString() + "-" + dateLap.Value.Day.ToString();
            NgayHTra = dateHtra.Value.Year.ToString() + "-" +
                dateHtra.Value.Month.ToString() + "-" + dateHtra.Value.Day.ToString();
            NgayTra = dateTra.Value.Year.ToString() + "-" +
                dateTra.Value.Month.ToString() + "-" + dateTra.Value.Day.ToString();

            SqlParameter[] para = new SqlParameter[]
                    {
                        new SqlParameter("@sopmt", SoPMT),
                        new SqlParameter("@ngaylappmt", NgayLap),
                        new SqlParameter("@ngayhtra", NgayHTra),
                        new SqlParameter("@ngaytra",NgayTra),
                        new SqlParameter("@madg", MaDG),
                        new SqlParameter("@matt", MaTT),

                      };
            return ExecuteNonQuery1("sua_PMT", para);

        }
        private void btnGhiNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (nhay == 1)//nut btnSua hoat dong
                {
                    SoPMT = txtSoPMT.Text.Trim();
                    //MaDG = txtMDG2.Text.Trim();
                    //MaTT = txtMTT.Text.Trim();
                    //NgayLap = dateLap.Value.Year.ToString() + "-" +
                    //    dateLap.Value.Month.ToString() + "-" + dateLap.Value.Day.ToString();
                    //NgayHTra = dateHtra.Value.Year.ToString() + "-" +
                    //    dateHtra.Value.Month.ToString() + "-" + dateHtra.Value.Day.ToString();
                    //NgayTra = dateTra.Value.Year.ToString() + "-" +
                    //    dateTra.Value.Month.ToString() + "-" + dateTra.Value.Day.ToString();

                   
                    if (sua_PMT()==1)
                    {
                        tinhTien_PMT(SoPMT);
                        clearCTM();
                        LoadPMT();
                        MessageBox.Show("Sửa  thành công!!");
                    }
                    
                }
                else throw new Exception();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnXoa.Text = "Xoá";
                nhay = 1;   //nut btnXoa hoatdong
                clearTxtPMT();
                disablePMT();
                btnSua.Enabled = false;
                LoadDG();
                LoadCTM();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            nhay = 1;
            btnXoa.Text = "Hủy";
            mo_PMT();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (nhay == 1)
            {
                clearTxtPMT();
                disablePMT();
                nhay = 2;
                btnXoa.Text = "Xóa";
                btnSua.Enabled = false;
            }
            else
            {
                int xoa;
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@sopmt",txtSoPMT.Text.Trim())
                };
                xoa = ExecuteNonQuery1("xoa_PMT", para);
                if (xoa > 0)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                    MessageBox.Show("Không xóa được");
                clearCTM();
                clearTxtPMT();
                disablePMT();
                LoadPMT();
                LoadDG();
                LoadCTM();
                btnSua.Enabled = false;
            }
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayTra, ngayHTra, ngayLap;
                if (dateTra.Text == " ")
                {
                    SoPMT = txtSoPMT.Text.Trim();
                    MaDG = txtMDG2.Text.Trim();
                    MaTT = txtMTT.Text.Trim();
                    ngayTra = DateTime.Today;
                    ngayHTra = dateHtra.Value;
                    ngayLap = dateLap.Value;
                    if (DateTime.Compare(ngayLap, ngayTra) == 0) throw new Exception();

                    if (sua_PMT() == 1)
                    {
                        tinhTien_PMT(SoPMT);
                        LoadCTM();
                        LoadPMT();
                        MessageBox.Show("Đã trả thành công!!!");
                        ChiTietMuon.soPMT = txtSoPMT.Text.Trim();
                        ChiTietMuon.maDG = txtMDG2.Text.Trim();
                        ChiTietMuon.ngayLap = dateLap.Value.Year.ToString() + "-" + dateLap.Value.Month.ToString() + "-" + dateLap.Value.Day.ToString();
                        ChiTietMuon.ngayHtra = dateHtra.Value.Year.ToString() + "-" + dateHtra.Value.Month.ToString() + "-" + dateHtra.Value.Day.ToString();
                        ChiTietMuon.ngayTra = (DateTime.Compare(ngayLap, ngayTra) != 0) ? ngayTra.ToShortDateString() : "";
                        new ChiTietMuon().Show();
                    }
                    else throw new Exception();

                }
                else throw new Exception();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không trả được!!!");
            }
        }
    }
}
