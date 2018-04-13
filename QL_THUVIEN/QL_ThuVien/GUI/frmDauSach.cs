﻿using System;
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

        private DataTable dtTuaSach = new DataTable();
        private DataTable dtTacGia = new DataTable();
        private DataTable dtDuLieu = new DataTable();
        private DataTable dtNXB = new DataTable();
        //
        DataView dvDuLieu = new DataView();
        DataView dvTuaSach = new DataView();
        DataView dvTacGia = new DataView();
        DataView dvNXB = new DataView();


        private void loadData()
        {
            try
            {
                SqlConnection MyConnect = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                MyConnect.Open();
                SqlCommand cmd = new SqlCommand("select * from tblTuaSach", MyConnect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                this.dtTuaSach.Clear();
                da.Fill(dtTuaSach);
                //fill data into TacGia
                cmd = new SqlCommand("select * from tblTacGia", MyConnect);
                da = new SqlDataAdapter(cmd);
                this.dtTacGia.Clear();
                da.Fill(dtTacGia);
                //fill data into TuaSach
              
                cmd = new SqlCommand("select ts.maTS, ts.TenTS ,ts.namXB, ts.Gia, ts.viTri, ts.noiDungTT, ts.nnChinh ,tg.tenTG, nxb.tenNXB from TuaSach ts , Viet v , TacGia tg , NXB nxb where  tg.maTG = v.maTG and ts.maTS=v.maTS ", MyConnect);
                da = new SqlDataAdapter(cmd);
                this.dtDuLieu.Clear();
                da.Fill(dtDuLieu);
                //fill data into NXB
                cmd = new SqlCommand("Select * from tblNXB", MyConnect);
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
                
                dgvTS.DataSource = dvDuLieu;


                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Don't display data.\nERROR:" + ex.Message);
            }



        }
        private void bindingData()
        {
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

        }

       
    }
}
