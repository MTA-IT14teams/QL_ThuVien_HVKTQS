using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuVien.GUI
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        int direction = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label2.Left >= this.Width - label2.Width)
            {
                direction = -1;
                label2.ForeColor = Color.Red;
            }
               
            else
                if (label2.Left <= 0) { direction = 1; label2.ForeColor = Color.Blue; }
                

            label2.Left = label2.Left + (7 * direction);
        }

        private void Intro_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
