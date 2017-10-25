using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA_Data.Model
{
    public class ResumeDM
    {
        public int ResumeID { get; set; }

        public string ProfessionalSummary { get; set; }

        public decimal SkillsID { get; set; }

        public long WorkHistoryID { get; set; }

        public long EducationID { get; set; }

        public long EmployeeID { get; set; }

        public EmployeeDM Employee { get; set; }

        public SkillsDM Skills { get; set; }

        public List<SkillsDM> SkillList { get; set; }

        public WorkHistoryDM WorkHistory { get; set; }

        public List<WorkHistoryDM> WorkHistoryList { get; set; }

        public EducationDM Education { get; set; }

        public List<EducationDM> EducationList { get; set; }
    }
}
