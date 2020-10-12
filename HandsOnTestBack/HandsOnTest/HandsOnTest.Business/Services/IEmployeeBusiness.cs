using HandsOnTest.Business.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Business.Services
{
    public interface IEmployeeBusiness
    {
        Task<IEnumerable<EmployeeBase>> GetEmployee();
        Task<EmployeeBase> GetEmployee(int id);
    }
}