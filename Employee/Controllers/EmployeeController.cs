using Employee.Model;
using Employee.Moduls.Command.Delete;
using Employee.Moduls.EmployeeManagement.Command.Create;
using Employee.Moduls.EmployeeManagement.Command.Update;
using Employee.Moduls.EmployeeManagement.Quers.GetEmployeeById;
using Employee.Moduls.EmployeeManagement.Quers.GetEmployeeList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Annotations;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag]
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
        [Route("CreateEmployee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<BaseResponse> CreateEmployee(CreateEmployee employee)
        {
            var customHeader = Request.Headers["Custom-Header"];
            if (!string.IsNullOrEmpty(customHeader) && customHeader == "Create-Value")
            {
                var result = await _mediator.Send(employee);
                return result;
            }
            else
            {
                throw new Exception();
            }
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
        [HttpPut]
        [Route("UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BaseResponse> UpdateEemployee(UpdateEmployee employee)
        {
            var customHeader = Request.Headers["Custom-Header"];
            if (!string.IsNullOrEmpty(customHeader) && customHeader == "Update-Value")
            {
                var result = await _mediator.Send(employee);
                return result;
            }
            else { throw new Exception(); }
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
        [HttpDelete]
        [Route("DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BaseResponse> DeleteEmployee(int id)
        {
            var customHeader = Request.Headers["Custom-Header"];
            if (!string.IsNullOrEmpty(customHeader) && customHeader == "Delete-Value")
            {
                var result = await _mediator.Send(new DeleteEmployee() { EmployeeID = id });
                return result;
            }
            else { throw new Exception() ; }
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

           var customHeader= Request.Headers["Custom-Header"];
            if (!string.IsNullOrEmpty(customHeader)&& customHeader== "Get-Value")
            {
                var result = await _mediator.Send(new GetAllEmployee());
               return result;
            }
            else
            {
                throw new Exception() ;
            }
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

        [HttpGet]
        [Route("GetEmployeebyId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<EmployeeManagement>> GetEmployeebyid(int Id)
        {
            var customHeader = Request.Headers["Custom-Header"];
            if (!string.IsNullOrEmpty(customHeader) && customHeader == "GetById-Value")
            {
                var result = await _mediator.Send(new GetEmployeeByID() { EmployeeID = Id });
                return result;
            }
            else { throw new Exception() ; }
        }
        #endregion


    }
}
