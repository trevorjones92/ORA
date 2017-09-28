using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA.Models
{
    public class EmployeeVM
    {
        public int EmployeeId { get; set; }

        public int EmployeeNumber { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeMiddle { get; set; }

        public string EmployeeLastName { get; set; }

        public int MyProperty { get; set; }
    }
}