using System;
using ORA.Models;
using System.Web.Mvc;
using ORA_Data.DAL;
using AutoMapper;
using ORA_Data.Model;
using System.Configuration;
using System.Collections.Generic;

namespace ORA.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
        

        public ActionResult ReadAccount()
        {
            return View();
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