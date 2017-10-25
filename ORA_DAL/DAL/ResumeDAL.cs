using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class ResumeDAL
    {
        #region CREATE METHODS
        /// <summary>
        /// Creates a blank resume on employee account creation for the employee to utilize later
        /// Uses the CREATE_RESUME stored procedure
        /// </summary>
        /// <param name="_resume"></param>
        /// <param name="empID"></param>
        public static void CreateResume(ResumeDM _resume, long empID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_RESUME", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Professional_Summary", _resume.ProfessionalSummary = "");
                    cmd.Parameters.AddWithValue("@Skills_ID", _resume.SkillsID);
                    cmd.Parameters.AddWithValue("@Work_History_ID", _resume.WorkHistoryID);
                    cmd.Parameters.AddWithValue("@Education_ID", _resume.EducationID);
                    cmd.Parameters.AddWithValue("@Employee_ID", _resume.EmployeeID = empID);
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

        /// <summary>
        /// Updates education fields in the Education table
        /// Uses the UPDATE_EDUCATION stored procedure
        /// </summary>
        /// <param name="_education"></param>
        public static void CreateEducation(EducationDM _education)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_EDUCATION", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Insitution_Name", _education.InsitutionName);
                    cmd.Parameters.AddWithValue("@Attended_Start_Date", _education.Attended_Start_Date);
                    cmd.Parameters.AddWithValue("@Attended_End_Date", _education.Attended_End_Date);
                    cmd.Parameters.AddWithValue("@Institution_Location", _education.InstitutionLocation);
                    cmd.Parameters.AddWithValue("@Education_Earned", _education.EducationEarned);
                    cmd.Parameters.AddWithValue("@Area_Of_Study", _education.AreaOfStudy);
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

        /// <summary>
        /// Updates Skill fields in the Skills table
        /// Uses the UPDATE_SKILLS stored procedure
        /// </summary>
        /// <param name="_skills"></param>
        public static void CreateSkills(SkillsDM _skills)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE_SKILLS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Skills_1", _skills.Skill_1);
                    cmd.Parameters.AddWithValue("@Skill_1_Proficiency", _skills.Skill_1_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_2", _skills.Skill_2);
                    cmd.Parameters.AddWithValue("@Skill_2_Proficiency", _skills.Skill_2_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_3", _skills.Skill_3);
                    cmd.Parameters.AddWithValue("@Skill_3_Proficiency", _skills.Skill_3_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_4", _skills.Skill_4);
                    cmd.Parameters.AddWithValue("@Skill_4_Proficiency", _skills.Skill_4_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_5", _skills.Skill_5);
                    cmd.Parameters.AddWithValue("@Skill_5_Proficiency", _skills.Skill_5_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_6", _skills.Skill_6);
                    cmd.Parameters.AddWithValue("@Skill_6_Proficiency", _skills.Skill_6_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_7", _skills.Skill_7);
                    cmd.Parameters.AddWithValue("@Skill_7_Proficiency", _skills.Skill_7_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_8", _skills.Skill_8);
                    cmd.Parameters.AddWithValue("@Skill_8_Proficiency", _skills.Skill_8_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_9", _skills.Skill_9);
                    cmd.Parameters.AddWithValue("@Skill_9_Proficiency", _skills.Skill_9_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_10", _skills.Skill_10);
                    cmd.Parameters.AddWithValue("@Skill_10_Proficiency", _skills.Skill_10_Proficiency);
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

        /// <summary>
        /// Updates the work history fields in the WorkHistory table
        /// Uses the UPDATE_WORK_HISTORY stored procedure
        /// </summary>
        /// <param name="_workHistory"></param>
        public static void CreateWorkHistory(WorkHistoryDM _workHistory)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_WORK_HISTORY", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Organization_Name", _workHistory.OrganizationName);
                    cmd.Parameters.AddWithValue("@Work_Place_Start_Date", _workHistory.WorkPlaceStartDate);
                    cmd.Parameters.AddWithValue("@Work_Place_End_Date", _workHistory.WorkPlaceEndDate);
                    cmd.Parameters.AddWithValue("@Job_Description", _workHistory.JobDescription);
                    cmd.Parameters.AddWithValue("@Work_Place_Location", _workHistory.WorkPlaceLocation);
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

        #region READ METHODS
        /// <summary>
        ///This will grab the employee resume from the resume table where the employee ID foreign key is equal to the current logged in users ID (i.e users employee ID)
        /// Uses the READ_RESUME stored procedure
        /// </summary>
        /// <param name="resumeID"></param>
        /// <param name="empID"></param>
        /// <returns></returns>
        public static ResumeDM ViewMyResume(string resumeID, int empID)
        {
            ResumeDM _resume = new ResumeDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("VIEW_MY_RESUME", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Resume_ID", resumeID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _resume.ResumeID = (int)reader["Resume_ID"];
                                _resume.ProfessionalSummary = (string)reader["Proffesional_Summary"];
                                _resume.SkillsID = (int)reader["Skills_ID"];
                                _resume.WorkHistoryID = (int)reader["Work_History_ID"];
                                _resume.EducationID = (int)reader["Education_ID"];
                                _resume.EmployeeID = (int)reader["Employee_ID"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_resume);
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        #endregion

        #region UPDATE METHODS
        /// <summary>
        /// Blank resumes are already built on account creation. This makes it to where instead of running a query to see if a resume was already
        /// created for the user, it just updates the blank resume. All employees will have resumes anyways
        /// Uses the UPDATE_RESUME stored procedure
        /// </summary>
        /// <param name="_resume"></param>
        /// <param name="empID"></param>
        public static void UpdateResume(ResumeDM _resume, int empID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("BUILD_RESUME", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Resume_ID", _resume.ResumeID);
                    cmd.Parameters.AddWithValue("@Professional_Summary", _resume.ProfessionalSummary);
                    cmd.Parameters.AddWithValue("@Skills_ID", _resume.SkillsID);
                    cmd.Parameters.AddWithValue("@Work_History_ID", _resume.WorkHistoryID);
                    cmd.Parameters.AddWithValue("@Education_ID", _resume.EducationID);
                    cmd.Parameters.AddWithValue("@Employee_ID", _resume.EmployeeID = empID);
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

        /// <summary>
        /// Updates education fields in the Education table
        /// Uses the UPDATE_EDUCATION stored procedure
        /// </summary>
        /// <param name="_education"></param>
        public static void UpdateEducation(EducationDM _education)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_EDUCATION", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Education_ID", _education.EducationID);
                    cmd.Parameters.AddWithValue("@Insitution_Name", _education.InsitutionName);
                    cmd.Parameters.AddWithValue("@Attended_Start_Date", _education.Attended_Start_Date);
                    cmd.Parameters.AddWithValue("@Attended_End_Date", _education.Attended_End_Date);
                    cmd.Parameters.AddWithValue("@Institution_Location", _education.InstitutionLocation);
                    cmd.Parameters.AddWithValue("@Education_Earned", _education.EducationEarned);
                    cmd.Parameters.AddWithValue("@Area_Of_Study", _education.AreaOfStudy);
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

        /// <summary>
        /// Updates Skill fields in the Skills table
        /// Uses the UPDATE_SKILLS stored procedure
        /// </summary>
        /// <param name="_skills"></param>
        public static void UpdateSkills(SkillsDM _skills)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_SKILLS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Skills_ID", _skills.Skills_ID);
                    cmd.Parameters.AddWithValue("@Skills_1", _skills.Skill_1);
                    cmd.Parameters.AddWithValue("@Skill_1_Proficiency", _skills.Skill_1_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_2", _skills.Skill_2);
                    cmd.Parameters.AddWithValue("@Skill_2_Proficiency", _skills.Skill_2_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_3", _skills.Skill_3);
                    cmd.Parameters.AddWithValue("@Skill_3_Proficiency", _skills.Skill_3_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_4", _skills.Skill_4);
                    cmd.Parameters.AddWithValue("@Skill_4_Proficiency", _skills.Skill_4_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_5", _skills.Skill_5);
                    cmd.Parameters.AddWithValue("@Skill_5_Proficiency", _skills.Skill_5_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_6", _skills.Skill_6);
                    cmd.Parameters.AddWithValue("@Skill_6_Proficiency", _skills.Skill_6_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_7", _skills.Skill_7);
                    cmd.Parameters.AddWithValue("@Skill_7_Proficiency", _skills.Skill_7_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_8", _skills.Skill_8);
                    cmd.Parameters.AddWithValue("@Skill_8_Proficiency", _skills.Skill_8_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_9", _skills.Skill_9);
                    cmd.Parameters.AddWithValue("@Skill_9_Proficiency", _skills.Skill_9_Proficiency);
                    cmd.Parameters.AddWithValue("@Skills_10", _skills.Skill_10);
                    cmd.Parameters.AddWithValue("@Skill_10_Proficiency", _skills.Skill_10_Proficiency);
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

        /// <summary>
        /// Updates the work history fields in the WorkHistory table
        /// Uses the UPDATE_WORK_HISTORY stored procedure
        /// </summary>
        /// <param name="_workHistory"></param>
        public static void UpdateWorkHistory(WorkHistoryDM _workHistory)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_WORK_HISTORY", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Education_ID", _workHistory.WorkHistoryID);
                    cmd.Parameters.AddWithValue("@Insitution_Name", _workHistory.OrganizationName);
                    cmd.Parameters.AddWithValue("@Attended_Start_Date", _workHistory.WorkPlaceStartDate);
                    cmd.Parameters.AddWithValue("@Attended_End_Date", _workHistory.WorkPlaceEndDate);
                    cmd.Parameters.AddWithValue("@Institution_Location", _workHistory.JobDescription);
                    cmd.Parameters.AddWithValue("@Education_Earned", _workHistory.WorkPlaceLocation);
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
