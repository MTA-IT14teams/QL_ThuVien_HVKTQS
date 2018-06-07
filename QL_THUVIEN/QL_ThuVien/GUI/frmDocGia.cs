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
    public partial class frmDocGia : Form
    {
        public frmDocGia()
        {
            InitializeComponent();
        }

        private void frmDocGia_Load(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
            grbThongTin.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
        }

        public void KetNoi()
        {
            SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
            conn.Open();

            string sql = "select *from DocGia" ;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDocGia.DataSource = dt;
        }

        public void LoadData()
        {
            txtMaDG.DataBindings.Clear();
            txtMaDG.DataBindings.Add("Text", dgvDocGia.DataSource, "maDG");

            txtTenDG.DataBindings.Clear();
            txtTenDG.DataBindings.Add("Text", dgvDocGia.DataSource, "tenDG");

            cboGioiTinh.DataBindings.Clear();
            cboGioiTinh.DataBindings.Add("Text", dgvDocGia.DataSource, "gioiTinh");

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Text", dgvDocGia.DataSource, "ngaySinh");

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvDocGia.DataSource, "diaChi");

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgvDocGia.DataSource, "SDT");

            txtLoaiDG.DataBindings.Clear();
            txtLoaiDG.DataBindings.Add("Text", dgvDocGia.DataSource, "loaiDG");

        }

        bool them = false;

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            grbThongTin.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            grbThongTin.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
            grbThongTin.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                    conn.Open();

                    string sql = "insert into DocGia values (@MaDG, @TenDG, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @LoaiDG)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@MaDG", txtMaDG.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenDG", txtTenDG.Text.Trim());
                    cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@LoaiDG", txtLoaiDG.Text.Trim());

                    int temp = cmd.ExecuteNonQuery();

                    if (temp != 0)
                    {
                        MessageBox.Show("Đã Thêm");
                        grbThongTin.Enabled = false;
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra lại");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            //sua 
            {
                SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                conn.Open();

                string sql = "update DocGia set maDG = @MaDG, tenDG = @TenDG, gioiTinh = @GioiTinh,ngaySinh = @NgaySinh,diaChi = @DiaChi, SDT = @SDT, loaiDG = @LoaiDG where maDG = @MaDG";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaDG", txtMaDG.Text.Trim());
                cmd.Parameters.AddWithValue("@TenDG", txtTenDG.Text.Trim());
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text.Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@LoaiDG", txtLoaiDG.Text.Trim());

                int temp = cmd.ExecuteNonQuery();

                if (temp != 0)
                {
                    MessageBox.Show("Đã sửa");
                    grbThongTin.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại");
                }
            }
            btnRefresh_Click(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa độc giả " + txtTenDG.Text.Trim() + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("XoaDG", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaDG", txtMaDG.Text.Trim());

                    cmd.ExecuteNonQuery();

                    KetNoi();
                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string sql = "";
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                conn.Open();
                if (cbbKieuTK.Text == "Theo Mã Độc Giả")
                {
                    sql = "select *from DocGia where maDG = '" + txtTimKiem.Text.Trim() + "'";
                }
                else if (cbbKieuTK.Text == "Theo Tên Độc Giả")
                {
                    sql = "select *from DocGia where tenDG like N'%" + txtTimKiem.Text.Trim() + "%'";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                dgvDocGia.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnTimKiem_Click(null, null);
        }
        

    }
}
