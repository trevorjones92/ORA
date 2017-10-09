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
<<<<<<< HEAD
                if (info.Password != info.ConfirmPassword) return View();
                info.Salt = Convert.ToBase64String(Salt.GenerateSalt());
                info.Password = ORA_Data.Hash.GetHash(info.Password + info.Salt);
                LoginDAL.Register(Mapper.Map<LoginDM>(info));
                info.Password = "";
                return ConfigurationManager.AppSettings["RegisterToLogin"].ToLower()=="true" 
                    ? RedirectToAction("Login", "Login", info) : RedirectToAction("Home", "Index", new { area = "Default" });
=======
                if (info.Password == info.ConfirmPassword)
                {
                    info.Salt = Convert.ToBase64String(Salt.GenerateSalt());
                    info.Password = ORA_Data.Hash.GetHash(info.Password + info.Salt);
                    LoginDAL.Register(Mapper.Map<LoginDM>(info));
                    info.Password = "";
                    if (ConfigurationManager.AppSettings["RegisterToLogin"].ToLower() == "true")
                    {
                        return RedirectToAction("Login", "Login", info);
                    }
                    else
                    {
                        return RedirectToAction("Home", "Index", new { area = "Default" });
                    }
                }
                else
                {
                    return View();
                }
>>>>>>> 2522debfdd1879f9367679f69723a16157f195ef
            }
            catch (Exception ex)
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
<<<<<<< HEAD
                Session["LoggedIn"] = LoginDAL.Login(Mapper.Map<LoginDM>(info));
                if (!(bool) Session["LoggedIn"]) return View();
                Session["Email"] = info.Email;
                return RedirectToAction("Index", "Home", new { area = "Default" });
=======
                if (info.Email != null)
                {
                    Session["LoggedIn"] = LoginDAL.Login(Mapper.Map<LoginDM>(info));
                    //RolesDAL.ReadRoleByID(Mapper.Map<RolesDM>(info.Role));
                    Session["Role"] = "employee" /*info*/;
                    if ((bool)Session["LoggedIn"])
                    {
                        Session["Email"] = info.Email;
                        return RedirectToAction("Index", "Home", new { area = "Default" });
                    }
                }
                return View();

>>>>>>> 2522debfdd1879f9367679f69723a16157f195ef
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult LogOut()
        {
            Session["LoggedIn"] = false;
            return View();
        }
        
        public ActionResult ReadLogin()
        {
            return View();
        }

        public ActionResult UpdateLogin()
        {
            return View();
        }

        public ActionResult DeleteLogin()
        {
            return View();
        }

    }
}