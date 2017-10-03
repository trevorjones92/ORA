using ORA_Data.Model;
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
        /// <summary>
        /// Basic methods for Logging in and Registering information.
        /// </summary>
        /// 

        #region LOGIN DAL METHODS

        SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]);

        public bool Login(LoginDM login)
        {
            try
            {
                bool loggedIN = false;
                using (SqlCommand command = new SqlCommand("", Connection))
                {
                    command.Parameters["Email"].Value = login.Email;
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if ((string)reader["Email"] == login.Email)
                                {
                                    if ((string)reader["Password"] == login.Password)
                                    {
                                        loggedIN = true;
                                    }
                                }
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return loggedIN;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Register(LoginDM login)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        command.Parameters["Email"].Value = login.Email;
                        command.Parameters["Password"].Value = login.Password;
                        command.Parameters["Salt"].Value = login.Salt;
                    }
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion
    }
}
