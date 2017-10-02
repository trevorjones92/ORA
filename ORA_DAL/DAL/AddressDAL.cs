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
    class AddressDAL
    {
        /// <summary>
        /// Basic CRUD methods for address information. AddressDM is the model being used here.
        /// </summary>
        
        #region ADDRESS DAL METHODS
        public void CreateAddress(AddressDM _address)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_ADDRESS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Address", _address.Address);
                        cmd.Parameters.AddWithValue("@City", _address.City);
                        cmd.Parameters.AddWithValue("@State", _address.State);
                        cmd.Parameters.AddWithValue("@Zip_Code", _address.Zip_Code);
                        cmd.Parameters.AddWithValue("@Country", _address.Country);
                        cmd.Parameters.AddWithValue("@Phone", _address.Phone);
                        cmd.Parameters.AddWithValue("@Email", _address.Email);
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

        public List<AddressDM> ReadAddress()
        {
            List<AddressDM> addressList = new List<AddressDM>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    Connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_ADDRESS", Connection))
                    {
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _address = new AddressDM();
                                    _address.Address = (string)reader["Address"];
                                    _address.City = (string)reader["City"];
                                    _address.State = (string)reader["State"];
                                    _address.Zip_Code = (int)reader["Zip_Code"];
                                    _address.Country = (string)reader["Country"];
                                    _address.Phone = (string)reader["Phone"];
                                    _address.Email = (string)reader["Email"];
                                    addressList.Add(_address);
                                }
                            }
                        }
                    }
                }
                return (addressList);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void UpdateAddress(AddressDM _address)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_ADDRESS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Address_ID", _address.Address_ID);
                        cmd.Parameters.AddWithValue("@Address", _address.Address);
                        cmd.Parameters.AddWithValue("@FirstName", _address.City);
                        cmd.Parameters.AddWithValue("@LastName", _address.State);
                        cmd.Parameters.AddWithValue("@DoB", _address.Zip_Code);
                        cmd.Parameters.AddWithValue("@PhoneNumber", _address.Country);
                        cmd.Parameters.AddWithValue("@UserName", _address.Phone);
                        cmd.Parameters.AddWithValue("@Password", _address.Email);
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

        public void DeleteAddress(AddressDM _address)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_ADDRESS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Address_ID", _address.Address_ID);
                        Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                //Write to error log
            }
        }
        #endregion
    }
}
