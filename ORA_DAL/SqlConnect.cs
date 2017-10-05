using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA_Data
{
    public class SqlConnect
    {
        public static SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]);
    }
}
