using Employee.Model;
using Employee.Moduls.Command.Delete;
using Employee.Moduls.EmployeeManagement.Command.Create;
using Employee.Moduls.EmployeeManagement.Command.Update;
using Employee.Moduls.EmployeeManagement.Quers.GetEmployeeById;
using Employee.Moduls.EmployeeManagement.Quers.GetEmployeeList;
using MediatR;
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
        #region Commands
        /// <summary>
        /// Used To Create A New Employee
        /// </summary>
        /// <remarks>
        ///     Example Values
        ///     -------------
        /// {
        /// 
        ///      "EmployeeName":"Test",
        ///      
        ///      "Designation":"Junior Engineer",
        ///      
        ///      "Pincode":"654321",
        ///      
        ///      "ManagerID":"4321",
        ///      
        ///      "Salary":"15000",
        ///      
        ///      "DepartmentName":"Developer"
        ///      
        ///      "degree":"B.B.A",
        ///      
        ///      "percentage":"68"
        /// 
        /// }
        /// </remarks>
        /// <param name="employee"></param>
        /// <returns>returns affected rows and addition Informations</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<BaseResponse> CreateEmployee(CreateEmployee employee)
        {
            var result = await _mediator.Send(employee);
            return result;
        }

        /// <summary>
        ///  Updates Employee details 
        /// </summary>
        /// <remarks> 
        /// 
        ///   Example Values
        ///   --------------
        /// {
        /// 
        ///      "EmployeeID":"1",
        ///      
        ///      "EmployeeName":"Test",
        ///      
        ///      "Designation":"Junior Engineer",
        ///      
        ///      "Pincode":"654321",
        ///      
        ///      "ManagerID":"4321",
        ///      
        ///      "Salary":"15000",
        ///      
        ///      "DepartmentName":"BackEnd Developer"
        ///      
        ///      "degree":"B.B.A",
        ///      
        ///      "percentage":"68"
        ///      
        ///     } 
        ///     
        /// </remarks>
        /// <param name="employee"></param>
        /// <returns>returns affected rows and addition Informations</returns>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BaseResponse> UpdateEemployee(UpdateEmployee employee)
        {
            var result = await _mediator.Send(employee);
            return result;
        }

        /// <summary>
        ///  Deletes Employee Details 
        /// </summary>
        /// <remarks> 
        /// 
        /// 
        ///     "id":"1"
        /// 
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>returns affected rows and addition Informations</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BaseResponse> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(new DeleteEmployee() { EmployeeID = id });
            return result;
        }
        #endregion

        #region Queries
        /// <summary>
        /// Fetch all Employee details
        /// </summary>
        /// <returns> All Employee Details</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<EmployeeManagement>> GetallEmployees()
        {
            var result = await _mediator.Send(new GetAllEmployee());
            return result;
        }
        /// <summary>
        ///  Fetch Employee details using Employee Id
        /// </summary>
        /// <remarks>
        /// 
        /// 
        ///     "Id":"1"
        ///     
        /// 
        /// </remarks>
        /// <param name="Id"></param>
        /// <returns>Employee Info</returns>

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<EmployeeManagement>> GetEmployeebyid(int Id)
        {
            var result = await _mediator.Send(new GetEmployeeByID() { EmployeeID = Id });
            return result;
        }
        #endregion


    }
}
