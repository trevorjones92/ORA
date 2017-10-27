using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA.Models
{
    public class ResumeVM
    {
        public int ResumeID { get; set; }

        public long EmployeeID { get; set; }

        public EmployeeVM Employee { get; set; }

        public EducationVM Education { get; set; }

        public SkillsVM Skills { get; set; }

        public WorkHistoryVM WorkHistory { get; set; }

        public List<WorkHistoryVM> WorkHistoryList { get; set; }
    }
}