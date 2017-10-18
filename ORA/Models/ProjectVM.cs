using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ORA.Models
{
    public class ProjectVM
    {
        public int ProjectId { get; set; }

        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        [DisplayName("Project Number")]
        public int ProjectNumber { get; set; }

        [DisplayName("Start Date")]
        public int StartDate { get; set; }

        [DisplayName("End Date")]
        public int EndDate { get; set; }

        public int ClientId { get; set; }

        public List<ClientsVM> Clients { get; set; }

        public DateTime Created { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }
    }
}