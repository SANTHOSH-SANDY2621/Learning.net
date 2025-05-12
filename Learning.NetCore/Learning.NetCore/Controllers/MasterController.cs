using Learning.NetCore.BLogic.IBLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IEmployeeLogic employeeLogic;

        public MasterController(IEmployeeLogic employeeLogic)
        {
            this.employeeLogic = employeeLogic;
        }        

        [HttpGet("employees")]
        public async Task<IActionResult> getemployees()
        {
           return Ok(await employeeLogic.GetEmployeesAsync());
        }

        [HttpGet("empbyid")]
        public async Task<IActionResult> getemployees([FromQuery] long id)
        {
            return Ok(await employeeLogic.GetEmployeebyId(id));
        }       
    }
}
