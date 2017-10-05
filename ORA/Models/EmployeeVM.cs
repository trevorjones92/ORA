using System;

namespace ORA.Models
{
    public class EmployeeVM
    {
        public Int64 EmployeeId { get; set; }

        public string EmployeeNumber { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeMiddle { get; set; }

        public string EmployeeLastName { get; set; }

        public int Age { get; set; }

        public string BirthDate { get; set; }

        public int AddressID { get; set; }

        public int TimeID { get; set; }

        public int WorkStatusID { get; set; }
    }
}