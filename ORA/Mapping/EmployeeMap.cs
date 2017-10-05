using System.Collections.Generic;
using ORA.Models;
using AutoMapper;
using ORA_Data.Data;
using ORA_DAL.Model;

namespace ORA.Mapping
{
    public class EmployeeMap
    {
        private static EmployeeDAL employeeDO = new EmployeeDAL();

        public static void CreateEmployee(EmployeeVM employee)
        {
            employeeDO.CreateEmployee(Mapper.Map<EmployeeDM>(employee));
        }

        public static List<EmployeeVM> ReadEmployees()
        {
<<<<<<< HEAD
            return Mapper.Map<List<EmployeeVM>>(employeeDO.ReadEmployee());
=======
            return Mapper.Map<List<EmployeeDM>>(employeeDO.ReadEmployees());
>>>>>>> 386b201499e73d21a7ce3c78e5996ac6ba23bcb6
        }

        public static void UpdateEmployee(EmployeeVM employee)
        {
            employeeDO.UpdateEmployee(Mapper.Map<EmployeeDM>(employee));
        }

        public static void DeleteEmployee(EmployeeVM employee)
        {
            employeeDO.DeleteEmployee(Mapper.Map<EmployeeDM>(employee));
        }
    }
}
