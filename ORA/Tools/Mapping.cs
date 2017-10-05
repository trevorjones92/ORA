using System.Collections.Generic;
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
                cfg.CreateMap<LoginVM,LoginDM>();
                cfg.CreateMap<EmployeeVM, EmployeeDM>();
                cfg.CreateMap<List<EmployeeVM>, List<EmployeeDM>>();
                cfg.CreateMap<List<EmployeeDM>, List<EmployeeVM>>();
            });

           
           
        }
    }
}