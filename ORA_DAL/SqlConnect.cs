using System.Configuration;
using System.Data.SqlClient;

namespace ORA_DAL
{
    public class SqlConnect
    {
        public static SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]);
    }
}
