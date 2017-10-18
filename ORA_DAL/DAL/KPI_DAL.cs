using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class KPI_DAL
    {
        /// <summary>
        /// Basic CRUD methods for KPI information. KPIDM is the model being used here.
        /// </summary>

        #region KPI DAL METHODS

        public static void CreateKPI(KPIDM _kpi)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlCommand cmd = new SqlCommand("CREATE_KPI", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Create_Date", _kpi.CreateDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Points", _kpi.Points);
                    cmd.Parameters.AddWithValue("@TC_Created", _kpi.TCCreated);
                    cmd.Parameters.AddWithValue("@TC_Executed", _kpi.TCExecuted);
                    cmd.Parameters.AddWithValue("@TC_Failed", _kpi.TCFailed);
                    cmd.Parameters.AddWithValue("@TC_Passed", _kpi.TCPassed);
                    cmd.Parameters.AddWithValue("@TC_Blocked", _kpi.TCBlocked);
                    cmd.Parameters.AddWithValue("@Defects_Found", _kpi.DefectsFound);
                    cmd.Parameters.AddWithValue("@Defects_Fixed", _kpi.DefectsFixed);
                    cmd.Parameters.AddWithValue("@Defects_Accepted", _kpi.DefectsAccepted);
                    cmd.Parameters.AddWithValue("@Defects_Rejected", _kpi.DefectsRejected);
                    cmd.Parameters.AddWithValue("@Defects_Deferred", _kpi.DefectsDeferred);
                    cmd.Parameters.AddWithValue("@Critical_Defects", _kpi.CriticalDefects);
                    cmd.Parameters.AddWithValue("@Test_Hrs_Planned", _kpi.TestHrsPlanned);
                    cmd.Parameters.AddWithValue("@Test_Hrs_Actual", _kpi.TestHrsActual);
                    cmd.Parameters.AddWithValue("@Bugs_Found_Production", _kpi.BugsFoundProduction);
                    cmd.Parameters.AddWithValue("@Total_Hrs_Fixing_Bugs", _kpi.TotalHrsFixingBugs);
                    cmd.Parameters.AddWithValue("@Assignment_ID", _kpi.AssignmentId);
                    cmd.Parameters.AddWithValue("@Project_ID", _kpi.ProjectId);
                    cmd.Parameters.AddWithValue("@Sprint_ID", _kpi.SprintId);
                    cmd.Parameters.AddWithValue("@Story_ID", _kpi.StoryId);

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

        public static List<KPIDM> ReadKPIs()
        {
            List<KPIDM> _kpiList = new List<KPIDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_KPIS", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var _kpi = new KPIDM();
                                _kpi.KPIID = (Int64)reader["KPI_ID"];
                                _kpi.CreateDate = (DateTime)reader["Create_Date"];
                                _kpi.Points = (int)reader["Points"];
                                _kpi.TCCreated = (int)reader["TC_Created"];
                                _kpi.TCExecuted = (int)reader["TC_Executed"];
                                _kpi.TCFailed = (int)reader["TC_Failed"];
                                _kpi.TCPassed = (int)reader["TC_Passed"];
                                _kpi.TCBlocked = (int)reader["TC_Blocked"];
                                _kpi.DefectsFound = (int)reader["Defects_Found"];
                                _kpi.DefectsFixed = (int)reader["Defects_Fixed"];
                                _kpi.DefectsAccepted = (int)reader["Defects_Accepted"];
                                _kpi.DefectsRejected = (int)reader["Defects_Rejected"];
                                _kpi.DefectsDeferred = (int)reader["Defects_Deferred"];
                                _kpi.CriticalDefects = (int)reader["Critical_Defects"];
                                _kpi.TestHrsPlanned = (decimal)reader["Test_Hrs_Planned"];
                                _kpi.TestHrsActual = (decimal)reader["Test_Hrs_Actual"];
                                _kpi.BugsFoundProduction = (int)reader["Bugs_Found_Production"];
                                _kpi.TotalHrsFixingBugs = (decimal)reader["Total_Hrs_Fixing_Bugs"];
                                _kpi.AssignmentId = (Int64)reader["Assignment_ID"];
                                _kpi.ProjectId = (Int64)reader["Project_ID"];
                                _kpi.SprintId = (Int64)reader["Sprint_ID"];
                                _kpi.StoryId = (Int64)reader["Story_ID"];

                                _kpiList.Add(_kpi);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_kpiList);
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public static KPIDM ReadKPIById(string kpiId)
        {
            KPIDM _kpi = new KPIDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_KPI_BY_ID", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KPI_ID", kpiId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _kpi.KPIID = (Int64)reader["KPI_ID"];
                                _kpi.CreateDate = (DateTime)reader["Create_Date"];
                                _kpi.Points = (int)reader["Points"];
                                _kpi.TCCreated = (int)reader["TC_Created"];
                                _kpi.TCExecuted = (int)reader["TC_Executed"];
                                _kpi.TCFailed = (int)reader["TC_Failed"];
                                _kpi.TCPassed = (int)reader["TC_Passed"];
                                _kpi.TCBlocked = (int)reader["TC_Blocked"];
                                _kpi.DefectsFound = (int)reader["Defects_Found"];
                                _kpi.DefectsFixed = (int)reader["Defects_Fixed"];
                                _kpi.DefectsAccepted = (int)reader["Defects_Accepted"];
                                _kpi.DefectsRejected = (int)reader["Defects_Rejected"];
                                _kpi.DefectsDeferred = (int)reader["Defects_Deferred"];
                                _kpi.CriticalDefects = (int)reader["Critical_Defects"];
                                _kpi.TestHrsPlanned = (decimal)reader["Test_Hrs_Planned"];
                                _kpi.TestHrsActual = (decimal)reader["Test_Hrs_Actual"];
                                _kpi.BugsFoundProduction = (int)reader["Bugs_Found_Production"];
                                _kpi.TotalHrsFixingBugs = (decimal)reader["Total_Hrs_Fixing_Bugs"];
                                _kpi.AssignmentId = (Int64)reader["Assignment_ID"];
                                _kpi.ProjectId = (Int64)reader["Project_ID"];
                                _kpi.SprintId = (Int64)reader["Sprint_ID"];
                                _kpi.StoryId = (Int64)reader["Story_ID"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_kpi);
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public static void UpdateKPI(KPIDM _kpi)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_KPI", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KPI_ID", _kpi.KPIID);
                    cmd.Parameters.AddWithValue("@Create_Date", _kpi.CreateDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Points", _kpi.Points);
                    cmd.Parameters.AddWithValue("@TC_Created", _kpi.TCCreated);
                    cmd.Parameters.AddWithValue("@TC_Executed", _kpi.TCExecuted);
                    cmd.Parameters.AddWithValue("@TC_Failed", _kpi.TCFailed);
                    cmd.Parameters.AddWithValue("@TC_Passed", _kpi.TCPassed);
                    cmd.Parameters.AddWithValue("@TC_Blocked", _kpi.TCBlocked);
                    cmd.Parameters.AddWithValue("@Defects_Found", _kpi.DefectsFound);
                    cmd.Parameters.AddWithValue("@Defects_Fixed", _kpi.DefectsFixed);
                    cmd.Parameters.AddWithValue("@Defects_Accepted", _kpi.DefectsAccepted);
                    cmd.Parameters.AddWithValue("@Defects_Rejected", _kpi.DefectsRejected);
                    cmd.Parameters.AddWithValue("@Defects_Deferred", _kpi.DefectsDeferred);
                    cmd.Parameters.AddWithValue("@Critical_Defects", _kpi.CriticalDefects);
                    cmd.Parameters.AddWithValue("@Test_Hrs_Planned", _kpi.TestHrsPlanned);
                    cmd.Parameters.AddWithValue("@Test_Hrs_Actual", _kpi.TestHrsActual);
                    cmd.Parameters.AddWithValue("@Bugs_Found_Production", _kpi.BugsFoundProduction);
                    cmd.Parameters.AddWithValue("@Total_Hrs_Fixing_Bugs", _kpi.TotalHrsFixingBugs);

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

        public static void DeleteKPI(KPIDM _kpi)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_KPI", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KPI_ID", _kpi.KPIID);
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
