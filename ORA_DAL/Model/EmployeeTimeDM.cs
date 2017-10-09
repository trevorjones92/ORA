using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA_DAL.Model
{
    public class EmployeeTimeDM
    {
        public int Time_ID { get; set; }

        public decimal Other_Total { get; set; }

        public decimal Other_Available { get; set; }

        public decimal Other_Used { get; set; }

        public decimal Payed_Total { get; set; }

        public decimal Payed_Available { get; set; }

        public decimal Payed_Used { get; set; }
    }
}
