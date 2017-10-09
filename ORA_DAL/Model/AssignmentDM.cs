using System;

namespace ORA_Data.Model
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

        public AssessmentDM Assessment { get; set; }

        public PositionsDM Position { get; set; }

        public RolesDM Role { get; set; }

        public KPIDM KPI { get; set; }

        public ClientsDM Client { get; set; }

        public TeamsDM Team { get; set; }
    }
}