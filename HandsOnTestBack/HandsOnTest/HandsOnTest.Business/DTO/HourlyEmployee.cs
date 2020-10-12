using HandsOnTest.Repository.Entities;

namespace HandsOnTest.Business.DTO
{
    public class HourlyEmployee : EmployeeBase
    {
        public HourlyEmployee(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleId = employee.RoleId;
            RoleName = employee.RoleName;
            RoleDescription = employee.RoleDescription;
            HourlySalary = employee.HourlySalary;
            MonthlySalary = employee.MonthlySalary;
            AnnualSalary = CalculatedAnnualSalary();
        }

        public override double CalculatedAnnualSalary()
        {
            return AnnualSalary = 120 * this.HourlySalary * 12;
        }
    }
}
