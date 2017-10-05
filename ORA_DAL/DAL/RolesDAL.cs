using ORA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ORA_Data;

namespace ORA_DAL.DAL
{
    class RolesDAL
    {
        /// <summary>
        /// Basic CRUD methods for address information. ProjectDM is the model being used here.
        /// </summary>

        #region ADDRESS DAL METHODS
        //public SqlSqlConnect.Connection SqlConnect.Connection = new SqlSqlConnect.Connection(ConfigurationManager.AppSettings["SQLSqlConnect.Connection"]);

        public void CreateProject(RolesDM _role)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                    using (SqlCommand cmd = new SqlCommand("CREATE_ROLE", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Role_Name", _role.RoleName);
                        cmd.Parameters.AddWithValue("@Role_Description", _role.RoleDescription);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                    }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public List<RolesDM> ReadAddress()
        {
            List<RolesDM> customerList = new List<RolesDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_ROLES", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                SqlConnect.Connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _role = new RolesDM();
                                    _role.RoleName = (string)reader["Role_Name"];
                                    _role.RoleDescription = (string)reader["Role_Description"];
                                    _role.RoleId = (int)reader["Role_ID"];
                                    customerList.Add(_role);
                                }
                            }
                    }
                    SqlConnect.Connection.Close();
                }
                return (customerList);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                throw ex;
            }
        }

        public void UpdateAddress(RolesDM _role)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_ROLE", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Role_Name", _role.RoleName);
                        cmd.Parameters.AddWithValue("@Role_Number", _role.RoleDescription);
                        cmd.Parameters.AddWithValue("@Role_ID", _role.RoleId);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public void DeleteAddress(RolesDM _role)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_ROLE", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Role_ID", _role.RoleId);
                        SqlConnect.Connection.Open();
                        cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                //Write to error log
                throw ex;
            }
        }
        #endregion
    }
}