using System;
using System.ComponentModel;

namespace ORA.Models
{
    public class SprintVM
    {
        public int SprintId { get; set; }

        [DisplayName("Sprint Number")]
        public int SprintNumber { get; set; }

        [DisplayName("Sprint Name")]
        public string SprintName { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }
    }
}