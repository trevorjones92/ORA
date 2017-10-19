using System.Collections.Generic;
using ORA.Models;
using AutoMapper;
using ORA_Data.Model;
using ORA_Data.DAL;

namespace ORA.Mapping
{
    public class EmployeeMap
    {
        private static readonly EmployeeDAL employeeDO = new EmployeeDAL();

        public static void CreateEmployee(EmployeeVM employee)
        {
            employeeDO.CreateEmployee(Mapper.Map<EmployeeDM>(employee));
        }

        public static List<EmployeeVM> ReadEmployees()
        {
            return Mapper.Map<List<EmployeeVM>>(employeeDO.ReadEmployees());
        }

        public static EmployeeVM GetEmployeeById(long employeeId)
        {
            return Mapper.Map<EmployeeVM>(employeeDO.ReadEmployeeById(employeeId));
        }

        public static long GetEmployeeId(string employeeNum)
        {
            return employeeDO.ReadEmployeeId(employeeNum);
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
