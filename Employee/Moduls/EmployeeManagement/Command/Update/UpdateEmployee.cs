using Azure.Core;
using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employee.Moduls.EmployeeManagement.Command.Update
{
    public class UpdateEmployee : IRequest<ResultResponce>
    {
        public int Id { get; set; }
        public string Empname { get; set; }

        public string Desgnation { get; set; }
        public int Pincode { get; set; }
        public int MangerID { get; set; }
        public int salary { get; set; }
        public string depName { get; set; }
        public List<Model.Educationalqualification> EducationalQualification { get; set; }

    }
    public class UpdateEmployeeHandlers : IRequestHandler<UpdateEmployee, ResultResponce>
    {
        public readonly EmpDbContext dbContext;
        public UpdateEmployeeHandlers(EmpDbContext _dbContext)
        {


            dbContext = _dbContext;
        }

        public Task<ResultResponce> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {
            var entity = dbContext.EmployeeManagement.Where(x => x.EmployeeId == request.Id);

            if (entity != null)
            {
                ResultResponce response = new ResultResponce();
                var Employeedetails = new Model.EmployeeManagement();
                Employeedetails.EmployeeId = request.Id;
                Employeedetails.EmployeeName = request.Empname;
                Employeedetails.Pincode = request.Pincode;
                Employeedetails.DepartmentName = request.depName;
                Employeedetails.Salary = request.salary;
                Employeedetails.Designation = request.Desgnation;
                Employeedetails.ManagerID = request.MangerID;
                Employeedetails.EducationalQualifications = request.EducationalQualification;
                dbContext.Update(Employeedetails);
                response.ResponseValue = dbContext.SaveChanges();
                response.Information = "Employee details Updated";
                return Task.FromResult(response);
            }
            else
            {
                throw new Exception();
            }



        }
    }
}
