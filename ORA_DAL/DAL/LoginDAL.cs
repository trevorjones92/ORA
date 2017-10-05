using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class LoginDAL
    {
        /// <summary>
        /// Basic methods for Logging in and Registering information.
        /// </summary>
        /// 

        #region LOGIN DAL METHODS

        static SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]);

        public static bool Login(LoginDM login)
        {
            try
            {
                bool loggedIN = false;
                using (SqlCommand command = new SqlCommand("READ_LOGIN_BY_EMAIL", Connection))
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("Email",login.Email);
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if ((string)reader["Email"] == login.Email)
                                {
                                    if ((string)reader["Password"] == ORA_Data.Hash.GetHash(login.Password + (string)reader["Salt"]))
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

        public static void Register(LoginDM login)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("CREATE_LOGIN", Connection))
                {
                    command.Parameters.AddWithValue("@Email",login.Email);
                    command.Parameters.AddWithValue("@Password",login.Password);
                    command.Parameters.AddWithValue("@Salt",login.Salt);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public List<LoginDM> ViewLoginEmails(List<LoginDM> logins)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("READ_LOGINS", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                LoginDM login = new LoginDM { Email = (string)reader["Email"] };
                                logins.Add(login);
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return logins;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteLogin(LoginDM login)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_LOGIN", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", login.Email);
                        Connection.Open();
                        cmd.ExecuteNonQuery();
                        Connection.Close();
                    }
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
