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
       
        //Dependence Injection of IMediator interface
        
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Creating Employee Details by Http Post Methods
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>It returns How many affected from Database and addition Informations</returns>
        [HttpPost]
        public async Task<ResultResponce> CreateEmployee(CreateEmployee employee)
        {
           
            var result=await _mediator.Send(employee);
            return result;
        }
        /// <summary>
        /// Its used to Fetch all Employee details
        /// </summary>
        /// <returns> All Employee Details</returns>
        [HttpGet]
        public async Task<List<EmployeeManagement>> GetallEmployees()
        {

            var result = await _mediator.Send(new GetEmployee());
            return result;
        }
        /// <summary>
        /// Its used to Fetch One Employee details using Employee Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>One Employee details</returns>

        [HttpGet("{Id}")]
        public async Task<EmployeeManagement> GetEmployeebyid(int Id)
        {

            var result = await _mediator.Send(new GetEmployeeByID() { EmployeeID = Id });
            return result;
        }
        /// <summary>
        /// This Controller method used to Update the Employee details in Database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>It returns How many affected from Database and addition Informations</returns>
        [HttpPut()]
        public async Task<ResultResponce> UpdatEemployee(UpdateEmployee employee)
        {

            var result= await _mediator.Send(employee);
            return result;
        }
        /// <summary>
        /// This Controllers used to Delete the Employee Details From Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>It returns How many affected from Database and addition Informations</returns>
        [HttpDelete("{id}")]
        public async Task<ResultResponce> DeleteEmployee(int id)
        {

            var result=await _mediator.Send(new DeleteEmployee() { EmployeeID = id });
            return result;
        }
    }
}
