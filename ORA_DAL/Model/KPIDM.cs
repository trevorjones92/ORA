using System;

namespace ORA.Models
{
    public class KPIDM
    {
        public int KPIID { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal Points { get; set; }

        public int TCCreated { get; set; }

        public int TCExecuted { get; set; }

        public int TCFailed { get; set; }

        public int TCPassed { get; set; }

        public int TCBlocked { get; set; }

        public int DefectsFound { get; set; }

        public int DefectsFixed { get; set; }

        public int DefectsAccepted { get; set; }

        public int DefectsRejected { get; set; }

        public int DefectsDeferred { get; set; }

        public int CriticalDefects { get; set; }

        public decimal TestHrsPlanned { get; set; }

        public decimal TestHrsActual { get; set; }

        public int BugsFoundProduction { get; set; }

        public decimal TotalHrsFixingBugs { get; set; }

        public int AssignmentId { get; set; }

        public int ProjectId { get; set; }

        public int SprintId { get; set; }

        public int StoryId { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }
    }
}