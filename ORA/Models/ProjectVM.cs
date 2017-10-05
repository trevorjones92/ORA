using System;

namespace ORA.Models
{
    public class ProjectVM
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public int ProjectNumber { get; set; }

        public int StartDate { get; set; }

        public int EndDate { get; set; }

        public int ClientId { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }
    }
}