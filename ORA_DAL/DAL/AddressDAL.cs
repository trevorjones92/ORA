using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class AddressDAL
    {
        /// <summary>
        /// Basic CRUD methods for address information. AddressDM is the model being used here.
        /// </summary>

        #region ADDRESS DAL METHODS
        public static void CreateAddress(AddressDM address)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlCommand cmd = new SqlCommand("CREATE_ADDRESS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Address", address.Address);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@State", address.State);
                    cmd.Parameters.AddWithValue("@Zip_Code", address.Zip_Code);
                    cmd.Parameters.AddWithValue("@Country", address.Country);
                    cmd.Parameters.AddWithValue("@Phone", address.Phone);
                    cmd.Parameters.AddWithValue("@Email", address.Email);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw e;
            }
        }

        public static List<AddressDM> ReadAllAddress()
        {
            List<AddressDM> addressList = new List<AddressDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_ADDRESS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return (addressList);
                        while (reader.Read())
                        {
                            AddressDM address = new AddressDM
                            {
                                Address_ID = (Int64)reader["Address_ID"],
                                Address = (string)reader["Address"],
                                City = (string)reader["City"],
                                State = (string)reader["State"],
                                Zip_Code = (int)reader["Zip_Code"],
                                Country = (string)reader["Country"],
                                Phone = (string)reader["Phone"],
                                Email = (string)reader["Email"]
                            };
                            addressList.Add(address);
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (addressList);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                throw ex;
            }
        }

        public static AddressDM ReadAddressById(Int64 addressId)
        {
            try
            {
                AddressDM address = new AddressDM();
                using (SqlCommand command = new SqlCommand("READ_ADDRESS_BY_ID", SqlConnect.Connection))
                {
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Address_ID", addressId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                address.Address_ID = (Int64)reader["Address_ID"];
                                address.Address = (string)reader["Address"];
                                address.City = (string)reader["City"];
                                address.State = (string)reader["State"];
                                address.Zip_Code = (int)reader["Zip_Code"];
                                address.Country = (string)reader["Country"];
                                address.Phone = (string)reader["Phone"];
                                address.Email = (string)reader["Email"];
                            }
                        }
                    }
                    command.Connection.Close();
                }
                return address;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        public static void UpdateAddress(AddressDM address)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_ADDRESS", SqlConnect.Connection))
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

        public static void DeleteAddress(AddressDM address)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_ADDRESS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Address_ID", address.Address_ID);
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
