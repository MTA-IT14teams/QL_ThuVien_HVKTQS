using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QL_THUVIEN.CONNECT
{
    class Connect
    {
        public static SqlConnection myconnect = new SqlConnection(CONNECT.ConnectString.StringConnect);

        public static void openConnect()
        {
            myconnect.Open();
        }

        public static void closeConnect()
        {
            myconnect.Close();
        }
    }
}
