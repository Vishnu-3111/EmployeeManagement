using Employee.Data.Handlers;
using Employee.Data.Quers;
using Employee.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task <IActionResult> post([FromBody]Employees employee)
        {
            
            return Ok (await _mediator.Send(new employeequery(employee)));
        }
        [HttpGet]
        public async Task<List<Employees>>GetallEmployees()
        {

           var result =await _mediator.Send(new getemployeequery());
            return result;
        }
        [HttpGet("{id}")]
        
        public async Task<Employees> GetallEmployeebyid(int id)
        {

            var result = await _mediator.Send(new employeequeryId(id));
            return result;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateemployee([FromBody] Employees employee)
        {

            return Ok(await _mediator.Send(new updateemployeequery(employee)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemployee(int id)
        {

            return Ok(await _mediator.Send(new DeleteemployeequeryId() { EmpId=id}));
        }
    }
}
