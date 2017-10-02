using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class EmployeeController : Controller
    {

        // GET: Employee
        public ActionResult Index()
        {
            if (Session["Roles"].ToString().ToUpper().Trim().Contains("DIRECTOR") || Session["Roles"].ToString().ToUpper().Trim().Contains("ADMINISTRATOR"))
            {
                return View(/*Specific View???*/);
            }
            return View();
        }


    }
}