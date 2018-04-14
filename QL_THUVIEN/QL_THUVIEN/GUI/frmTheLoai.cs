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
    public partial class frmTheLoai : Form
    {
        public frmTheLoai(string mts)
        {
            this.MaTuaSach = mts;
            InitializeComponent();
        }
        private string MaTuaSach = "";
        //
        private byte _status = 0;
        //
        
        private DataTable dtTheLoai = new DataTable();
        private DataTable dtDuLieu = new DataTable();
        
        //
        DataView dvDuLieu = new DataView();
        DataView dvTheLoai = new DataView();
        //
        BindingSource bsDuLieu = new BindingSource();

        private void loadData()
        {
            try
            {
                SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                MyConnect.Open();
               
               
                //fill data into TacGia
               SqlCommand cmd = new SqlCommand("select * from TheLoai", MyConnect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                this.dtTheLoai.Clear();
                da.Fill(dtTheLoai);
                //fill data into TuaSach
                    //                --view tua sach-the loai
                    //ALTER VIEW v_TuaSach_TL AS
                    //SELECT ts.maTS,ts.tenTS,v_tl.maTL,v_tl.tenTL
                    //FROM dbo.TuaSach ts
                    //INNER JOIN (SELECT tstl.maTS, tl.maTL, tl.tenTL FROM dbo.TS_TL tstl, dbo.TheLoai tl WHERE tstl.maTL = tl.maTL) v_tl
                    //  ON v_tl.maTS = ts.maTS
                    //GO

                    //SELECT* FROM dbo.v_TuaSach_TL
                    //GO
                cmd = new SqlCommand("SELECT* FROM dbo.v_TuaSach_TL", MyConnect);
                da = new SqlDataAdapter(cmd);
                this.dtDuLieu.Clear();
                da.Fill(dtDuLieu);
             
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
                dvTheLoai = new DataView(dtTheLoai);
                //
                this.bsDuLieu.DataSource = dvDuLieu;
                bnChucNang.BindingSource = bsDuLieu;
                dgvDuLieu.DataSource = bsDuLieu;
                //
                this.cboTheLoai.DataSource = dvTheLoai;
                this.cboTheLoai.ValueMember = "maTL";
                this.cboTheLoai.DisplayMember = "tenTL";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Don't display data.\nERROR:" + ex.Message);
            }



        }
        private void bindingData()
        {
            this.txtMaTS.DataBindings.Add("Text", this.dgvDuLieu.DataSource, "maTS", true, DataSourceUpdateMode.Never);
            this.txtTenTS.DataBindings.Add("Text", this.dgvDuLieu.DataSource, "tenTS", true, DataSourceUpdateMode.Never);
            this.cboTheLoai.DataBindings.Add("SelectedValue", this.dgvDuLieu.DataSource, "maTL", true, DataSourceUpdateMode.Never);
            this.cboTheLoai.DataBindings.Add("Text", this.dgvDuLieu.DataSource, "tenTL", true, DataSourceUpdateMode.Never);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _status = 1;//them
            ////
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            ActiveControl = cboTheLoai;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _status = 2;//sua
            ////
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            ActiveControl = cboTheLoai;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                    MyConnect.Open();
                    SqlCommand cmd = new SqlCommand("DELETE dbo.TS_TL WHERE maTS = @maTS and maTL = @maTL", MyConnect);
                    cmd.Parameters.Add("@maTS", this.txtMaTS.Text.Trim());
                    cmd.Parameters.Add("@maTL", this.cboTheLoai.SelectedValue);


                    var _num = cmd.ExecuteNonQuery();
                    if (_num == 0)
                    {
                        MessageBox.Show("Không thể Xoá Dữ Liệu.\nHãy Kiểm Tra Lại!\n", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Đã Xóa Dữ Liệu Thành Công!\n", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyConnect.Close();
                    }

                    frmTheLoai_Load(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi:" + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = true;
            _status = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
              if (_status == 1)
            {
                ThemDuLieu();
                frmTheLoai_Load(null,null);
                //loadData();
                //displayData();
            }
            else if (_status == 2)
            {
                SuaDuLieu();
                frmTheLoai_Load(null, null);
                //loadData();
                //displayData();
            }
        }

        private void SuaDuLieu()
        {
            try
            {
                ////
                SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                MyConnect.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.TS_TL  SET maTL=@maTL WHERE maTS =@maTS and maTL=@maTL1 ", MyConnect);
                cmd.Parameters.Add("@maTS", this.txtMaTS.Text.Trim());
                cmd.Parameters.Add("@maTL", this.cboTheLoai.SelectedValue);
                cmd.Parameters.Add("@maTL1", this.dgvDuLieu.SelectedRows[0].Cells["maTL"].Value);


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


        }
        private void ThemDuLieu()
        {
            try
            {
                ////
                SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                MyConnect.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.TS_TL( maTS ,maTL) VALUES  (@maTS, @maTL) ", MyConnect);
                cmd.Parameters.Add("@maTS", this.MaTuaSach);
                cmd.Parameters.Add("@maTL", this.cboTheLoai.SelectedValue);

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
                MessageBox.Show("Không thể thêm Dữ Liệu.\nHãy Kiểm Tra Lại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            loadData();
            displayData();
            this.bsDuLieu.Filter = "maTS LIKE '*" + this.MaTuaSach.Trim() + "*'";
            //
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;
        }

        private void frmTheLoai_Shown(object sender, EventArgs e)
        {
            bindingData();
        }

        private void dgvDuLieu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.dgvDuLieu.CurrentRow.Selected = true;
            }
            catch
            {

            }
            //this.dgvDuLieu.CurrentRow.Selected = true;
        }
    }
}
