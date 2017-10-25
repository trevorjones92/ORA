using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;

namespace ORA.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult UpdateResume()
        {
            ResumeVM resume = new ResumeVM();
            return View(resume);
        }

        [HttpPost]
        public ActionResult UpdateResume(ResumeVM resume)
        {
            int empID = (int)Session["ID"];
            ResumeDAL.UpdateResume(Mapper.Map<ResumeDM>(resume), empID);
            return Redirect("ReadAccount");
        }
    }
}