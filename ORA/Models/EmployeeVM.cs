using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ORA.Models
{
    public class EmployeeVM 
    {
        public Int64 EmployeeId { get; set; }

        [DisplayName("Employee Number")]
        public string EmployeeNumber { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("First Name")]
        public string EmployeeFirstName { get; set; }

        [DisplayName("Middle Name")]
        public string EmployeeMiddle { get; set; }

        [DisplayName("Last Name")]
        public string EmployeeLastName { get; set; }

        public int Age { get; set; }

        [DisplayName("Birth Date")]
        public string BirthDate { get; set; }

        //Objects of other models

        public long AddressId { get; set; }

        public AddressVM Address { get; set; }

        public List<AddressVM> AddressList { get; set; }

        public long TimeId { get; set; }

        public EmployeeTimeVM EmployeeTime { get; set; }

        public List<EmployeeTimeVM> EmployeeTimeList { get; set; }

        public long ClientId { get; set; }

        public ClientsVM Client { get; set; }

        public List<ClientsVM> ClientList { get; set; }

        public long PositionId { get; set; }

        public PositionsVM Position { get; set; }

        public List<PositionsVM> PositionList { get; set; }

        public long TeamId { get; set; }

        public TeamsVM Team { get; set; }

        public List<TeamsVM> TeamList { get; set; }

        public long StatusId { get; set; }

        public StatusVM Status { get; set; }

        public List<StatusVM> StatusList { get; set; }

        public long AssignmentId { get; set; }

        public AssignmentVM Assignment { get; set; }

        public List<AssignmentVM> AssignmentList { get; set; }

    }
}