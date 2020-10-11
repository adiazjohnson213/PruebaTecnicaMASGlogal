using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandsOnTest.Business.DTO;
using HandsOnTest.Business.Services;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeBase>> Get()
        {
            try
            {
                return Ok(_EmployeeBusiness.GetEmployee());
            }
            catch
            {
                throw;
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeBase> Get(int id)
        {
            try
            {
                return Ok(_EmployeeBusiness.GetEmployee(id));
            }
            catch
            {
                throw;
            }
        }
    }
}
