using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employee.Moduls.Command.Delete
{
    public class DeleteEmployee : IRequest<ResultResponce>
    {
        public int EmployeeID { get; set; }
    }
    public class DeleteEmployeeHandlers : IRequestHandler<DeleteEmployee, ResultResponce>
    {
        private readonly EmpDbContext _dbContext;
        public DeleteEmployeeHandlers(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResultResponce> Handle(DeleteEmployee command, CancellationToken cancellationToken)
        {
            var employees = await _dbContext.EmployeeManagement.Where(a => a.EmployeeId == command.EmployeeID).FirstOrDefaultAsync();


            if (employees != null)
            {
                ResultResponce response=new ResultResponce();
                _dbContext.EmployeeManagement.Remove(employees);
               response.ResponseValue= await _dbContext.SaveChangesAsync();
                response.Information = "Record is Deleted";
                return response;
            }
           else
            {
                throw new Exception();
            }
        }
    }
}
