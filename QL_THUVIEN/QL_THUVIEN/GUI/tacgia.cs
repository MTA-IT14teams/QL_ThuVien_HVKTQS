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
    public partial class tacgia : Form
    {
        public tacgia()
        {
            InitializeComponent();
        }

        private DataTable dtTuaSach = new DataTable();
        private DataTable dtTacGia = new DataTable();
        private DataTable dtDuLieu = new DataTable();

        //
        DataView dvDuLieu = new DataView();
        DataView dvTuaSach = new DataView();
        DataView dvTacGia = new DataView();



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

                cmd = new SqlCommand("select ts.maTS, ts.tenTS, tg.maTG, tg.tenTG from TuaSach ts, TacGia tg, Viet v where ts.maTS= v.maTS and v.maTG= tg.maTG ", MyConnect);
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
                dvTuaSach = new DataView(dtTuaSach);
                dvTacGia = new DataView(dtTacGia);




            }
            catch (Exception ex)
            {
                MessageBox.Show("Don't display data.\nERROR:" + ex.Message);
            }



        }
    }
}
