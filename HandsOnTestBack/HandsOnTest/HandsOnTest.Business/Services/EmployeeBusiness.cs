using HandsOnTest.Business.DTO;
using HandsOnTest.Business.Exeption;
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
            var employeeList = GetEmployeesFromRepository();
            return GetAnualsSalarys(employeeList);
        }

        public EmployeeBase GetEmployee(int id)
        {
            var employeeList = GetEmployeesFromRepository();
            return GetAnualSalary(employeeList.FirstOrDefault(e => e.Id == id));
        }

        private List<Employee> GetEmployeesFromRepository()
        {
            return _MasGlobalEmployeeTestRepository.GetEmployeesAsync().Result.ToList();
        }

        private IEnumerable<EmployeeBase> GetAnualsSalarys(IEnumerable<Employee> employee)
        {
            _ = employee ?? throw new HandsOnTestException("Employee does not have information");
            return employee.ToList().Select(e => GetAnualSalary(e));
        }

        private EmployeeBase GetAnualSalary(Employee employee)
        {
            _ = employee ?? throw new HandsOnTestException("Employee does not exist");
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
