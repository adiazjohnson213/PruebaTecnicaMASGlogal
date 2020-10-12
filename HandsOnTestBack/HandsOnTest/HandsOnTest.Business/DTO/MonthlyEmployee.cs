using HandsOnTest.Repository.Entities;

namespace HandsOnTest.Business.DTO
{
    public class MonthlyEmployee : EmployeeBase
    {
        public MonthlyEmployee(Employee employee)
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
            return this.AnnualSalary = this.MonthlySalary * 12;
        }
    }
}
