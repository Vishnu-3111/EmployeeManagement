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
        public async Task<ResultResponce> Post([FromBody] Employees employee)
        {
            ResultResponce result = new ResultResponce();

            await _mediator.Send(new Addemployeequery(employee));
           
                result.information = "Employee details added";
            

            return result;
        }
        [HttpGet]
        public async Task<List<Employees>> GetallEmployees()
        {

            var result = await _mediator.Send(new Getemployeequery());
            return result;
        }

        [HttpGet("{Id}")]
        public async Task<Employees> GetEmployeebyid(int Id)
        {

            var result = await _mediator.Send(new GetemployeequeryId(Id));
            return result;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updateemployee([FromBody] Employees employee)
        {

            return Ok(await _mediator.Send(new updateemployeequery(employee)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemployee(int id)
        {

            return Ok(await _mediator.Send(new DeleteemployeequeryId() { EmployeeId = id }));
        }
    }
}
