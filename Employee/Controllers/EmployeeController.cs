using Employee.LoggerExtention;
using Employee.Model;
using Employee.Moduls.Command.Delete;
using Employee.Moduls.EmployeeManagement.Command.Create;
using Employee.Moduls.EmployeeManagement.Command.Update;
using Employee.Moduls.EmployeeManagement.Quers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       
        //Dependence Injection of IMediator interface
        
        
        private readonly IMediator _mediator;
        private IloggerError _IloggerError;
        public EmployeeController(IMediator mediator,IloggerError iloggerError)
        {
            _mediator = mediator;
            _IloggerError = iloggerError;
        }
        /// <summary>
        /// Creating Employee Record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>It returns How many affected from Database and addition Informations</returns>
        [HttpPost]
        public async Task<BaseResponse> CreateEmployee(CreateEmployee employee)
        {
           
            var result=await _mediator.Send(employee);
            return result;
        }
        /// <summary>
        /// Fetch all Employee details
        /// </summary>
        /// <returns> All Employee Details</returns>
        [HttpGet]
        public async Task<List<EmployeeManagement>> GetallEmployees()
        {

            var result = await _mediator.Send(new GetEmployee());
            return result;
        }
        /// <summary>
        ///  Fetch One Employee details using Employee Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>One Employee details</returns>

        [HttpGet("{Id}")]
        public async Task<List<EmployeeManagement>> GetEmployeebyid(int Id)
        {

            var result = await _mediator.Send(new GetEmployeeByID() { EmployeeID = Id });
            return result;
        }
        /// <summary>
        ///  Update the Employee details in Database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>It returns How many affected from Database and addition Informations</returns>
        [HttpPut()]
        public async Task<BaseResponse> UpdatEemployee(UpdateEmployee employee)
        {

            var result= await _mediator.Send(employee);
            return result;
        }
        /// <summary>
        ///  Delete the Employee Details From Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>It returns How many affected from Database and addition Informations</returns>
        [HttpDelete("{id}")]
        public async Task<BaseResponse> DeleteEmployee(int id)
        {

            var result=await _mediator.Send(new DeleteEmployee() { EmployeeID = id });
            return result;
        }
    }
}
