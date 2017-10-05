using ORA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_DAL.DAL
{
    class SprintDAL
    {
        /// <summary>
        /// Basic CRUD methods for address information. ProjectDM is the model being used here.
        /// </summary>

        #region ADDRESS DAL METHODS
        public void CreateProject(SprintDM _sprint)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                    using (SqlCommand cmd = new SqlCommand("CREATE_SPRINT", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sprint_Number", _sprint.SprintNumber);
                        cmd.Parameters.AddWithValue("@Sprint_Name", _sprint.SprintName);
                        cmd.Parameters.AddWithValue("@Client_ID", _sprint.ClientId);
                        cmd.Parameters.AddWithValue("@Start_Date", _sprint.EndDate);
                        cmd.Parameters.AddWithValue("@End_Date", _sprint.StartDate);
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

        public List<SprintDM> ReadAddress()
        {
            List<SprintDM> customerList = new List<SprintDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_SPRINTS", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _sprint = new SprintDM();
                                    _sprint.SprintName = (string)reader["Sprint_Name"];
                                    _sprint.SprintNumber = (int)reader["Sprint_Number"];
                                    _sprint.StartDate = (DateTime)reader["Start_Date"];
                                    _sprint.EndDate = (DateTime)reader["End_Date"];
                                    _sprint.ClientId = (int)reader["Client_ID"];
                                    _sprint.SprintId = (int)reader["Sprint_ID"];
                                    customerList.Add(_sprint);
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

        public void UpdateAddress(SprintDM _sprint)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_SPRINT", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sprint_Name", _sprint.SprintName);
                        cmd.Parameters.AddWithValue("@Sprint_Number", _sprint.SprintNumber);
                        cmd.Parameters.AddWithValue("@Start_Date", _sprint.StartDate);
                        cmd.Parameters.AddWithValue("@End_Date", _sprint.EndDate);
                        cmd.Parameters.AddWithValue("@Client_ID", _sprint.ClientId);
                        cmd.Parameters.AddWithValue("@Sprint_ID", _sprint.SprintId);
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

        public void DeleteAddress(SprintDM _sprint)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_SPRINT", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sprint_ID", _sprint.SprintId);
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