using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA.Models
{
    public class MasterEmployeeDetailsVM
    {
        public List<EmployeeVM> employeeVM { get; set; }
        public List<AddressVM> addressVM { get; set; }
        public List<EmployeeTimeVM> employeeTimeVM { get; set; }
        public List<StatusVM> statusVM { get; set; }
    }
}