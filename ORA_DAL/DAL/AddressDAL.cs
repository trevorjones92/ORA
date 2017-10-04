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

namespace ORA_Data
{
    class AddressDal
    {
        /// <summary>
        /// Basic CRUD methods for address information. AddressDM is the model being used here.
        /// </summary>
        
        #region ADDRESS DAL METHODS
        public void CreateAddress(AddressDM address)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_ADDRESS", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Address", address.Address);
                        cmd.Parameters.AddWithValue("@City", address.City);
                        cmd.Parameters.AddWithValue("@State", address.State);
                        cmd.Parameters.AddWithValue("@Zip_Code", address.Zip_Code);
                        cmd.Parameters.AddWithValue("@Country", address.Country);
                        cmd.Parameters.AddWithValue("@Phone", address.Phone);
                        cmd.Parameters.AddWithValue("@Email", address.Email);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AddressDM> ReadAddress()
        {
            List<AddressDM> addressList = new List<AddressDM>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_ADDRESS", connection))
                    {
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows) return (addressList);
                            while (reader.Read())
                            {
                                var address = new AddressDM
                                {
                                    Address = (string) reader["Address"],
                                    City = (string) reader["City"],
                                    State = (string) reader["State"],
                                    Zip_Code = (int) reader["Zip_Code"],
                                    Country = (string) reader["Country"],
                                    Phone = (string) reader["Phone"],
                                    Email = (string) reader["Email"]
                                };
                                addressList.Add(address);
                            }
                        }
                    }
                }
                return (addressList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAddress(AddressDM address)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_ADDRESS", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Address_ID", address.Address_ID);
                        cmd.Parameters.AddWithValue("@Address", address.Address);
                        cmd.Parameters.AddWithValue("@FirstName", address.City);
                        cmd.Parameters.AddWithValue("@LastName", address.State);
                        cmd.Parameters.AddWithValue("@DoB", address.Zip_Code);
                        cmd.Parameters.AddWithValue("@PhoneNumber", address.Country);
                        cmd.Parameters.AddWithValue("@UserName", address.Phone);
                        cmd.Parameters.AddWithValue("@Password", address.Email);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public void DeleteAddress(AddressDM address)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_ADDRESS", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Address_ID", address.Address_ID);
                        connection.Open();
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
