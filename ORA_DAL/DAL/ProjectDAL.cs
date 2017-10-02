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
    class ProjectDAL
    {
        /// <summary>
        /// Basic CRUD methods for address information. ProjectDM is the model being used here.
        /// </summary>

        #region ADDRESS DAL METHODS
        public void CreateProject(ProjectDM _project)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_PROJECT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Project_Name", _project.ProjectName);
                        cmd.Parameters.AddWithValue("@Project_Number", _project.ProjectNumber);
                        cmd.Parameters.AddWithValue("@Project_Start_Date", _project.StartDate);
                        cmd.Parameters.AddWithValue("@Project_End_Date", _project.EndDate);
                        cmd.Parameters.AddWithValue("@Client_ID", _project.ClientId);
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

        public List<ProjectDM> ReadAddress()
        {
            List<ProjectDM> customerList = new List<ProjectDM>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    Connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_PROJECTS", Connection))
                    {
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _project = new ProjectDM();
                                    _project.ProjectName = (string)reader["Project_Name"];
                                    _project.ProjectNumber = (int)reader["Project_Number"];
                                    _project.StartDate = (DateTime)reader["Project_Start_Date"];
                                    _project.EndDate = (DateTime)reader["Project_End_Date"];
                                    _project.ClientId = (int)reader["Client_ID"];
                                    customerList.Add(_project);
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

        public void UpdateAddress(ProjectDM _project)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_PROJECT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Project_Name", _project.ProjectName);
                        cmd.Parameters.AddWithValue("@Project_Number", _project.ProjectNumber);
                        cmd.Parameters.AddWithValue("@Project_Start_Date", _project.StartDate);
                        cmd.Parameters.AddWithValue("@Project_End_Date", _project.EndDate);
                        cmd.Parameters.AddWithValue("@Client_ID", _project.ClientId);
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

        public void DeleteAddress(ProjectDM _project)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_ADDRESS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Project_ID", _project.ProjectId);
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