using System;
using System.Collections.Generic;

namespace ORA_Data.Model
{
    public class EmployeeDM : AddressDM
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

        public AddressDM address { get; set; }

        public List<AddressDM> AddressList { get; set; }

        public EmployeeTimeDM EmployeeTime { get; set; }

        public List<EmployeeTimeDM> EmployeeTimeList { get; set; }

        public ClientsDM Client { get; set; }

        public List<ClientsDM> ClientList { get; set; }

        public PositionsDM Position { get; set; }

        public List<PositionsDM> PositionList { get; set; }

        public TeamsDM Team { get; set; }

        public List<TeamsDM> TeamList { get; set; }

        public StatusDM Status { get; set; }

        public List<StatusDM> StatusList { get; set; }

        public AssignmentDM Assignment { get; set; }

        public List<AssignmentDM> AssignmentList { get; set; }
    }
}