using Employees.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("GetEmployees")]
        public async Task<ActionResult> Get()
        {
            return Ok(await employeeService.GetEmployeesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            return Ok(await employeeService.GetEmployeeByIdAsync(id));
        }
    }
}
