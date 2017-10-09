using System;
using ORA.Models;
using System.Web.Mvc;
using ORA_Data.DAL;
using AutoMapper;
using ORA_Data.Model;
using System.Configuration;

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
                if (info.Password != info.ConfirmPassword) return View();
                info.Salt = Convert.ToBase64String(Salt.GenerateSalt());
                info.Password = ORA_Data.Hash.GetHash(info.Password + info.Salt);
                LoginDAL.Register(Mapper.Map<LoginDM>(info));
                info.Password = "";
                return ConfigurationManager.AppSettings["RegisterToLogin"].ToLower()=="true" 
                    ? RedirectToAction("Login", "Login", info) : RedirectToAction("Home", "Index", new { area = "Default" });
            }
            catch(Exception ex)
            {
                throw ex;
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
                Session["LoggedIn"] = LoginDAL.Login(Mapper.Map<LoginDM>(info));
                if (!(bool) Session["LoggedIn"]) return View();
                Session["Email"] = info.Email;
                return RedirectToAction("Index", "Home", new { area = "Default" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult LogOut()
        {
            Session["LoggedIn"] = false;
            return View();
        }

    }
}