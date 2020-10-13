using HandsOnTest.Business.DTO;
using HandsOnTest.Business.Exeption;
using HandsOnTest.Business.Factories;
using HandsOnTest.Repository.Entities;
using HandsOnTest.Repository.Reposotories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnTest.Business.Services
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IMasGlobalEmployeeTestRepository _MasGlobalEmployeeTestRepository;
        private readonly IEmployeeFactory _EmployeeFactory;

        public EmployeeBusiness(IMasGlobalEmployeeTestRepository masGlobalEmployeeTestRepository,
                                IEmployeeFactory employeeFactory)
        {
            _MasGlobalEmployeeTestRepository = masGlobalEmployeeTestRepository;
            _EmployeeFactory = employeeFactory;
        }

        public async Task<IEnumerable<EmployeeBase>> GetEmployee()
        {
            try
            {
                var employeeList = await GetEmployeesFromRepository();
                return GetAnualsSalarys(employeeList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeeBase> GetEmployee(int id)
        {
            try
            {
                var employeeList = await GetEmployeesFromRepository();
                return GetAnualSalary(employeeList.FirstOrDefault(e => e.Id == id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Task<IEnumerable<Employee>> GetEmployeesFromRepository()
        {
            return _MasGlobalEmployeeTestRepository.GetEmployeesAsync();
        }

        private IEnumerable<EmployeeBase> GetAnualsSalarys(IEnumerable<Employee> employee)
        {
            _ = employee ?? throw new HandsOnTestException("Employee does not have information");
            return employee.Select(e => GetAnualSalary(e));
        }

        private EmployeeBase GetAnualSalary(Employee employee)
        {
            _ = employee ?? throw new HandsOnTestException("Employee does not exist");
            return _EmployeeFactory.CreateEmployee(employee);
        }
    }
}
