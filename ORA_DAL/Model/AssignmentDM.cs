using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA.Models
{
    public class AssignmentDM
    {
        public int AssignmentId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        public int PositionId { get; set; }

        public int RoleId { get; set; }

        public int TeamId { get; set; }

        public DateTime Modify { get; set; }

        public string ModifiedBy { get; set; }

        public int Created { get; set; }

        public string CreatedBy { get; set; }
    }
}