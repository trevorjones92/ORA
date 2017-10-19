using AutoMapper;
using ORA.Mapping;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class AssessmentController : Controller
    {
        // GET: Assessment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAssessment()
        {
            AssessmentVM assessment = new AssessmentVM();
            assessment.EmployeeList = EmployeeMap.ReadEmployees();
            return View(assessment);
        }

        [HttpPost]
        public ActionResult CreateAssessment(AssessmentVM assessment)
        {
            AssessmentDAL.CreateAssessment(Mapper.Map<AssessmentDM>(assessment));
            return View();
        }

        public ActionResult ReadAssessments()
        {
            return View(Mapper.Map<List<AssessmentVM>>(AssessmentDAL.ReadAssessments()));
        }

        public ActionResult ReadAssessmentByID(AssessmentDM assessment)
        {
            return View(Mapper.Map<AssessmentVM>(AssessmentDAL.ReadAssessmentByID(assessment.AssessmentId.ToString())));
        }

        public ActionResult UpdateAssessment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAssessment(AssessmentVM assessment)
        {
            AssessmentDAL.UpdateAssessment(Mapper.Map<AssessmentDM>(assessment));
            return View();
        }

        public ActionResult DeleteAssessment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteAssessment(AssessmentVM assessment)
        {
            AssessmentDAL.DeleteAssessment(Mapper.Map<AssessmentDM>(assessment));
            return View();
        }

        //Get Assessments

        //Get Assessments for different Roles

        //Update Assessments

        //Delete Assessments

        //Get Average for each Position

        //Average for each team

        //Average for each client
    }
}