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
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_WORK_STATUS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Employee_Status", _status.EmployeeStatus);
                        cmd.Parameters.AddWithValue("@Hire_Date", _status.HireDate);
                        cmd.Parameters.AddWithValue("@Pay_Type", _status.PayType);
                        cmd.Parameters.AddWithValue("@Service_Length", _status.ServiceLength);
                        cmd.Parameters.AddWithValue("@Employement_Type", _status.EmploymentType);
                        cmd.Parameters.AddWithValue("@Office_Location", _status.OfficeLocation);
                        cmd.Parameters.AddWithValue("@Termination_Date", _status.TerminationDate);
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

        public List<StatusDM> ReadAddress()
        {
            List<StatusDM> customerList = new List<StatusDM>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    Connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_WORK_STATUS", Connection))
                    {
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows) return (customerList);
                            while (reader.Read())
                            {
                                var status = new StatusDM();
                                status.EmployeeStatus = (string)reader["Employee_Status"];
                                status.HireDate = (DateTime)reader["Hire_Date"];
                                status.PayType = (string)reader["Pay_Type"];
                                status.ServiceLength = (string)reader["Service_Length"];
                                status.EmploymentType = (string)reader["Employement_Type"];
                                status.OfficeLocation = (string)reader["Office_Location"];
                                status.TerminationDate = (DateTime)reader["Termination_Date"];
                                customerList.Add(status);
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

        public void UpdateAddress(StatusDM status)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_WORK_STATUS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Employee_Status", status.EmployeeStatus);
                        cmd.Parameters.AddWithValue("@Hire_Date", status.HireDate);
                        cmd.Parameters.AddWithValue("@Pay_Type", status.PayType);
                        cmd.Parameters.AddWithValue("@Service_Length", status.ServiceLength);
                        cmd.Parameters.AddWithValue("@Employment_Type", status.EmploymentType);
                        cmd.Parameters.AddWithValue("@Office_Location", status.OfficeLocation);
                        cmd.Parameters.AddWithValue("@Termination_Date", status.TerminationDate);
                        cmd.Parameters.AddWithValue("@Work_Status_ID", status.StatusId);
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

        public void DeleteAddress(StatusDM status)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_WORK_STATUS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Work_Status_ID", status.StatusId);
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