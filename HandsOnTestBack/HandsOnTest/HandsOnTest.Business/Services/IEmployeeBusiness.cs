using HandsOnTest.Business.DTO;
using System.Collections.Generic;

namespace HandsOnTest.Business.Services
{
    public interface IEmployeeBusiness
    {
        IEnumerable<EmployeeBase> GetEmployee();
        EmployeeBase GetEmployee(int id);
    }
}