using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Employee.Moduls.EmployeeManagement.Command.Create
{/// <summary>
/// This Class used Create Or Add new employee
/// </summary>
    public class CreateEmployee : IRequest<ResultResponce>
    {
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int Pincode { get; set; }
        public int ManagerID { get; set; }
        public int Salary { get; set; }
        public string DepartmentName { get; set; }
        public List<Model.Educationalqualification> EducationalQualification { get; set; }
    }
   
   
   
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, ResultResponce>
    {
        /// <summary>
        /// Dependency Injection of EmployeeDBcontext Class
        /// </summary>
        
        private readonly EmpDbContext _dbContext;
        public CreateEmployeeHandler(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
          
        }
        /// <summary>
        /// This Handler Handles the Create new Employee details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> Retruns how many Rows effected and create status of this method </returns>

        public Task<ResultResponce> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {
            ResultResponce response = new ResultResponce();
            var EmployeeDetails = new Model.EmployeeManagement();
            EmployeeDetails.EmployeeName = request.EmployeeName;
            EmployeeDetails.Pincode = request.Pincode;
            EmployeeDetails.DepartmentName = request.DepartmentName;
            EmployeeDetails.Salary = request.Salary;
            EmployeeDetails.Designation = request.Designation;
            EmployeeDetails.ManagerID = request.ManagerID;
            EmployeeDetails.EducationalQualifications = request.EducationalQualification;
            _dbContext.EmployeeManagement.Add(EmployeeDetails);
            response.ResponseValue= _dbContext.SaveChanges();
            response.Information = "Employee Details Created";

            return Task.FromResult(response);
        }
    }
}
