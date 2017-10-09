using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ORA_Data.Model;

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
                using (SqlCommand command = new SqlCommand("READ_EMPLOYEE_BY_ID", SqlConnect.Connection))
                {
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Employee_ID", employeeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                employee.EmployeeId = (Int64)reader["Employee_ID"];
                                employee.EmployeeNumber = (string)reader["Employee_Number"];
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
            finally
            {
                SqlConnect.Connection.Close();
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
                            AddressDM address = new AddressDM();
                            EmployeeTimeDM EmployeeTime = new EmployeeTimeDM();
                            PositionsDM position = new PositionsDM();
                            StatusDM Status = new StatusDM();
                            #region Pulling Employee Table Information
                            employee.EmployeeId = (Int64)reader["Employee_ID"];
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
                            #endregion

                            #region Pulling Address Table Information
                            address.Address = (string)reader["Address"];
                            address.City = (string)reader["City"];
                            address.State = (string)reader["State"];
                            address.Country = (string)reader["Country"];
                            address.Zip_Code = (int)reader["Zip_Code"];
                            address.Phone = (string)reader["Phone"];
                            address.Email = (string)reader["Email"];
                            #endregion

                            #region Pulls Employee Time Table Information
                            EmployeeTime.Other_Total = (decimal)reader["Other_Total"];
                            EmployeeTime.Other_Available = (decimal)reader["Other_Available"];
                            EmployeeTime.Other_Used = (decimal)reader["Other_Used"];
                            EmployeeTime.Payed_Total = (decimal)reader["Payed_Total"];
                            EmployeeTime.Payed_Used = (decimal)reader["Payed_Total"];
                            #endregion

                            #region Pulls Employee Work Status Information

                            Status.EmployeeStatus = (string) reader["Employee_Status"];
                            Status.HireDate = (DateTime) reader["Hire_Date"];
                            Status.PayType = (string) reader["Pay_Type"];
                            Status.ServiceLength = (string) reader["Service_Length"];
                            Status.EmploymentType = (string) reader["Employment_Type"];
                            Status.OfficeLocation = (string) reader["Office_Location"];
                            if (reader["Termination_Date"] != DBNull.Value)
                                Status.TerminationDate = (DateTime) reader["Termination_Date"];
                            #endregion

                            //Adding the object properties to the employment object to be used together for the view modal
                            employee.address = address; employee.EmployeeTime = EmployeeTime; employee.Status = Status;

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
                    cmd.Parameters.AddWithValue("@Employee_Number", employee.EmployeeNumber);
                    cmd.Parameters.AddWithValue("@Employee_Name", employee.EmployeeName);
                    cmd.Parameters.AddWithValue("@Employee_FirstName", employee.EmployeeFirstName);
                    cmd.Parameters.AddWithValue("@Employee_MiddleName", employee.EmployeeMiddle);
                    cmd.Parameters.AddWithValue("@Employee_LastName", employee.EmployeeLastName);
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