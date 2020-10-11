﻿using HandsOnTest.Repository.Entities;

namespace HandsOnTest.Business.DTO
{
    public class HourlyEmployee : EmployeeBase
    {
        public HourlyEmployee(Employee employee)
        {
            this.Id = employee.Id;
            this.Name = employee.Name;
            this.ContractTypeName = employee.ContractTypeName;
            this.RoleId = employee.RoleId;
            this.RoleName = employee.RoleName;
            this.RoleDescription = employee.RoleDescription;
            this.HourlySalary = employee.HourlySalary;
            this.MonthlySalary = employee.MonthlySalary;
            this.AnnualSalary = CalculatedAnnualSalary();
        }

        public override double CalculatedAnnualSalary()
        {
            return this.AnnualSalary = 120 * this.HourlySalary * 12;
        }
    }
}