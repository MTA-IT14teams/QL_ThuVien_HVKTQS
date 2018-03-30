using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace QL_ThuVien
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

            string sname="";
            string dbname= "";
            string uname ="";
            string pass = "";

            if (!File.Exists("config"))
            {
                Application.Run(new GUI.frmConnectDatabase());
            }
            else
            {
                using (StreamReader read = new StreamReader("config"))
                {
                    sname = read.ReadLine();
                    dbname = read.ReadLine();
                    uname = read.ReadLine();
                    pass = read.ReadLine();
                }

                DTO.ConnectDatabase.SeverName = sname;
                DTO.ConnectDatabase.DatabaseName = dbname;
                
                if (uname == null)
                {
                    DTO.ConnectDatabase.WindowAuthentication = true;
                    //DTO.ConnectDatabase.TaoChuoiKetNoi();
                }
                else
                {
                    DTO.ConnectDatabase.WindowAuthentication = true; 
                }
                DTO.ConnectDatabase.TaoChuoiKetNoi();

                try 
                {
                    SqlConnection conn = new SqlConnection(DTO.ConnectDatabase.ConnectionString);
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        GUI.frmLogin lg = new GUI.frmLogin();
                        lg.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra lại kết nối đến CSDL");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }









            Application.Run(new GUI.frmConnectDatabase());
        }
    }
}
