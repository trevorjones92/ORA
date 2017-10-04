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
            });
        }
    }
}