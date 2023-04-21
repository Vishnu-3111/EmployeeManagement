using Azure;
using Employee.Model;
using MediatR;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Moduls.EmployeeManagement.Command.Create
{/// <summary>
/// used Create Or Add new employee
/// </summary>
    public class CreateEmployee : IRequest<BaseResponse>
    {
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int Pincode { get; set; }
        public int ManagerID { get; set; }
        public int Salary { get; set; }
        public string DepartmentName { get; set; }
        public string degree { get; set; }
        public int percentage { get; set; }
    }



    public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, BaseResponse>
    {

        private readonly EmpDbContext _dbContext;
        public CreateEmployeeHandler(EmpDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        // Handles the Create new Employee details

        public async Task<BaseResponse> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {
            BaseResponse response = new BaseResponse();
          
            var EmployeeDetails = new Model.EmployeeManagement();
            EmployeeDetails.EmployeeName = request.EmployeeName;
            EmployeeDetails.Pincode = request.Pincode;
            EmployeeDetails.DepartmentName = request.DepartmentName;
            EmployeeDetails.Salary = request.Salary;
            EmployeeDetails.Designation = request.Designation;
            EmployeeDetails.ManagerID = request.ManagerID;
            EmployeeDetails.degree = request.degree;
            EmployeeDetails.percentage = request.percentage;
            _dbContext.EmployeeManagement.Add(EmployeeDetails);
            int result = await _dbContext.SaveChangesAsync();
            response.ResponseValue = EmployeeDetails.EmployeeId;
            response.Information = "Employee Details Created";
            if (result == 0)
            {
                throw new BadRequest();
            }
            return response;

        }
    }
}
