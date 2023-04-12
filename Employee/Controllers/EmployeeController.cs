using Employee.Model;
using Employee.Moduls.Command.Delete;
using Employee.Moduls.EmployeeManagement.Command.Create;
using Employee.Moduls.EmployeeManagement.Command.Delete;
using Employee.Moduls.EmployeeManagement.Command.Update;
using Employee.Moduls.EmployeeManagement.Quers;
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
        public async Task<ResultResponce> Create(CreateEmployee employee)
        {
            ResultResponce result = new();

            await _mediator.Send(employee);

            result.information = "Employee details added";


            return result;
        }
        [HttpGet]
        public async Task<List<Employees>> GetallEmployees()
        {

            var result = await _mediator.Send(new GetEmployee());
            return result;
        }

        [HttpGet("{Id}")]
        public async Task<Employees> GetEmployeebyid(int Id)
        {

            var result = await _mediator.Send(new GetEmployeeByID() { EmployeeID = Id });
            return result;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updateemployee(UpdateEmployee employee)
        {

            return Ok(await _mediator.Send(employee));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemployee(int id)
        {

            return Ok(await _mediator.Send(new DeleteEmployee() { EmployeeID = id }));
        }
    }
}
