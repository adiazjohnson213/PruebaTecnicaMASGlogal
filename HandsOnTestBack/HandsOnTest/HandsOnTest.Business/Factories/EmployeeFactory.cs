using HandsOnTest.Business.DTO;
using HandsOnTest.Repository.Entities;

namespace HandsOnTest.Business.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeBase CreateEmployee(Employee employee)
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
