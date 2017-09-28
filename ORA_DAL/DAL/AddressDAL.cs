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

        public void CreateUser(AddressDM _address)
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
    }
}
