using ORA_Data.Model;
using System;
using System.Collections.Generic;
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
        public static void CreateAssignment(AssignmentDM _assignment)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlCommand cmd = new SqlCommand("CREATE_ASSIGNMENT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Assignment_Name", _assignment.AssignmentName);
                    cmd.Parameters.AddWithValue("@StartDate", _assignment.StartDate.ToShortDateString());
                    if (_assignment.EndDate != null)
                        cmd.Parameters.AddWithValue("@EndDate", _assignment.EndDate.ToShortDateString());
                    else
                        cmd.Parameters.AddWithValue("@EndDate", null);
                    cmd.Parameters.AddWithValue("@Client_Id", _assignment.ClientId);
                    cmd.Parameters.AddWithValue("@Position_Id", _assignment.PositionId);
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

        public static List<AssignmentDM> ReadAssignments()
        {
            List<AssignmentDM> _assignmentList = new List<AssignmentDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_ASSIGNMENTS", SqlConnect.Connection))
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
                                _assignment.AssignmentId = (Int64)reader["Assignment_ID"];
                                _assignment.AssignmentName = (string)reader["Assignment_Name"];
                                _assignment.StartDate = (DateTime)reader["Start_Date"];
                                _assignment.EndDate = (DateTime)reader["End_Date"];
                                _assignment.ClientId = (Int64)reader["Client_ID"];
                                _assignment.PositionId = (Int64)reader["Position_ID"];
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

        public static AssignmentDM ReadAssignmentByID(string assignmentId)
        {
            AssignmentDM _assignment = new AssignmentDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_ASSIGNMENT_BY_ID", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    cmd.Parameters.AddWithValue("@Assignment_ID", assignmentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _assignment.AssignmentId = (Int64)reader["Assignment_ID"];
                                _assignment.AssignmentName = (string)reader["Assignment_Name"];
                                _assignment.StartDate = (DateTime)reader["Start_Date"];
                                _assignment.EndDate = (DateTime)reader["End_Date"];
                                _assignment.ClientId = (Int64)reader["Client_ID"];
                                _assignment.PositionId = (Int64)reader["Position_ID"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_assignment);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                throw ex;
            }
        }

        public static void UpdateAssignment(AssignmentDM _assignment)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_ASSIGNMENT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Assignment_ID", _assignment.AssignmentId);
                    cmd.Parameters.AddWithValue("@Assignment_Name", _assignment.AssignmentName);
                    cmd.Parameters.AddWithValue("@Start_Date", _assignment.StartDate.ToShortDateString());
                    if (_assignment.EndDate != null)
                        cmd.Parameters.AddWithValue("@EndDate", _assignment.EndDate.ToShortDateString());
                    else
                        cmd.Parameters.AddWithValue("@EndDate", null);
                    cmd.Parameters.AddWithValue("@Client_ID", _assignment.ClientId);
                    cmd.Parameters.AddWithValue("@Position_ID", _assignment.PositionId);
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

        public static void DeleteAssignment(AssignmentDM _assignment)
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
