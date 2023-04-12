using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employee.Moduls.EmployeeManagement.Command.Create
{
    public class CreateEmployee : IRequest<string>
    {
        public string Empname { get; set; }

        public string Desgnation { get; set; }
        public int Pincode { get; set; }
        public int MangerID { get; set; }
        public int salary { get; set; }
        public string depName { get; set; }
    }
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, string>
    {
        private readonly EmpDbContext _dbContext;
        public CreateEmployeeHandler(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<string> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {

            var EmployeeDetails = new Employees();
            EmployeeDetails.Empname = request.Empname;
            EmployeeDetails.Pincode = request.Pincode;
            EmployeeDetails.depName = request.depName;
            EmployeeDetails.salary = request.salary;
            EmployeeDetails.Desgnation = request.Desgnation;
            EmployeeDetails.MangerID = request.MangerID;
            _dbContext.Employees.Add(EmployeeDetails);
            _dbContext.SaveChanges();

            return Task.FromResult("Employeedetails added");
        }
    }
}
