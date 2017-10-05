using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ORA_DAL.Model;
using ORA_DAL;

namespace ORA_Data.Data
{
    public class EmployeeDAL
    {
        /// <summary>
        /// Basic CRUD methods for Employee information. EmployeeDM is the model being used here.
        /// </summary>
        /// 

        #region EMPLOYEE DAL METHODS

        //Creates the Employee in the database
        public void CreateEmployee(EmployeeDM employee)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("CREATE_EMPLOYEE", SqlConnect.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Employee_Number", employee.EmployeeNumber);
                    command.Parameters.AddWithValue("@Employee_Name", employee.EmployeeName);
                    command.Parameters.AddWithValue("@Employee_FirstName", employee.EmployeeFirstName);
                    command.Parameters.AddWithValue("@Employee_MiddleName", employee.EmployeeMiddle);
                    command.Parameters.AddWithValue("@Employee_LastName", employee.EmployeeLastName);
                    command.Parameters.AddWithValue("@Age", employee.Age);
                    command.Parameters.AddWithValue("@Birth_Date", employee.BirthDate);
                    command.Parameters.AddWithValue("@Address_ID", employee.AddressID);
                    command.Parameters.AddWithValue("@Time_ID", employee.TimeID);
                    command.Parameters.AddWithValue("@Work_Status_ID", employee.WorkStatusID);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
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

        public EmployeeDM ReadEmployeeById(int employeeId)
        {
            try
            {
                EmployeeDM employee = new EmployeeDM();
                using (SqlCommand command = new SqlCommand("", SqlConnect.Connection))
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
                                employee.AddressID = (int)reader["Address_ID"];
                                employee.TimeID = (int)reader["Time_ID"];
                                employee.WorkStatusID = (int)reader["Work_Status_ID"];
                            }
                        }
                    }

                    command.Connection.Close();
                }
                return employee;
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                throw (ex);
            }
        }

        public List<EmployeeDM> ReadEmployees()
        {
            List<EmployeeDM> employeeList = new List<EmployeeDM>();
            try
            {
                SqlConnect.Connection.Open();
                using (SqlCommand cmd = new SqlCommand("READ_EMPLOYEES", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return (employeeList);
                        while (reader.Read())
                        {
                            EmployeeDM employee = new EmployeeDM();
                            employee.EmployeeNumber = (string)reader["Employee_Number"];
                            employee.EmployeeName = (string)reader["Employee_Name"];
                            employee.EmployeeFirstName = (string)reader["Employee_FirstName"];
                            employee.EmployeeMiddle = (string)reader["Employee_MiddleName"];
                            employee.EmployeeLastName = (string)reader["Employee_LastName"];
                            employee.Age = (int)reader["Age"];
                            employee.BirthDate = (string)reader["Birth_Date"];
                            if (reader["Address_ID"] != DBNull.Value)
                                employee.AddressID = (Int64)reader["Address_ID"];
                            if (reader["Time_ID"] != DBNull.Value)
                                employee.TimeID = (Int64)reader["Time_ID"];
                            if (reader["Work_Status_ID"] != DBNull.Value)
                                employee.WorkStatusID = (Int64)reader["Work_Status_ID"];
                            employeeList.Add(employee);
                        }
                    }
                    cmd.Connection.Close();
                }
                return (employeeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnect.Connection.Close();
            }
        }

        public void UpdateEmployee(EmployeeDM employee)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_EMPLOYEE", SqlConnect.Connection))
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

        public void DeleteEmployee(EmployeeDM employee)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_EMPLOYEE", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", employee.EmployeeId);
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