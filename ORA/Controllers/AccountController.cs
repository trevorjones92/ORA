using System;
using ORA.Models;
using System.Web.Mvc;
using ORA_Data.DAL;
using AutoMapper;
using ORA_Data.Model;
using System.Configuration;
using System.Collections.Generic;
using ORA.Mapping;

namespace ORA.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccountCreation()
        {
            EmployeeVM employee = new EmployeeVM();
            employee.TeamList = Mapper.Map<List<TeamsVM>>(TeamsDAL.ReadTeams());
            employee.AssignmentList = Mapper.Map<List<AssignmentVM>>(AssignmentDAL.ReadAssignments());
            employee.RoleList = Mapper.Map<List<RolesVM>>(RolesDAL.ReadRoles());
            return View(employee);
        }

        [HttpPost]
        public ActionResult AccountCreation(EmployeeVM employee)
        {
            EmployeeMap.CreateEmployee(employee);
            AddressDAL.CreateAddress(Mapper.Map<AddressDM>(employee.Address));
            TimeDAL.CreateTime(Mapper.Map<EmployeeTimeDM>(employee.EmployeeTime));
            Work_StatusDAL.CreateStatus(Mapper.Map<StatusDM>(employee.Status));
            LoginDAL.Register(Mapper.Map<LoginDM>(employee.Login));
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
        

        public ActionResult ReadAccount()
        {
            return View(/*Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById((int)Session["ID"]))*/);
        }

        public ActionResult UpdateAccount()
        {
            return View();
        }

        public ActionResult DeleteAccount()
        {
            return View();
        }
    }
}