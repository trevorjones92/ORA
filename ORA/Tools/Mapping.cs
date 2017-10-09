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
                cfg.CreateMap<LoginDM, LoginVM>();
                cfg.CreateMap<EmployeeVM, EmployeeDM>();
                cfg.CreateMap<EmployeeDM, EmployeeVM>();
                cfg.CreateMap<AddressVM, AddressDM>();
                cfg.CreateMap<AddressDM, AddressVM>();
            });
        }
    }
}