using ORA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ORA_Data;
using ORA_Data.DAL;
using AutoMapper;
using ORA_Data.Model;

namespace ORA.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(LoginVM info)
        {

            try
            {
                info.Salt = Salt.GenerateSalt().ToString();
                info.Password = ORA_Data.Hash.GetHash(info.Password + info.Salt);
                LoginDAL.Register(Mapper.Map<LoginDM>(info));
                return View("Login", info);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM info)
        {
            try
            {
                LoginDAL.Login(Mapper.Map<LoginDM>(info));
                Session["LoggedIn"] = true;
                return View("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}