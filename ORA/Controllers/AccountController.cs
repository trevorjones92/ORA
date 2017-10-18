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
            return View();
        }

        [HttpPost]
        public ActionResult AccountCreation(EmployeeVM employee)
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
        

        public ActionResult ReadAccount()
        {
            return View(Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById((int)Session["ID"])));
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