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
                //LoginDAL.Register(Mapper.Map<LoginDM>(info));
                info.Password = "";
                return ConfigurationManager.AppSettings["RegisterToLogin"].ToLower() == "true"
                    ? RedirectToAction("Login", "Login", info) : RedirectToAction("Home", "Index", new { area = "Default" });

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

        readonly EmployeeVM _employee = new EmployeeVM();
        [HttpPost]
        public ActionResult Login(LoginVM info)
        {
            try
            {
                if (info.Email != null && LoginDAL.Login(Mapper.Map<LoginDM>(info)))
                {
                    Session["LoggedIn"] = true;
                    info.EmployeeId = LoginDAL.ReadLoginByEmail(info.Email);
                    info.Employee = EmployeeMap.GetEmployeeById(info.EmployeeId);
                    info.Role = Mapper.Map<RolesVM>(RolesDAL.ReadRoleByID(info.Employee.RoleId));
                    Session["Role"] = info.Role.RoleName;
                    Session["ID"] = info.EmployeeId;
                    if ((bool)Session["LoggedIn"])
                    {
                        if ((string)Session["Role"] == "ADMIN" || ((string)Session["Role"] == "DIRECTOR"))
                        {
                            Session["Email"] = info.Email;
                            return RedirectToAction("AdminDashboard", "Home", new { area = "Default" });
                        }
                        else
                        {
                            Session["Email"] = info.Email;
                            return RedirectToAction("ReadAccount", "Account", new { area = "Default" });
                        }
                    }
                }
                return View();
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

        public ActionResult ReadLogins()
        {
            return View(Mapper.Map<List<LoginVM>>(LoginDAL.ViewLogins()));
        }

        public ActionResult ReadLoginByID(LoginDM login)
        {
            return View(Mapper.Map<LoginVM>(LoginDAL.ReadLoginById(login.LoginId.ToString())));
        }

        public ActionResult UpdateLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateLogin(LoginVM login)
        {
            LoginDAL.UpdateLogin(Mapper.Map<LoginDM>(login));
            return View();
        }

        public ActionResult DeleteLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteLogin(LoginVM login)
        {
            LoginDAL.DeleteLogin(Mapper.Map<LoginDM>(login));
            return View();
        }

    }
}