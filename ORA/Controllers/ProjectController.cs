using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectVM project)
        {
            ProjectDAL.CreateProject(Mapper.Map<ProjectDM>(project));
            return View();
        }

        public ActionResult ReadProjects()
        {
            return View(Mapper.Map<List<ProjectVM>>(ProjectDAL.ReadProjects()));
        }

        public ActionResult ReadProjectByID(ProjectDM project)
        {
            return View(Mapper.Map<ProjectVM>(ProjectDAL.ReadProjectById(project.ProjectId.ToString())));
        }

        public ActionResult UpdateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateProject(ProjectVM project)
        {
            ProjectDAL.UpdateProject(Mapper.Map<ProjectDM>(project));
            return View();
        }

        public ActionResult DeleteProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteProject(ProjectVM project)
        {
            ProjectDAL.DeleteProject(Mapper.Map<ProjectDM>(project));
            return View();
        }
    }
}