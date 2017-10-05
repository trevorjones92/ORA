using ORA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ORA_DAL.DAL
{
    class AssessmentDAL
    {
        /// <summary>
        /// Basic CRUD methods for Assessment information. AssessmentDM is the model being used here.
        /// </summary>
        /// 

        #region Assessment DAL Methods
        public void CreateAssessment(AssessmentDM assessment)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE_ASSESSMENT", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TD_Problem_Solving", assessment.TDProblemSolving);
                        cmd.Parameters.AddWithValue("@TD_Quality_of_Work", assessment.TDQualityOfWork);
                        cmd.Parameters.AddWithValue("@TD_Productivity", assessment.TDProductivity);
                        cmd.Parameters.AddWithValue("@TD_Product_Knowledge", assessment.TDProductKnowledge);
                        cmd.Parameters.AddWithValue("@TD_Comments", assessment.TDComments);
                        cmd.Parameters.AddWithValue("@CSR_Proffesionalism_Teamwork", assessment.CSRProffesionalismTeamwork);
                        cmd.Parameters.AddWithValue("@CSR_Verbal_Skills", assessment.CSRVerbalSkills);
                        cmd.Parameters.AddWithValue("@CSR_Written_Skills", assessment.CSRWrittenSkills);
                        cmd.Parameters.AddWithValue("@CSR_Listening_Skills", assessment.CSRListeningSkills);
                        cmd.Parameters.AddWithValue("@CSR_Comments", assessment.CSRComments);
                        cmd.Parameters.AddWithValue("@AD_Attendence", assessment.ADAttendence);
                        cmd.Parameters.AddWithValue("@AD_Ethical_Behavior", assessment.ADEthicalBehavior);
                        cmd.Parameters.AddWithValue("@AD_Meet_Deadlines", assessment.ADMeetDeadlines);
                        cmd.Parameters.AddWithValue("@AD_Organize_Detailed_Work", assessment.ADOrganizeDetailedWork);
                        cmd.Parameters.AddWithValue("@AD_Comments", assessment.ADComments);
                        cmd.Parameters.AddWithValue("@TM_Resource_Use", assessment.TMResourceUse);
                        cmd.Parameters.AddWithValue("@TM_Feedback", assessment.TMFeedback);
                        cmd.Parameters.AddWithValue("@TM_Technical_Monitoring", assessment.TMTechnicalMonitoring);
                        cmd.Parameters.AddWithValue("@TM_Asking_Questions", assessment.TMAskingQuestions);
                        cmd.Parameters.AddWithValue("@TM_Comments", assessment.TMComments);
                        cmd.Parameters.AddWithValue("@MI_Attitude_Work", assessment.MIAttitudeWork);
                        cmd.Parameters.AddWithValue("@MI_Grooming_Appearance", assessment.MIGroomingAppearance);
                        cmd.Parameters.AddWithValue("@MI_Personal_Growth", assessment.MIPersonalGrowth);
                        cmd.Parameters.AddWithValue("@MI_Potential_Advancement", assessment.MIPotentialAdvancement);
                        cmd.Parameters.AddWithValue("@MI_Comments", assessment.MIComments);
                        cmd.Parameters.AddWithValue("@Assignment_ID", assessment.AssignmentID);
                        cmd.Parameters.AddWithValue("@Created", assessment.Created);
                        cmd.Parameters.AddWithValue("@Created_By", assessment.CreatedBy);
                        cmd.Parameters.AddWithValue("@Modified", assessment.Modified);
                        cmd.Parameters.AddWithValue("@Modified_By", assessment.ModifiedBy);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public List<AssessmentDM> ReadAddress()
        {
            List<AssessmentDM> assessmentList = new List<AssessmentDM>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("READ_ASSESSMENT", connection))
                    {
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var _assessment = new AssessmentDM();
                                    _assessment.AssessmentId = (int)reader["Assessment_ID"];
                                    _assessment.TDProblemSolving = (int)reader["TD_Problem_Solving"];
                                    _assessment.TDQualityOfWork = (int)reader["TD_Quality_Of_Work"];
                                    _assessment.TDProductivity = (int)reader["TD_Productivity"];
                                    _assessment.TDProductKnowledge = (int)reader["TD_Product_Knowledge"];
                                    _assessment.TDComments = (string)reader["TD_Comments"];
                                    _assessment.CSRProffesionalismTeamwork = (int)reader["CSR_Proffesionalism_Teamwork"];
                                    _assessment.CSRVerbalSkills = (int)reader["CSR_Verbal_Skills"];
                                    _assessment.CSRWrittenSkills = (int)reader["CSR_Written_Skills"];
                                    _assessment.CSRListeningSkills = (int)reader["CSR_Listening_Skills"];
                                    _assessment.CSRComments = (string)reader["CSR_Comments"];
                                    _assessment.ADAttendence = (int)reader["AD_Attendence"];
                                    _assessment.ADEthicalBehavior = (int)reader["AD_Ethical_Behavior"];
                                    _assessment.ADMeetDeadlines = (int)reader["AD_Meet_Deadlines"];
                                    _assessment.ADOrganizeDetailedWork = (int)reader["AD_Organize_Detailed_Work"];
                                    _assessment.ADComments = (string)reader["AD_Comments"];
                                    _assessment.TMResourceUse = (int)reader["TM_ResourceUse"];
                                    _assessment.TMFeedback = (int)reader["TM_Feedback"];
                                    _assessment.TMTechnicalMonitoring = (int)reader["TM_Technical_Monitoring"];
                                    _assessment.TMAskingQuestions = (int)reader["TM_Asking_Questions"];
                                    _assessment.TMComments = (string)reader["TM_Comments"];
                                    _assessment.MIAttitudeWork = (int)reader["MI_Attitude_Work"];
                                    _assessment.MIGroomingAppearance = (int)reader["MI_Grooming_Appearance"];
                                    _assessment.MIPersonalGrowth = (int)reader["MI_Personal_Growth"];
                                    _assessment.MIPotentialAdvancement = (int)reader["MI_Potential_Advancement"];
                                    _assessment.MIComments = (string)reader["MI_Comments"];
                                    _assessment.AssignmentID = (int)reader["Assignment_ID"];
                                    _assessment.Created = (DateTime)reader["Created"];
                                    _assessment.CreatedBy = (string)reader["Created_By"];
                                    _assessment.Modified = (DateTime)reader["Modified"];
                                    _assessment.ModifiedBy = (string)reader["Modified_By"];

                                    assessmentList.Add(_assessment);
                                }
                            }
                        }
                    }
                }
                return (assessmentList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAssessment(AssessmentDM assessment)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE_ASSESSMENT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Assessment_ID", assessment.AssessmentId);
                        cmd.Parameters.AddWithValue("@TD_Problem_Solving", assessment.TDProblemSolving);
                        cmd.Parameters.AddWithValue("@TD_Quality_of_Work", assessment.TDQualityOfWork);
                        cmd.Parameters.AddWithValue("@TD_Productivity", assessment.TDProductivity);
                        cmd.Parameters.AddWithValue("@TD_Product_Knowledge", assessment.TDProductKnowledge);
                        cmd.Parameters.AddWithValue("@TD_Comments", assessment.TDComments);
                        cmd.Parameters.AddWithValue("@CSR_Proffesionalism_Teamwork", assessment.CSRProffesionalismTeamwork);
                        cmd.Parameters.AddWithValue("@CSR_Verbal_Skills", assessment.CSRVerbalSkills);
                        cmd.Parameters.AddWithValue("@CSR_Written_Skills", assessment.CSRWrittenSkills);
                        cmd.Parameters.AddWithValue("@CSR_Listening_Skills", assessment.CSRListeningSkills);
                        cmd.Parameters.AddWithValue("@CSR_Comments", assessment.CSRComments);
                        cmd.Parameters.AddWithValue("@AD_Attendence", assessment.ADAttendence);
                        cmd.Parameters.AddWithValue("@AD_Ethical_Behavior", assessment.ADEthicalBehavior);
                        cmd.Parameters.AddWithValue("@AD_Meet_Deadlines", assessment.ADMeetDeadlines);
                        cmd.Parameters.AddWithValue("@AD_Organize_Detailed_Work", assessment.ADOrganizeDetailedWork);
                        cmd.Parameters.AddWithValue("@AD_Comments", assessment.ADComments);
                        cmd.Parameters.AddWithValue("@TM_Resource_Use", assessment.TMResourceUse);
                        cmd.Parameters.AddWithValue("@TM_Feedback", assessment.TMFeedback);
                        cmd.Parameters.AddWithValue("@TM_Technical_Monitoring", assessment.TMTechnicalMonitoring);
                        cmd.Parameters.AddWithValue("@TM_Asking_Questions", assessment.TMAskingQuestions);
                        cmd.Parameters.AddWithValue("@TM_Comments", assessment.TMComments);
                        cmd.Parameters.AddWithValue("@MI_Attitude_Work", assessment.MIAttitudeWork);
                        cmd.Parameters.AddWithValue("@MI_Grooming_Appearance", assessment.MIGroomingAppearance);
                        cmd.Parameters.AddWithValue("@MI_Personal_Growth", assessment.MIPersonalGrowth);
                        cmd.Parameters.AddWithValue("@MI_Potential_Advancement", assessment.MIPotentialAdvancement);
                        cmd.Parameters.AddWithValue("@MI_Comments", assessment.MIComments);
                        cmd.Parameters.AddWithValue("@Created", assessment.Created);
                        cmd.Parameters.AddWithValue("@Created_By", assessment.CreatedBy);
                        cmd.Parameters.AddWithValue("@Modified", assessment.Modified);
                        cmd.Parameters.AddWithValue("@Modified_By", assessment.ModifiedBy);
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

        public void DeleteAssessment(AssessmentDM assessment)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"]))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE_ASSESSMENT", Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Assessment_ID", assessment.AssessmentId);
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
