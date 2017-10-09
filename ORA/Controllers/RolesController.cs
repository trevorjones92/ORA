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

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RolesVM role)
        {
            RolesDAL.CreateRole(Mapper.Map<RolesDM>(role));
            return View();
        }
    }
}