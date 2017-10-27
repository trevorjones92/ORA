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

        public long EmployeeID { get; set; }

        public EmployeeDM Employee { get; set; }

        public EducationDM Education { get; set; }

        public SkillsDM Skills { get; set; }

        public WorkHistoryDM WorkHistory { get; set; }

        public List<WorkHistoryDM> WorkHistoryList { get; set; }

    }
}
