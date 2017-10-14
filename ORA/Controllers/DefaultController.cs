using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}