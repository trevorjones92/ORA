using ORA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ORA_Data.Data
{
    public class UserData
    {

        SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]);

        private static RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();

        //Creates the Employee in the database
        public EmployeeDM CreateEmployee(EmployeeDM employee)
        {
            try
            {
                //EmployeeDM employee = new EmployeeDM();
                using (SqlCommand command = new SqlCommand("", Connection))
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

        public EmployeeDM ReadEmployeeByID(int employeeID)
        {
            try
            {
                EmployeeDM employee = new EmployeeDM();
                using (SqlCommand command = new SqlCommand("", Connection))
                {
                    command.Parameters["Employee_ID"].Value = employeeID;
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                employee.EmployeeNumber = (int)reader["Employee_ID"];
                                employee.EmployeeName = (string)reader["Employee_Name"];
                                employee.EmployeeFirstName = (string)reader["Employee_FirstName"];
                                employee.EmployeeMiddle = (string)reader["Employee_MiddleName"];
                                employee.EmployeeLastName = (string)reader["Employee_LastName"];
                                employee.Age = (int)reader["Age"];
                                employee.BirthDate = (DateTime)reader["Birth_Date"];
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
                throw (ex);
            }
        }

        public DataTable ReadAllEmployees()
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlCommand command = new SqlCommand("", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    table.Load(command.ExecuteReader());
                    command.Connection.Close();
                }
                return table;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateEmployee(string employeeID, List<string> updates)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("", Connection))
                {
                    command.Parameters["Employee_ID"].Value = employeeID;
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (updates[0] != "")
                                {
                                    command.Parameters["Employee_Name"].Value = updates[0];
                                }
                                if (updates[1] != "")
                                {
                                    command.Parameters["Employee_FirstName"].Value = updates[1];
                                }
                                if (updates[2] != "")
                                {
                                    command.Parameters["Employee_MiddleName"].Value = updates[2];
                                }
                                if (updates[3] != "")
                                {
                                    command.Parameters["Employee_LastName"].Value = updates[3];
                                }
                                if (updates[4] != "")
                                {
                                    command.Parameters["Age"].Value = updates[4];
                                }
                                if (updates[5] != "")
                                {
                                    command.Parameters["Birth_Date"].Value = updates[5];
                                }
                            }
                        }
                    }

                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteEmployee(string employeeID)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("", Connection))
                {
                    command.Parameters["Employee_ID"].Value = employeeID;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}