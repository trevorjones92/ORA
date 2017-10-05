using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ORA_DAL.DAL
{
    class Work_StatusDAL
    {
        /// <summary>
        /// Basic CRUD methods for address information. ProjectDM is the model being used here.
        /// </summary>

        #region ADDRESS DAL METHODS
        public void CreateProject(StatusDM _status)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                    using (SqlCommand cmd = new SqlCommand("CREATE_WORK_STATUS", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Employee_Status", _status.EmployeeStatus);
                        cmd.Parameters.AddWithValue("@Hire_Date", _status.HireDate);
                        cmd.Parameters.AddWithValue("@Pay_Type", _status.PayType);
                        cmd.Parameters.AddWithValue("@Service_Length", _status.ServiceLength);
                        cmd.Parameters.AddWithValue("@Employement_Type", _status.EmploymentType);
                        cmd.Parameters.AddWithValue("@Office_Location", _status.OfficeLocation);
                        cmd.Parameters.AddWithValue("@Termination_Date", _status.TerminationDate);
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

        public List<StatusDM> ReadAddress()
        {
            List<StatusDM> customerList = new List<StatusDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_WORK_STATUS", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _status = new StatusDM();
                                    _status.EmployeeStatus = (string)reader["Employee_Status"];
                                    _status.HireDate = (DateTime)reader["Hire_Date"];
                                    _status.PayType = (string)reader["Pay_Type"];
                                    _status.ServiceLength = (string)reader["Service_Length"];
                                    _status.EmploymentType = (string)reader["Employement_Type"];
                                    _status.OfficeLocation = (string)reader["Office_Location"];
                                    _status.TerminationDate = (DateTime)reader["Termination_Date"];
                                    customerList.Add(_status);
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

        public void UpdateAddress(StatusDM _status)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_WORK_STATUS", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Employee_Status", _status.EmployeeStatus);
                        cmd.Parameters.AddWithValue("@Hire_Date", _status.HireDate);
                        cmd.Parameters.AddWithValue("@Pay_Type", _status.PayType);
                        cmd.Parameters.AddWithValue("@Service_Length", _status.ServiceLength);
                        cmd.Parameters.AddWithValue("@Employment_Type", _status.EmploymentType);
                        cmd.Parameters.AddWithValue("@Office_Location", _status.OfficeLocation);
                        cmd.Parameters.AddWithValue("@Termination_Date", _status.TerminationDate);
                        cmd.Parameters.AddWithValue("@Work_Status_ID", _status.StatusId);
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

        public void DeleteAddress(StatusDM _status)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_WORK_STATUS", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Work_Status_ID", _status.StatusId);
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