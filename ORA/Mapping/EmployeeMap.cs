using System.Collections.Generic;
using ORA.Models;
using AutoMapper;
using ORA_Data.Data;
using ORA_DAL.Model;

namespace ORA.Mapping
{
    public class EmployeeMap
    {
        public static EmployeeDAL employeeDO = new EmployeeDAL();

        public static void CreateEmployee(EmployeeVM employee)
        {
            employeeDO.CreateEmployee(Mapper.Map<EmployeeDM>(employee));
        }

        public static List<EmployeeDM> ReadEmployees()
        {
            return Mapper.Map<List<EmployeeDM>>(employeeDO.ReadEmployee());
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