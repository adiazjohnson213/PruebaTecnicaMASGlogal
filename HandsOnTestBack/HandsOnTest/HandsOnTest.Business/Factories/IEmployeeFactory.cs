using HandsOnTest.Business.DTO;
using HandsOnTest.Repository.Entities;

namespace HandsOnTest.Business.Factories
{
    public interface IEmployeeFactory
    {
        EmployeeBase CreateEmployee(Employee employee);
    }
}