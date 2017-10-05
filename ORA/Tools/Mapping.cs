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
                cfg.CreateMap<LoginVM, LoginDM>();
                cfg.CreateMap<EmployeeVM, EmployeeDM>();
<<<<<<< HEAD
                cfg.CreateMap<EmployeeDM, EmployeeVM>();
=======
>>>>>>> 386b201499e73d21a7ce3c78e5996ac6ba23bcb6
            });
        }
    }
}