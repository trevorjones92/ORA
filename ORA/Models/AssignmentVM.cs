using System;
using System.ComponentModel;

namespace ORA.Models
{
    public class AssignmentVM
    {
        public int AssignmentId { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public int ClientId { get; set; } 

        public int EmployeeId { get; set; }

        public int PositionId { get; set; }

        public int RoleId { get; set; }

        public DateTime Modify { get; set; }

        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }

        public int Created { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
    }
}