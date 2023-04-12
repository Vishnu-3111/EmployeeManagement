using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employee.Moduls.Command.Delete
{
    public class DeleteEmployee : IRequest<string>
    {
        public int EmployeeID { get; set; }
    }
    public class DeleteEmployeeHandlers : IRequestHandler<DeleteEmployee, string>
    {
        private readonly EmpDbContext _dbContext;
        public DeleteEmployeeHandlers(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> Handle(DeleteEmployee command, CancellationToken cancellationToken)
        {
            var employees = await _dbContext.Employees.Where(a => a.EmpId == command.EmployeeID).FirstOrDefaultAsync();


            if (employees != null)
            {
                _dbContext.Employees.Remove(employees);
                await _dbContext.SaveChangesAsync();
                string output = "Record is Deleted";
                return output;
            }
           else
            {
                throw new Exception();
            }
        }
    }
}
