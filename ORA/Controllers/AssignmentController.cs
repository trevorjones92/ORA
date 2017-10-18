using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAssignment()
        {
            AssignmentVM assignmment = new AssignmentVM();
            assignmment.Created = DateTime.Now;
            assignmment.Modify = DateTime.Now;
            assignmment.Clients = Mapper.Map<List<ClientsVM>>(ClientsDAL.ReadClients());
            assignmment.Positions = Mapper.Map<List<PositionsVM>>(PositionsDAL.ReadPositions());
            return View(assignmment);
        }

        [HttpPost]
        public ActionResult CreateAssignment(AssignmentVM assignment)
        {
            AssignmentDAL.CreateAssignment(Mapper.Map<AssignmentDM>(assignment));
            return View();
        }

        public ActionResult ReadAssignments()
        {
            return View(Mapper.Map<List<AddressVM>>(AssignmentDAL.ReadAssignments()));
        }

        public ActionResult ReadAssignmentByID(AssignmentDM assignment)
        {
            return View(Mapper.Map<AddressVM>(AssignmentDAL.ReadAssignmentByID(assignment.AssignmentId.ToString())));
        }

        public ActionResult UpdateAssignment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAssignment(AssignmentVM assignment)
        {
            AssignmentDAL.UpdateAssignment(Mapper.Map<AssignmentDM>(assignment));
            return View();
        }

        public ActionResult DeleteAssignment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteAssignment(AssignmentVM assignment)
        {
            AssignmentDAL.DeleteAssignment(Mapper.Map<AssignmentDM>(assignment));
            return View();
        }
    }
}