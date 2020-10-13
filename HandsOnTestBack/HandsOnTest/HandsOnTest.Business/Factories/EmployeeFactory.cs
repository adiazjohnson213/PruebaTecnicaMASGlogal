using HandsOnTest.Business.DTO;
using HandsOnTest.Repository.Entities;

namespace HandsOnTest.Business.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public EmployeeBase CreateEmployee(Employee employee)
        {
            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new HourlyEmployee(employee);
                case "MonthlySalaryEmployee":
                    return new MonthlyEmployee(employee);
                default:
                    return null;
            }
        }
    }
}
