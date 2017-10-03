using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA.Models
{
    public class StatusVM
    {
        public int StatusId { get; set; }

        public string EmployeeStatus { get; set; }

        public DateTime HireDate { get; set; }

        public string PayType { get; set; }

        public string ServiceLength { get; set; }

        public string EmploymentType { get; set; }

        public string OfficeLocation { get; set; }

        public DateTime TerminationDate { get; set; }
    }
}