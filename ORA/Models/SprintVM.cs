using System;

namespace ORA.Models
{
    public class SprintVM
    {
        public int SprintId { get; set; }

        public int SprintNumber { get; set; }

        public string SprintName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }
    }
}