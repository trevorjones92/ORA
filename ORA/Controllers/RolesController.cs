using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(RolesVM role)
        {
            RolesDAL.CreateRole(Mapper.Map<RolesDM>(role));
            return View();
        }
        
        public ActionResult ReadRole()
        {
            return View();
        }

        public ActionResult UpdateRole()
        {
            return View();
        }

        public ActionResult DeleteRole()
        {
            return View();
        }
    }
}