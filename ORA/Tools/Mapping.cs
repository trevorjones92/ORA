using AutoMapper;
using ORA.Models;
using ORA_Data.Model;
using ORA_DAL.Model;

namespace ORA.Tools
{
    public class Mapping
    {
        public static void MappingMethod()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AddressVM, AddressDM>();
                cfg.CreateMap<AddressDM, AddressVM>();
                cfg.CreateMap<AssessmentVM, AssessmentDM>();
                cfg.CreateMap<AssessmentDM, AssessmentVM>();
                cfg.CreateMap<AssignmentVM, AssignmentDM>();
                cfg.CreateMap<AssignmentDM, AssignmentVM>();
                cfg.CreateMap<ClientsVM, ClientsDM>();
                cfg.CreateMap<ClientsDM, ClientsVM>();
                cfg.CreateMap<KPIVM, KPIDM>();
                cfg.CreateMap<KPIDM, KPIVM>();
                cfg.CreateMap<PositionsVM, PositionsDM>();
                cfg.CreateMap<PositionsDM, PositionsVM>();
                cfg.CreateMap<ProjectVM, ProjectDM>();
                cfg.CreateMap<ProjectDM, ProjectVM>();
                cfg.CreateMap<SprintVM, SprintDM>();
                cfg.CreateMap<SprintDM, SprintVM>();
                cfg.CreateMap<StatusVM, StatusDM>();
                cfg.CreateMap<StatusDM, StatusVM>();
                cfg.CreateMap<StoryVM, StoryDM>();
                cfg.CreateMap<StoryDM, StoryVM>();
                cfg.CreateMap<TeamsVM, TeamsDM>();
                cfg.CreateMap<TeamsDM, TeamsVM>();
                cfg.CreateMap<LoginVM,LoginDM>();
                cfg.CreateMap<LoginDM, LoginVM>();
                cfg.CreateMap<EmployeeVM, EmployeeDM>();
                cfg.CreateMap<EmployeeDM, EmployeeVM>();
<<<<<<< HEAD
                cfg.CreateMap<AddressVM, AddressDM>();
                cfg.CreateMap<AddressDM, AddressVM>();
=======
                cfg.CreateMap<RolesVM, RolesDM>();
                cfg.CreateMap<RolesDM, RolesVM>();
>>>>>>> 2522debfdd1879f9367679f69723a16157f195ef
            });
        }
    }
}