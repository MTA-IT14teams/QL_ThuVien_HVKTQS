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
    public partial class frmTacGia : Form
    {
        public frmTacGia(string mts)
        {
            this.MaTS = mts;
            InitializeComponent();
        }
        //bien
        private string MaTS = "";
        //
        private byte _status = 0;
        //
        private DataTable dtTacGia = new DataTable();
        private DataTable dtDuLieu = new DataTable();
        //
        DataView dvDuLieu = new DataView();
        DataView dvTuaSach = new DataView();
        DataView dvTacGia = new DataView();
        //bin
        BindingSource bsDuLieu = new BindingSource();


        private void loadData()
        {
            try
            {
                SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                MyConnect.Open();
               
                SqlCommand cmd = new SqlCommand("select maTG,tenTG from TacGia", MyConnect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                this.dtTacGia.Clear();
                da.Fill(dtTacGia);
                //fill data into TuaSach
                        //                --view tua sach-tacgia
                        //CREATE VIEW v_TuaSach_TG AS
                        //SELECT ts.maTS,ts.tenTS,v_tg.maTG,v_tg.tenTG
                        //FROM dbo.TuaSach ts
                        //INNER JOIN (SELECT v.maTS, v.maTG, tg.tenTG FROM dbo.Viet v, dbo.TacGia tg WHERE v.maTG = tg.maTG) v_tg
                        //  ON v_tg.maTS = ts.maTS
                        //GO

                        //SELECT* FROM dbo.v_TuaSach_TG
                        //GO
                cmd = new SqlCommand("SELECT* FROM dbo.v_TuaSach_TG", MyConnect);
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
            //try
            //{
                dvDuLieu = new DataView(dtDuLieu);
                dvTacGia = new DataView(dtTacGia);
                //
                this.bsDuLieu.DataSource = dvDuLieu;
                bnChucNang.BindingSource = bsDuLieu;
                dgvDulieu.DataSource = bsDuLieu;
                //

                this.cboTacGia.DataSource = dvTacGia;
                this.cboTacGia.ValueMember = "maTG";
                this.cboTacGia.DisplayMember = "tenTG";

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Don't display data.\nERROR:" + ex.Message);
            //}



        }

       private void bindingData()
        {
            this.txtMaTS.DataBindings.Add("Text", this.dgvDulieu.DataSource, "maTS", true, DataSourceUpdateMode.Never);
            this.txtTenTuaSach.DataBindings.Add("Text", this.dgvDulieu.DataSource, "tenTS", true, DataSourceUpdateMode.Never);
            this.cboTacGia.DataBindings.Add("SelectedValue", this.dgvDulieu.DataSource,"maTG",true, DataSourceUpdateMode.Never);
            this.cboTacGia.DataBindings.Add("Text", this.dgvDulieu.DataSource, "tenTG", true, DataSourceUpdateMode.Never);
        
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                this.Dispose();
            }

        }

        private void SuaDuLieu()
        {
            try
            {
                ////
                SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                MyConnect.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.Viet  SET maTG=@maTG WHERE maTS =@maTS and maTG=@maTG1 ", MyConnect);
                cmd.Parameters.Add("@maTS", this.txtMaTS.Text.Trim());
                cmd.Parameters.Add("@maTG", this.cboTacGia.SelectedValue);
                cmd.Parameters.Add("@maTG1", this.dgvDulieu.SelectedRows[0].Cells["maTG"].Value);


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
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Viet( maTS ,maTG) VALUES  (@maTS, @maTG) ", MyConnect);
                cmd.Parameters.Add("@maTS", this.txtMaTS.Text.Trim());
                cmd.Parameters.Add("@maTG", this.cboTacGia.SelectedValue);
               
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
                MessageBox.Show("Không thể thêm Dữ Liệu.\nHãy Kiểm Tra Lại!\n"+ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _status = 1;//them
            ////
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            
            ActiveControl = cboTacGia;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _status = 2;//them
            ////
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            ActiveControl = cboTacGia;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn xóa?","Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                    MyConnect.Open();
                    SqlCommand cmd = new SqlCommand("DELETE dbo.viet WHERE maTS = @maTS and maTG = @maTG", MyConnect);
                    cmd.Parameters.Add("@maTS", this.txtMaTS.Text.Trim());
                    cmd.Parameters.Add("@maTG", this.cboTacGia.SelectedValue);
                    
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
                    frmTacGia_Load(null,null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi:" + ex.Message);
                }
            }
          
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_status == 1)
            {
                ThemDuLieu();
                frmTacGia_Load(null, null);
                //loadData();
                //displayData();
            }
            else if (_status == 2)
            {
                SuaDuLieu();
                frmTacGia_Load(null, null);
                //loadData();
                //displayData();
            }
        }

        private void dgvDulieu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.dgvDulieu.CurrentRow.Selected = true;
            }
            catch
            {

            }

          // this.dgvDulieu.CurrentRow.Selected = true;
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

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            loadData();
            displayData();
            this.bsDuLieu.Filter = "maTS LIKE '*" + this.MaTS.Trim() + "*'";
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;
        }

        private void frmTacGia_Shown(object sender, EventArgs e)
        {
            bindingData();
        }
    }
}
