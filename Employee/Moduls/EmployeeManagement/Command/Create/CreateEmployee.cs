using Azure;
using Employee.Model;
using MediatR;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Moduls.EmployeeManagement.Command.Create
{/// <summary>
/// This Class used Create Or Add new employee
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
        /// <summary>
        /// Dependency Injection of EmployeeDBcontext Class
        /// </summary>
        
        private readonly EmpDbContext _dbContext;
        public CreateEmployeeHandler(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
          
        }
        //This Handler Handles the Create new Employee details

        public Task<BaseResponse> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {
                BaseResponse response = new BaseResponse();
            //This Try block Throws any Error during create operations
            try
            {
                var EmployeeDetails = new Model.EmployeeManagement();
                EmployeeDetails.EmployeeName = request.EmployeeName;
                EmployeeDetails.Pincode = request.Pincode;
                EmployeeDetails.DepartmentName = request.DepartmentName;
                EmployeeDetails.Salary = request.Salary;
                EmployeeDetails.Designation = request.Designation;
                EmployeeDetails.ManagerID = request.ManagerID;
                EmployeeDetails.degree= request.degree;
                EmployeeDetails.percentage= request.percentage;

                //if(request.EducationalQualification.Count > 0)
                //{
                //    foreach(var item in request.EducationalQualification)
                //    {
                //       List< Educationalqualification >eq = new List<Educationalqualification>();
                //        eq.Add(item);
                //        EmployeeDetails.EducationalQualifications=eq;
                //    }
                //}
                _dbContext.EmployeeManagement.Add(EmployeeDetails);
                               
                response.ResponseValue =  _dbContext.SaveChanges();
                response.Information = "Employee Details Created";
                if (response.ResponseValue == 0)
                {
                    throw new BadRequest();
                }
                return Task.FromResult(response);
            }
            catch(Exception ex)
            {
                //throw ;
            }
            return Task.FromResult(response);
        }
    }
}
