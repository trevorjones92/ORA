using ORA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class StoryDAL
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
                    using (SqlCommand cmd = new SqlCommand("CREATE_STORY", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Story_Name", _story.StoryName);
                        cmd.Parameters.AddWithValue("@Story_Number", _story.StoryNumber);
                        cmd.Parameters.AddWithValue("@Story_Start_Date", _story.StartDate);
                        cmd.Parameters.AddWithValue("@Story_End_Date", _story.EndDate);
                        cmd.Parameters.AddWithValue("@Client_ID", _story.ClientId);
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

        public List<StoryDM> ReadAddress()
        {
            List<StoryDM> customerList = new List<StoryDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_STORYS", SqlConnect.Connection))
                    {
                    SqlConnect.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _story = new StoryDM();
                                    _story.StoryId = (int)reader["Story_ID"];
                                    _story.StoryName = (string)reader["Story_Name"];
                                    _story.StoryNumber = (int)reader["Story_Number"];
                                    _story.StartDate = (DateTime)reader["Story_Start_Date"];
                                    _story.EndDate = (DateTime)reader["Story_End_Date"];
                                    _story.ClientId = (int)reader["Client_ID"];
                                    customerList.Add(_story);
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

        public void UpdateAddress(StoryDM _story)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_STORY", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Story_ID", _story.StoryId);
                        cmd.Parameters.AddWithValue("@Story_Name", _story.StoryName);
                        cmd.Parameters.AddWithValue("@Story_Number", _story.StoryNumber);
                        cmd.Parameters.AddWithValue("@Story_Start_Date", _story.StartDate);
                        cmd.Parameters.AddWithValue("@Story_End_Date", _story.EndDate);
                        cmd.Parameters.AddWithValue("@Client_ID", _story.ClientId);
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

        public void DeleteAddress(StoryDM _story)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_STORY", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Story_ID", _story.StoryId);
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