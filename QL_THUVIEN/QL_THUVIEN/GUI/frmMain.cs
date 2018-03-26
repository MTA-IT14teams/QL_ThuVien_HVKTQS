using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_THUVIEN.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ucBackGround uv = new ucBackGround();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(uv);
            uv.Dock = DockStyle.Fill;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThongTinMuonTra_Click(object sender, EventArgs e)
        {
            ucThongTinMuonTra uv = new ucThongTinMuonTra();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(uv);
            uv.Dock = DockStyle.Fill;
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            ucDocGia uv = new ucDocGia();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(uv);
            uv.Dock = DockStyle.Fill;
        }

        private void btnDauSach_Click(object sender, EventArgs e)
        {
            ucDauSach uv = new ucDauSach();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(uv);
            uv.Dock = DockStyle.Fill;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain_Load(sender, e);
        }
    }
}
