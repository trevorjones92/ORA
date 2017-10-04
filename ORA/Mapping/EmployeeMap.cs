using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ORA.Models;
using AutoMapper;

namespace ORA.Mapping
{
    public class EmployeeMap
    {
        public static EmployeeVM _employee = new EmployeeVM();

        public static EmployeeVM PlaceHolderMethod(EmployeeVM _employee)
        {
            return (_employee);
        }

        public static EmployeeVM PlaceHolderMethodByID(EmployeeVM _employee)
        {
            return (_employee);
        }
    }
}