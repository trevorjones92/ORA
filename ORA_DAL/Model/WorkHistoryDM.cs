using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA_Data.Model
{
    public class WorkHistoryDM
    {
        public int WorkHistoryID { get; set; }
        public string OrganizationName { get; set; }
        public string WorkPlaceStartDate { get; set; }
        public string WorkPlaceEndDate { get; set; }
        public string JobDescription { get; set; }
        public string WorkPlaceLocation { get; set; }
    }
}
