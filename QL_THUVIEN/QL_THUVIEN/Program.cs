using QL_THUVIEN.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QL_THUVIEN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmConnectDatabase db = new frmConnectDatabase();
            db.ShowDialog();

            if (CONNECT.ConnectString.StringConnect != "")
            {
                Application.Run(new GUI.frmLogin());
            }
        }
    }
}
