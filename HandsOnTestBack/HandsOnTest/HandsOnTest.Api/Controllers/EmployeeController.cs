using HandsOnTest.Business.DTO;
using HandsOnTest.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _EmployeeBusiness;

        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _EmployeeBusiness = employeeBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeBase>>> Get()
        {
            return Ok(await _EmployeeBusiness.GetEmployee());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeBase>> Get(int id)
        {
            return Ok(await _EmployeeBusiness.GetEmployee(id));
        }
    }
}
