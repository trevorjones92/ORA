using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class TeamsDAL
    {
        /// <summary>
        /// Basic CRUD methods for Team information. TeamDM is the model being used here.
        /// </summary>

        #region Team DAL METHODS
        public static void CreateTeam(TeamsDM _team)
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

        public static List<TeamsDM> ReadTeam()
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

        public static void UpdateTeam(TeamsDM _team)
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

        public static void DeleteTeam(TeamsDM _team)
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