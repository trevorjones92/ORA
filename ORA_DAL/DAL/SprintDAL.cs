using ORA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_SPRINT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sprint_Number", _sprint.SprintNumber);
                        cmd.Parameters.AddWithValue("@Sprint_Name", _sprint.SprintName);
                        cmd.Parameters.AddWithValue("@Client_ID", _sprint.ClientId);
                        cmd.Parameters.AddWithValue("@Start_Date", _sprint.EndDate);
                        cmd.Parameters.AddWithValue("@End_Date", _sprint.StartDate);
                        Connection.Open();
                        cmd.ExecuteNonQuery();
                        Connection.Close();
                        Connection.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public List<SprintDM> ReadAddress()
        {
            List<SprintDM> customerList = new List<SprintDM>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    Connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_SPRINTS", Connection))
                    {
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
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
                    }
                }
                return (customerList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAddress(SprintDM _sprint)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_SPRINT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sprint_Name", _sprint.SprintName);
                        cmd.Parameters.AddWithValue("@Sprint_Number", _sprint.SprintNumber);
                        cmd.Parameters.AddWithValue("@Start_Date", _sprint.StartDate);
                        cmd.Parameters.AddWithValue("@End_Date", _sprint.EndDate);
                        cmd.Parameters.AddWithValue("@Client_ID", _sprint.ClientId);
                        cmd.Parameters.AddWithValue("@Sprint_ID", _sprint.SprintId);
                        Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public void DeleteAddress(SprintDM _sprint)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_SPRINT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sprint_ID", _sprint.SprintId);
                        Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //Write to error log
                throw ex;
            }
        }
        #endregion
    }
}