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

namespace ORA_DAL.DAL
{
    class AssignmentDAL
    {
        /// <summary>
        /// Basic CRUD methods for Assignment information. AssignmentDM is the model being used here.
        /// </summary>
        /// 

        #region ASSIGNMENT DAL Methods
        public void CreateAssignment(AssignmentDM _assignment)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_ADDRESS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Start_Date", _assignment.StartDate);
                        cmd.Parameters.AddWithValue("@End_Date", _assignment.EndDate);
                        cmd.Parameters.AddWithValue("@Client_Id", _assignment.ClientId);
                        cmd.Parameters.AddWithValue("@Employee_Id", _assignment.EmployeeId);
                        cmd.Parameters.AddWithValue("@Position_Id", _assignment.PositionId);
                        cmd.Parameters.AddWithValue("@Role_Id", _assignment.RoleId);
                        cmd.Parameters.AddWithValue("@Team_Id", _assignment.TeamId);
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

        public List<AssignmentDM> ReadAddress()
        {
            List<AssignmentDM> _assignmentList = new List<AssignmentDM>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    Connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_ASSIGNMENT", Connection))
                    {
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _assignment = new AssignmentDM();
                                    _assignment.StartDate = (DateTime)reader["Start_Date"];
                                    _assignment.EndDate = (DateTime)reader["End_Date"];
                                    _assignment.ClientId = (int)reader["Client_ID"];
                                    _assignment.EmployeeId = (int)reader["Employee_ID"];
                                    _assignment.PositionId = (int)reader["Position_ID"];
                                    _assignment.RoleId = (int)reader["Role_ID"];
                                    _assignment.TeamId = (int)reader["Team_ID"];
                                    _assignmentList.Add(_assignment);
                                }
                            }
                        }
                    }
                }
                return (_assignmentList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAssignment(AssignmentDM _assignment)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_ASSIGNMENT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Assignment_ID", _assignment.AssignmentId);
                        cmd.Parameters.AddWithValue("@Start_Date", _assignment.StartDate);
                        cmd.Parameters.AddWithValue("@End_Date", _assignment.EndDate);
                        cmd.Parameters.AddWithValue("@Client_ID", _assignment.ClientId);
                        cmd.Parameters.AddWithValue("@Employee_ID", _assignment.EmployeeId);
                        cmd.Parameters.AddWithValue("@Position_ID", _assignment.PositionId);
                        cmd.Parameters.AddWithValue("@Role_ID", _assignment.RoleId);
                        cmd.Parameters.AddWithValue("@Team_ID", _assignment.TeamId);
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

        public void DeleteAssignment(AssignmentDM _assignment)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_ADDRESS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Assignment_ID", _assignment.AssignmentId);
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

        #endregion
    }
}
