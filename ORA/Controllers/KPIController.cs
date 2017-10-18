using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class KPIController : Controller
    {
        // GET: KPI
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateKPI()
        {
            KPIVM kpi = new KPIVM();
            kpi.Assignments = Mapper.Map<List<AssignmentVM>>(AssignmentDAL.ReadAssignments());
            kpi.Projects = Mapper.Map<List<ProjectVM>>(ProjectDAL.ReadProjects());
            kpi.Sprints = Mapper.Map<List<SprintVM>>(SprintDAL.ReadSprints());
            kpi.Stories = Mapper.Map<List<StoryVM>>(StoryDAL.ReadStorys());
            return View(kpi);
        }

        [HttpPost]
        public ActionResult CreateKPI(KPIVM kpi)
        {
            KPI_DAL.CreateKPI(Mapper.Map<KPIDM>(kpi));
            return View();
        }

        public ActionResult ReadKPIs()
        {
            return View(Mapper.Map<List<KPIVM>>(KPI_DAL.ReadKPIs()));
        }

        public ActionResult ReadKPIByID(KPIDM kpi)
        {
            return View(Mapper.Map<KPIVM>(KPI_DAL.ReadKPIById(kpi.KPIID.ToString())));
        }

        public ActionResult UpdateKPI()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateKPI(KPIVM kpi)
        {
            KPI_DAL.UpdateKPI(Mapper.Map<KPIDM>(kpi));
            return View();
        }

        public ActionResult DeleteKPI()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteKPI(KPIVM kpi)
        {
            KPI_DAL.DeleteKPI(Mapper.Map<KPIDM>(kpi));
            return View();
        }
    }
}