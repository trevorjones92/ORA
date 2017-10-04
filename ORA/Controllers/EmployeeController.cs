﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ORA.Models;
using ORA.Mapping;

namespace ORA.Controllers
{
    public class EmployeeController : Controller
    {

        // GET: List of Employees 
        //Initial Page Load, checks Session Role, returns List of employees based on role and role parameters
        public ActionResult ViewEmployees(EmployeeVM _employee)
        {
            //This view is not accessable to regular employees
            if (!string.IsNullOrEmpty((string)Session["Roles"]))
            {
                if (Session["Roles"].ToString().ToUpper().Trim().Contains("DIRECTOR") || Session["Roles"].ToString().ToUpper().Trim().Contains("ADMINISTRATOR"))
                {
                    return View(/*Returns List of employees*/);
                }

                /*Service managers will team Leads and employees for specific Client AND Location*/
                else if (Session["Roles"].ToString().ToUpper().Trim().Contains("SERVICEMANAGER"))
                {
                    return View(/*Returns a List of employees*/);
                }

                /*Team Leads can only see employees within Team AND Location */
                else
                    return View(/*Returns a List of employees*/);
            }
            //Else returns to Login if session is null or empty
            else
                return RedirectToAction("", "", new { area = "" });
        }

        #region ADMIN/MANAGER CREATE, READ, UPDATE, DELETE METHODS FOR SUPER USER

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View(/*Create Employee View*/);
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeVM _employee)
        {
            EmployeeMap.PlaceHolderMethod(_employee);
            return RedirectToAction("", "", new { area = "" }); ;
        }


        public ActionResult SortEmployeeBy()
        {
            /*Gets selection from dynamically loaded drop down and can sort by
             *Employee WorkStatus, Location, Client, Team, Project, Position
             */
            return View(/*Returns view based on selection*/);
        }

        [HttpGet]
        public ActionResult UpdateEmployee()
        {
            return View(/*Update Employee View*/);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeVM _employee)
        {
            EmployeeMap.PlaceHolderMethod(_employee);
            return RedirectToAction("", "", new { area = "" });
        }

        /*TODO: Needs javascript functionality to reconfirm deletion of an employee. Deleting an employee shouldnt actually delete employ, but change work status
         *      and cascade delete everywhere else where that employee is being referenced. Keeping the employee in the system for records, but removing him elsewhere
         */
        [HttpPost]
        public ActionResult DeleteEmployee(EmployeeVM _employee)
        {
            EmployeeMap.PlaceHolderMethod(_employee);
            return RedirectToAction("", "", new { area = "" }); ;
        }
        #endregion
    }
}