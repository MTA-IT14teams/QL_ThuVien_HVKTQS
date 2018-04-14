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
    public partial class frmDauSach : Form
    {
        public frmDauSach()
        {
            InitializeComponent();
        }
        //status   0:none 1:them 2:Sua 3:Xoa
        private byte _status = 0;
        //
        private DataTable dtTuaSach = new DataTable();
        private DataTable dtTacGia = new DataTable();
        private DataTable dtDuLieu = new DataTable();
        private DataTable dtNXB = new DataTable();
        //
        DataView dvDuLieu = new DataView();
        DataView dvTuaSach = new DataView();
        DataView dvTacGia = new DataView();
        DataView dvNXB = new DataView();
        //
        System.Windows.Forms.BindingSource bsDuLieu = new System.Windows.Forms.BindingSource();
        //
       
        private void loadData()
        {
            try
            {
                SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                MyConnect.Open();
                SqlCommand cmd = new SqlCommand("select * from TuaSach", MyConnect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                this.dtTuaSach.Clear();
                da.Fill(dtTuaSach);
                //fill data into TacGia
                cmd = new SqlCommand("select * from TacGia", MyConnect);
                da = new SqlDataAdapter(cmd);
                this.dtTacGia.Clear();
                da.Fill(dtTacGia);
                //fill data into TuaSach
              
                cmd = new SqlCommand("SELECT ts.maTS,ts.tenTS,ts.namXB,ts.Gia,ts.viTri,ts.noiDungTT,ts.nnChinh,ts.maNXB, nxb.tenNXB FROM dbo.TuaSach ts LEFT JOIN dbo.NXB nxb ON nxb.maNXB = ts.maNXB", MyConnect);
                da = new SqlDataAdapter(cmd);
                this.dtDuLieu.Clear();
                da.Fill(dtDuLieu);
                //fill data into NXB
                cmd = new SqlCommand("Select * from NXB", MyConnect);
                da = new SqlDataAdapter(cmd);
                this.dtNXB.Clear();
                da.Fill(dtNXB);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy dữ liệu từ Server.\nVui lòng kiểm tra lại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void displayData()
        {
            try
            {

                dvDuLieu = new DataView(dtDuLieu);
                dvTuaSach = new DataView(dtTuaSach);
                dvTacGia = new DataView(dtTacGia);
                dvNXB = new DataView(dtNXB);
                //data
                bsDuLieu.DataSource = dvDuLieu;
                bnChucNang.BindingSource = bsDuLieu;
                dgvTS.DataSource = bsDuLieu;
                //nxb
                cboNhaXB.DataSource = dvNXB;
                cboNhaXB.DisplayMember = "tenNXB";
                cboNhaXB.ValueMember = "maNXB";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Don't display data.\nERROR:" + ex.Message);
            }



        }
        private void bindingData()
        {
            this.txtMaTS.DataBindings.Add("Text", dgvTS.DataSource, "maTS", true, DataSourceUpdateMode.Never);
            this.txtTen.DataBindings.Add("Text", dgvTS.DataSource, "tenTS", true, DataSourceUpdateMode.Never);
            this.txtNamXB.DataBindings.Add("Text", dgvTS.DataSource, "namXB", true, DataSourceUpdateMode.Never);
            this.txtGia.DataBindings.Add("Text", dgvTS.DataSource, "Gia", true, DataSourceUpdateMode.Never);
            this.txtViTri.DataBindings.Add("Text", dgvTS.DataSource, "viTri", true, DataSourceUpdateMode.Never);
            this.txtNgonNgu.DataBindings.Add("Text", dgvTS.DataSource, "nnChinh", true, DataSourceUpdateMode.Never);
            this.txtNDTT.DataBindings.Add("Text", dgvTS.DataSource, "noiDungTT", true, DataSourceUpdateMode.Never);
            //
            this.cboNhaXB.DataBindings.Add("SelectedValue", dgvTS.DataSource, "maNXB", true, DataSourceUpdateMode.Never);
            this.cboNhaXB.DataBindings.Add("Text", dgvTS.DataSource, "tenNXB", true, DataSourceUpdateMode.Never);
            //   this.cboGiaoVien.DataBindings.Clear();
            //   this.cboGiaoVien.DataBindings.Add("SelectedValue", dgvData.DataSource, "MaGV", true, DataSourceUpdateMode.Never);
            //    this.cboGiaoVien.DataBindings.Add("Text", dgvData.DataSource, "TenGV", true, DataSourceUpdateMode.Never);
            //   this.cboLop.DataBindings.Add("SelectedValue", dgvData.DataSource, "MaLop", true, DataSourceUpdateMode.Never);
            //  this.cboLop.DataBindings.Add("Text", dgvData.DataSource, "TenLop", true, DataSourceUpdateMode.Never);

            //   this.cboThu.DataBindings.Add("SelectedValue", dgvData.DataSource, "idthu", true, DataSourceUpdateMode.Never);
            //    this.cboThu.DataBindings.Add("Text", dgvData.DataSource, "Thu", true, DataSourceUpdateMode.Never);

            //  this.txtTiet.DataBindings.Add("Text", dgvData.DataSource, "Tiet", true, DataSourceUpdateMode.Never);

        }









        private void frmDauSach_Load(object sender, EventArgs e)
        {
            loadData();
            displayData();

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;

        }

        private void dgvTS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbtnTimKiem_Click(object sender, EventArgs e)
        {
            if(tstxtTuKhoa.Text.Trim() != "")
            {
                if (tscboTieuDeTK.SelectedIndex == 0)
                {
                    this.bsDuLieu.Filter = "maTS Like'*" + tstxtTuKhoa.Text.Trim() + "*'";
                }
                else if (tscboTieuDeTK.SelectedIndex == 1)
                {
                    this.bsDuLieu.Filter = "tenTS Like'*" + tstxtTuKhoa.Text.Trim() + "*'";
                }
                else if (tscboTieuDeTK.SelectedIndex == 2)
                {
                    //nam
                    this.bsDuLieu.Filter = "namXB = '" + tstxtTuKhoa.Text.Trim() + "'";
                }
                else if (tscboTieuDeTK.SelectedIndex == 3)
                {
                    //nn
                    this.bsDuLieu.Filter = "nnChinh Like'*" + tstxtTuKhoa.Text.Trim() + "*'";
                }
                else if (tscboTieuDeTK.SelectedIndex == 4)
                {
                    //tg
                    this.bsDuLieu.Filter = "tenTG Like'*" + tstxtTuKhoa.Text.Trim() + "*'";
                }
                else if (tscboTieuDeTK.SelectedIndex == 5)
                {
                    //nxb
                    this.bsDuLieu.Filter = "tenNXB Like'*" + tstxtTuKhoa.Text.Trim() + "*'";
                }
                else
                {

                }
            }
            else
            {
                this.bsDuLieu.Filter = null;
            }
           
        }
        private void tstxtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            tsbtnTimKiem_Click(null, null);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                ////
                _status = 1;//them
                ////
                this.txtMaTS.Enabled = true;
                this.txtMaTS.Clear();
                this.txtTen.Clear();
                this.txtViTri.Clear();
                this.txtNgonNgu.Clear();
                this.txtNDTT.Clear();
                this.txtNamXB.Clear();
                this.txtGia.Clear();
                ////
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                ActiveControl = this.txtMaTS;
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

      

        private void btnSua_Click(object sender, EventArgs e)
        {
            ////
            _status = 2;//sua
            ////
            this.txtMaTS.Enabled = false;
            ////
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            ActiveControl = this.txtMaTS;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa?","Chú Ý",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                XoaDuLieu();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ////
            _status = 0;//them
                        ////
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = true;
           
        }

        private void SuaDuLieu()
        {
            try
            {
                ////
                SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                MyConnect.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.TuaSach SET tenTS=@tenTS ,namXB=@namXB ,Gia=@Gia ,viTri=@viTri ,noiDungTT=@noiDungTT ,nnChinh=@nnChinh ,maNXB=@maNXB WHERE maTS =@maTS ", MyConnect);
                cmd.Parameters.Add("@maTS", this.txtMaTS.Text.Trim());
                cmd.Parameters.Add("@tenTS", this.txtTen.Text.Trim());
                cmd.Parameters.Add("@namXB", this.txtNamXB.Text.Trim());
                cmd.Parameters.Add("@Gia", this.txtGia.Text.Trim());
                cmd.Parameters.Add("@vitri", this.txtViTri.Text.Trim());
                cmd.Parameters.Add("@noidungTT", this.txtNDTT.Text.Trim());
                cmd.Parameters.Add("@nnChinh", this.txtNgonNgu.Text.Trim());
                cmd.Parameters.Add("@maNXB", this.cboNhaXB.SelectedValue);

                var _num = cmd.ExecuteNonQuery();
                if (_num == 0)
                {
                    MessageBox.Show("Không thể sửa Dữ Liệu.\nHãy Kiểm Tra Lại!\n", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã Sửa Dữ Liệu Thành Công!\n", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyConnect.Close();
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void ThemDuLieu()
        {
            try
            {
                ////
                SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                MyConnect.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.TuaSach( maTS ,tenTS ,namXB ,Gia ,viTri ,noiDungTT ,nnChinh ,maNXB) VALUES  (@maTS ,@tenTS ,@namXB ,@Gia ,@viTri ,@noiDungTT ,@nnChinh ,@maNXB) ", MyConnect);
                cmd.Parameters.Add("@maTS", this.txtMaTS.Text.Trim());
                cmd.Parameters.Add("@tenTS", this.txtTen.Text.Trim());
                cmd.Parameters.Add("@namXB", this.txtNamXB.Text.Trim());
                cmd.Parameters.Add("@Gia", this.txtGia.Text.Trim());
                cmd.Parameters.Add("@vitri", this.txtViTri.Text.Trim());
                cmd.Parameters.Add("@noidungTT", this.txtNDTT.Text.Trim());
                cmd.Parameters.Add("@nnChinh", this.txtNgonNgu.Text.Trim());
                cmd.Parameters.Add("@maNXB", this.cboNhaXB.SelectedValue);

                var _num = cmd.ExecuteNonQuery();
                if (_num == 0)
                {
                    MessageBox.Show("Không thể thêm Dữ Liệu.\nHãy Kiểm Tra Lại!\n", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã Thêm Dữ Liệu Thành Công!\n", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyConnect.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void XoaDuLieu()
        {
            try
            {
                ////
                SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                MyConnect.Open();
                SqlCommand cmd = new SqlCommand("DELETE dbo.TuaSach WHERE maTS = @maTS", MyConnect);
                cmd.Parameters.Add("@maTS", this.txtMaTS.Text.Trim());
                var _num = cmd.ExecuteNonQuery();
                if (_num == 0)
                {
                    MessageBox.Show("Không thể sửa Dữ Liệu.\nHãy Kiểm Tra Lại!\n", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã Sửa Dữ Liệu Thành Công!\n", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyConnect.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //DELETE dbo.TuaSach WHERE maTS = @maTS
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(_status == 1)
            {
                ThemDuLieu();
                frmDauSach_Load(null,null);
                //loadData();
                //displayData();
            }
            else if(_status == 2)
            {
                SuaDuLieu();
                frmDauSach_Load(null, null);
                //loadData();
                //displayData();
            }
        }

        private void frmDauSach_Shown(object sender, EventArgs e)
        {
            bindingData();
        }

        private void btnTG_Click(object sender, EventArgs e)
        {
            frmTacGia tg = new frmTacGia(this.txtMaTS.Text.Trim());
            tg.ShowDialog();
        }

        private void dgvTS_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvTS.CurrentRow.Selected = true;
            }
            catch
            {

            }
        }

        private void btnTL_Click(object sender, EventArgs e)
        {
            frmTheLoai tl = new frmTheLoai(this.txtMaTS.Text.Trim());
            tl.ShowDialog();
        }
    }
}
