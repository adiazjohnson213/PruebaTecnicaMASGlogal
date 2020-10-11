using HandsOnTest.Business.DTO;
using HandsOnTest.Repository.Entities;
using HandsOnTest.Repository.Reposotories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HandsOnTest.Business.Services
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IMasGlobalEmployeeTestRepository _MasGlobalEmployeeTestRepository;

        private const string ContractHourlyName = "HourlySalaryEmployee";
        private const string ContractMonthlyName = "MonthlySalaryEmployee";

        public EmployeeBusiness(IMasGlobalEmployeeTestRepository masGlobalEmployeeTestRepository)
        {
            _MasGlobalEmployeeTestRepository = masGlobalEmployeeTestRepository;
        }

        public IEnumerable<EmployeeBase> GetEmployee()
        {
            var employeeList = _MasGlobalEmployeeTestRepository.GetEmployeesAsync().Result.ToList();
            return GetAnualsSalarys(employeeList);
        }

        public EmployeeBase GetEmployee(int id)
        {
            var employeeList = _MasGlobalEmployeeTestRepository.GetEmployeesAsync().Result.ToList();
            return GetAnualSalary(employeeList.FirstOrDefault(e => e.Id == id));
        }

        private IEnumerable<EmployeeBase> GetAnualsSalarys(IEnumerable<Employee> employee)
        {
            _ = employee ?? throw new ArgumentNullException("Employee", "Employee can not by null");
            return employee.ToList().Select(e => GetAnualSalary(e));
        }

        private EmployeeBase GetAnualSalary(Employee employee)
        {
            _ = employee ?? throw new ArgumentNullException("Employee", "Employee can not by null");
            if (String.Compare(employee.ContractTypeName, ContractHourlyName) == 0)
            {
                return new HourlyEmployee(employee);
            }
            else
            {
                return new MonthlyEmployee(employee);
            }
        }
    }
}
