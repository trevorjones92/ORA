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

        public Int64 AddressID { get; set; }

        public Int64 TimeID { get; set; }

        public Int64 WorkStatusID { get; set; }

<<<<<<< HEAD
        //Objects of other models
        public AddressVM address { get; set; }

        public EmployeeTimeVM employeeTime { get; set; }

        public ClientsVM client { get; set; }

        public PositionsVM position { get; set; }

        public TeamsVM team { get; set; }

        public StatusVM workStatus { get; set; }
=======
        public AddressVM Address { get; set; }

        public StatusVM Status { get; set; }

        public AssignmentVM Assignment { get; set; }

>>>>>>> 2522debfdd1879f9367679f69723a16157f195ef
    }
}