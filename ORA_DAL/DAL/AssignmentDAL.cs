using ORA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class AssignmentDAL
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
                    using (SqlCommand cmd = new SqlCommand("CREATE_ADDRESS", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Start_Date", _assignment.StartDate);
                        cmd.Parameters.AddWithValue("@End_Date", _assignment.EndDate);
                        cmd.Parameters.AddWithValue("@Client_Id", _assignment.ClientId);
                        cmd.Parameters.AddWithValue("@Employee_Id", _assignment.EmployeeId);
                        cmd.Parameters.AddWithValue("@Position_Id", _assignment.PositionId);
                        cmd.Parameters.AddWithValue("@Role_Id", _assignment.RoleId);
                        cmd.Parameters.AddWithValue("@Team_Id", _assignment.TeamId);
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

        public List<AssignmentDM> ReadAssignment()
        {
            List<AssignmentDM> _assignmentList = new List<AssignmentDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_ASSIGNMENT", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
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
                    SqlConnect.Connection.Close();
                }
                return (_assignmentList);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                throw ex;
            }
        }

        public void UpdateAssignment(AssignmentDM _assignment)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_ASSIGNMENT", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Assignment_ID", _assignment.AssignmentId);
                        cmd.Parameters.AddWithValue("@Start_Date", _assignment.StartDate);
                        cmd.Parameters.AddWithValue("@End_Date", _assignment.EndDate);
                        cmd.Parameters.AddWithValue("@Client_ID", _assignment.ClientId);
                        cmd.Parameters.AddWithValue("@Employee_ID", _assignment.EmployeeId);
                        cmd.Parameters.AddWithValue("@Position_ID", _assignment.PositionId);
                        cmd.Parameters.AddWithValue("@Role_ID", _assignment.RoleId);
                        cmd.Parameters.AddWithValue("@Team_ID", _assignment.TeamId);
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

        public void DeleteAssignment(AssignmentDM _assignment)
        {
            try
            {
                    using (SqlCommand cmd = new SqlCommand("DELETE_ADDRESS", SqlConnect.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Assignment_ID", _assignment.AssignmentId);
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

        #endregion
    }
}
