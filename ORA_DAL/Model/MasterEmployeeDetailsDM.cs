using System.Collections.Generic;
using ORA_Data.Model;

namespace ORA_Data.Model
{
    public class MasterEmployeeDetailsDM
    {
        public List<EmployeeDM> employeeDM { get; set; }
        public List<AddressDM> addressDM { get; set; }
        public List<EmployeeTimeDM> employeeTimeDM { get; set; }
        public List<StatusDM> statusVM { get; set; }
    }
}
