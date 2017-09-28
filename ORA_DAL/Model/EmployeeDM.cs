using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA.Models
{
    public class EmployeeDM
    {
        public int EmployeeId { get; set; }

        public int EmployeeNumber { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeMiddle { get; set; }

        public string EmployeeLastName { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public int AddressID { get; set; }

        public int TimeID { get; set; }

        public int WorkStatusID { get; set; }
    }
}