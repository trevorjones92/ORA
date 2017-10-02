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
    class KPI_DAL
    {
        /// <summary>
        /// Basic CRUD methods for KPI information. KPIDM is the model being used here.
        /// </summary>

        #region KPI DAL METHODS

        public void CreateKPI(KPIDM _kpi)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_KPI", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Create_Date", _kpi.CreateDate);
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

        public List<KPIDM> ReadKPI()
        {
            List<KPIDM> _kpiList = new List<KPIDM>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    Connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_KPI", Connection))
                    {
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _kpi = new KPIDM();
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

                                    _kpiList.Add(_kpi);
                                }
                            }
                        }
                    }
                }
                return (_kpiList);
            }
            catch (Exception e)
            {
                throw(e);
            }
        }

        public void UpdateKPI(KPIDM _kpi)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_ADDRESS", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@KPI_ID", _kpi.KPIID);
                        cmd.Parameters.AddWithValue("@Create_Date", _kpi.CreateDate);
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

        public void DeleteKPI(KPIDM _kpi)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_KPI", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@KPI_ID", _kpi.KPIID);
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
