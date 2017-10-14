﻿using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
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
            return View();
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