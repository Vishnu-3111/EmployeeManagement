using Employee.LoggerExtention;
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
        private IloggerError _IloggerError;
        public EmployeeController(IMediator mediator, IloggerError iloggerError)
        {
            _mediator = mediator;
            _IloggerError = iloggerError;
        }
        #region Commands
        /// <summary>
        /// Used To Create A New Employee
        /// </summary>
        /// <remarks>
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
        ///      "DepartmentName":"BackEnd Developer"
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
        public async Task<BaseResponse> UpdatEemployee(UpdateEmployee employee)
        {
            var result = await _mediator.Send(employee);
            return result;
        }

        /// <summary>
        ///  Deletes Employee Details 
        /// </summary>
        /// <remarks> 
        /// {
        /// 
        ///     "EmployeeID":"1"
        /// 
        /// }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>returns affected rows and addition Informations</returns>
        [HttpDelete("{id}")]
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
        public async Task<List<EmployeeManagement>> GetallEmployees()
        {
            var result = await _mediator.Send(new GetEmployee());
            return result;
        }
        /// <summary>
        ///  Fetch Employee details using Employee Id
        /// </summary>
        /// <remarks>
        /// {
        /// 
        ///     "EmployeeID":"1"
        ///     
        /// }
        /// </remarks>
        /// <param name="Id"></param>
        /// <returns>Employee Info</returns>

        [HttpGet("{Id}")]
        public async Task<List<EmployeeManagement>> GetEmployeebyid(int Id)
        {
            var result = await _mediator.Send(new GetEmployeeByID() { EmployeeID = Id });
            return result;
        }
        #endregion


    }
}
