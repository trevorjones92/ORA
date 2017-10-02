using ORA.Models;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ORA_DAL.DAL
{
    /// <summary>
    /// Basic CRUD methods for Client information. ClientsDM is the model being used here.
    /// </summary>
    /// 

    #region CLIENTS DAL METHODS

    public class ClientsDAL
    {
        public void CreateClient(ClientsDM _client)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_ADDRESS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Client_Name", _client.ClientName);
                        cmd.Parameters.AddWithValue("@Client_Abbreviation", _client.ClientAbbreviation);
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

        public List<ClientsDM> ReadClient()
        {
            List<ClientsDM> _clientList = new List<ClientsDM>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    Connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_CLIENT", Connection))
                    {
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _client = new ClientsDM();
                                    _client.ClientName = (string)reader["Client_Name"];
                                    _client.ClientAbbreviation = (string)reader["Client_Abbreviation"];
                                    _clientList.Add(_client);
                                }
                            }
                        }
                    }
                }
                return (_clientList);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public void UpdateClient(ClientsDM _client)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_CLIENT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Client_ID", _client.ClientId);
                        cmd.Parameters.AddWithValue("@Client_Name", _client.ClientName);
                        cmd.Parameters.AddWithValue("@Client_Abbreviation", _client.ClientAbbreviation);
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

        public void DeleteClient(ClientsDM _client)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_CLIENT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Client_ID", _client.ClientId);
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
    }

    #endregion
}
