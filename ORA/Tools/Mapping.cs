using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ORA.Models;
using ORA_Data.Model;

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
<<<<<<< HEAD
=======
                cfg.CreateMap<List<EmployeeDM>, List<EmployeeVM>>();
>>>>>>> 788adcab32142a1a3f01fa3b0cd37d01080a219e
            });

           
           
        }
    }
}