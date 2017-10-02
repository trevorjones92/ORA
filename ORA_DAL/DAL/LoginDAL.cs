using ORA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ORA_Data.DAL
{
    class LoginDAL
    {
        SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]);

        public bool Login(string email, string password)
        {
            try
            {
                bool login = false;
                using (SqlCommand command = new SqlCommand("", Connection))
                {
                    command.Parameters["Email"].Value = email;
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if ((string)reader["Email"] == email)
                                {
                                    if ((string)reader["Password"] == password)
                                    {
                                        login = true;
                                    }
                                }
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return login;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Register(string email, string password, string salt)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        command.Parameters["Email"].Value = email;
                        command.Parameters["Password"].Value = password;
                        command.Parameters["Salt"].Value = salt;
                    }
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
