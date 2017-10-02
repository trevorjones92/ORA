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
    class StoryDAL
    {
        /// <summary>
        /// Basic CRUD methods for address information. ProjectDM is the model being used here.
        /// </summary>

        #region ADDRESS DAL METHODS
        public void CreateProject(StoryDM _story)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_STORY", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Story_Name", _story.StoryName);
                        cmd.Parameters.AddWithValue("@Story_Number", _story.StoryNumber);
                        cmd.Parameters.AddWithValue("@Story_Start_Date", _story.StartDate);
                        cmd.Parameters.AddWithValue("@Story_End_Date", _story.EndDate);
                        cmd.Parameters.AddWithValue("@Client_ID", _story.ClientId);
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

        public List<StoryDM> ReadAddress()
        {
            List<StoryDM> customerList = new List<StoryDM>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    Connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_STORYS", Connection))
                    {
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _story = new StoryDM();
                                    _story.StoryName = (string)reader["Story_Name"];
                                    _story.StoryNumber = (int)reader["Story_Number"];
                                    _story.StartDate = (DateTime)reader["Story_Start_Date"];
                                    _story.EndDate = (DateTime)reader["Story_End_Date"];
                                    _story.ClientId = (int)reader["Client_ID"];
                                    customerList.Add(_story);
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

        public void UpdateAddress(StoryDM _story)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_STORY", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Story_Name", _story.StoryName);
                        cmd.Parameters.AddWithValue("@Story_Number", _story.StoryNumber);
                        cmd.Parameters.AddWithValue("@Story_Start_Date", _story.StartDate);
                        cmd.Parameters.AddWithValue("@Story_End_Date", _story.EndDate);
                        cmd.Parameters.AddWithValue("@Client_ID", _story.ClientId);
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

        public void DeleteAddress(StoryDM _story)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_STORY", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Story_ID", _story.StoryId);
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