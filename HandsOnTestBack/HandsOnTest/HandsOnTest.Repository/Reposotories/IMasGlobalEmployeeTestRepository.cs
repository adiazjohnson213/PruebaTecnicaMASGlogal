using HandsOnTest.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Repository.Reposotories
{
    public interface IMasGlobalEmployeeTestRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}