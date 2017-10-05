using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ORA_DAL.Model;

namespace ORA_Data.Data
{
    public class EmployeeDAL
    {
        /// <summary>
        /// Basic CRUD methods for Employee information. EmployeeDM is the model being used here.
        /// </summary>
        /// 
        public string ConnectionString = @"Data Source=GDC-LAPTOP-148; Initial Catalog = ORATest; Integrated Security = True";
        
        #region EMPLOYEE DAL METHODS
        SqlConnection _connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]);

        //Creates the Employee in the database
        public EmployeeDM CreateEmployee(EmployeeDM employee)
        {
            try
            {
                //EmployeeDM employee = new EmployeeDM();
                using (SqlCommand command = new SqlCommand("", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters["Employee_Name"].Value = employee.EmployeeName;
                    command.Parameters["Employee_FirstName"].Value = employee.EmployeeFirstName;
                    command.Parameters["Employee_MiddleName"].Value = employee.EmployeeMiddle;
                    command.Parameters["Employee_LastName"].Value = employee.EmployeeLastName;
                    command.Parameters["Age"].Value = employee.Age;
                    command.Parameters["Birth_Date"].Value = employee.BirthDate;
                    command.Parameters["Address_ID"].Value = employee.AddressID;
                    command.Parameters["Time_ID"].Value = employee.TimeID;
                    command.Parameters["Work_Status_ID"].Value = employee.WorkStatusID;

                    command.Connection.Close();
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public EmployeeDM ReadEmployeeById(int employeeId)
        {
            try
            {
                EmployeeDM employee = new EmployeeDM();
                using (SqlCommand command = new SqlCommand("", _connection))
                {
                    command.Parameters["Employee_ID"].Value = employeeId;
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                employee.EmployeeNumber = (string)reader["Employee_ID"];
                                employee.EmployeeName = (string)reader["Employee_Name"];
                                employee.EmployeeFirstName = (string)reader["Employee_FirstName"];
                                employee.EmployeeMiddle = (string)reader["Employee_MiddleName"];
                                employee.EmployeeLastName = (string)reader["Employee_LastName"];
                                employee.Age = (int)reader["Age"];
                                employee.BirthDate = (string)reader["Birth_Date"];
                                employee.AddressID = (Int64)reader["Address_ID"];
                                employee.TimeID = (Int64)reader["Time_ID"];
                                employee.WorkStatusID = (Int64)reader["Work_Status_ID"];
                            }
                        }
                    }

                    command.Connection.Close();
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<EmployeeDM> ReadEmployee()
        {
            List<EmployeeDM> employeeList = new List<EmployeeDM>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_EMPLOYEE", connection))
                    {
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows) return (employeeList);
                            while (reader.Read())
                            {
                                var employee = new EmployeeDM
                                {
                                    EmployeeNumber = (string)reader["Employee_Number"],
                                    EmployeeName = (string)reader["Employee_Name"],
                                    EmployeeFirstName = (string)reader["Employee_FirstName"],
                                    EmployeeMiddle = (string)reader["Employee_MiddleName"],
                                    EmployeeLastName = (string)reader["Employee_LastName"],
                                    Age = (int)reader["Age"],
                                    BirthDate = (string)reader["Birth_Date"],
                                    AddressID = (Int64)reader["Address_ID"],
                                    TimeID = (Int64)reader["Time_ID"],
                                    WorkStatusID = (Int64)reader["Work_Status_ID"]
                                };
                                employeeList.Add(employee);
                            }
                        }
                    }
                }
                return (employeeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee(EmployeeDM employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_EMPLOYEE", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Employee_ID", employee.EmployeeId);
                        cmd.Parameters.AddWithValue("@Employee_Name", employee.EmployeeName);
                        cmd.Parameters.AddWithValue("@Employee_First_Name", employee.EmployeeFirstName);
                        cmd.Parameters.AddWithValue("@Employee_Middle", employee.EmployeeMiddle);
                        cmd.Parameters.AddWithValue("@Employee_Last_Name", employee.EmployeeLastName);
                        cmd.Parameters.AddWithValue("@Age", employee.Age);
                        cmd.Parameters.AddWithValue("@Birth_Date", employee.BirthDate);
                        cmd.Parameters.AddWithValue("@Address_ID", employee.AddressID);
                        cmd.Parameters.AddWithValue("@Time_ID", employee.TimeID);
                        cmd.Parameters.AddWithValue("@Work_Status_ID", employee.WorkStatusID);
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

        public void DeleteEmployee(EmployeeDM employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_EMPLOYEE", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Employee_ID", employee.EmployeeId);
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