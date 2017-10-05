using ORA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class TeamsDAL
    {
        /// <summary>
        /// Basic CRUD methods for address information. ProjectDM is the model being used here.
        /// </summary>

        #region ADDRESS DAL METHODS
        public void CreateProject(TeamsDM _team)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                    using (SqlCommand cmd = new SqlCommand("CREATE_TEAM", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Team_Name", _team.TeamName);
                        cmd.Parameters.AddWithValue("@Client_ID", _team.ClientId);
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

        public List<TeamsDM> ReadAddress()
        {
            List<TeamsDM> customerList = new List<TeamsDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_TEAMS", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _team = new TeamsDM();
                                    _team.TeamName = (string)reader["Team_Name"];
                                    _team.TeamId = (int)reader["Team_ID"];
                                    _team.ClientId = (int)reader["Client_ID"];
                                    customerList.Add(_team);
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

        public void UpdateAddress(TeamsDM _team)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_TEAM", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Team_Name", _team.TeamName);
                        cmd.Parameters.AddWithValue("@Team_ID", _team.TeamId);
                        cmd.Parameters.AddWithValue("@Client_ID", _team.ClientId);
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

        public void DeleteAddress(TeamsDM _team)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_TEAM", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Team_ID", _team.TeamId);
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