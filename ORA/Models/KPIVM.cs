using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ORA.Models
{
    public class KPIVM
    {
        public int KPIID { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreateDate { get; set; }

        public decimal Points { get; set; }

        public int TCCreated { get; set; }

        public int TCExecuted { get; set; }

        public int TCFailed { get; set; }

        public int TCPassed { get; set; }

        public int TCBlocked { get; set; }

        [DisplayName("Defects Found")]
        public int DefectsFound { get; set; }

        [DisplayName("Defects Fixed")]
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

        public List<AssignmentVM> Assignments { get; set; }

        public int ProjectId { get; set; }

        public List<ProjectVM> Projects { get; set; }

        public int SprintId { get; set; }

        public List<SprintVM> Sprints { get; set; }

        public int StoryId { get; set; }

        public List<StoryVM> Stories { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }
    }
}