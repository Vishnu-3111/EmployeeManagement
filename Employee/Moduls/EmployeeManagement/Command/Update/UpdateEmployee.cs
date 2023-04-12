using Azure.Core;
using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employee.Moduls.EmployeeManagement.Command.Update
{
    public class UpdateEmployee : IRequest<string>
    {
        public int Id { get; set; }
        public string Empname { get; set; }

        public string Desgnation { get; set; }
        public int Pincode { get; set; }
        public int MangerID { get; set; }
        public int salary { get; set; }
        public string depName { get; set; }

    }
    public class UpdateEmployeeHandlers : IRequestHandler<UpdateEmployee, string>
    {
        public readonly EmpDbContext dbContext;
        public UpdateEmployeeHandlers(EmpDbContext _dbContext)
        {


            dbContext = _dbContext;
        }

        public Task<string> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {
            var entity=dbContext.Employees.Where(x=>x.EmpId == request.Id);

            if (entity != null)
            {

                var Employeedetails = new Employees();
                Employeedetails.EmpId = request.Id;
                Employeedetails.Empname = request.Empname;
                Employeedetails.Pincode = request.Pincode;
                Employeedetails.depName = request.depName;
                Employeedetails.salary = request.salary;
                Employeedetails.Desgnation = request.Desgnation;
                Employeedetails.MangerID = request.MangerID;
                dbContext.Update(Employeedetails);
                dbContext.SaveChanges();
                return Task.FromResult("Employee details Updated");
            }
            else
            {
                throw new Exception();
            }
            


        }
    }
}
