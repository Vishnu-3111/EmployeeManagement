using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Moduls.Command.Delete
{
    //Used to Delete the Employee details 
    public class DeleteEmployee : IRequest<BaseResponse>
    {
        public int EmployeeID { get; set; }
    }
    public class DeleteEmployeeHandlers : IRequestHandler<DeleteEmployee, BaseResponse>
    {

        private readonly EmpDbContext _dbContext;

        public DeleteEmployeeHandlers(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Used to Delete the Employee details 
        public async Task<BaseResponse> Handle(DeleteEmployee command, CancellationToken cancellationToken)
        {
            var employees = await _dbContext.EmployeeManagement.Where(a => a.EmployeeId == command.EmployeeID).FirstOrDefaultAsync();


            if (employees != null)
            {
                BaseResponse response = new BaseResponse();

                _dbContext.EmployeeManagement.Remove(employees);
                response.ResponseValue = await _dbContext.SaveChangesAsync();
                response.Information = "Record is Deleted";
                return response;
            }
            else
            {
                throw new InvalidIDExceptions();
            }


        }
    }
}
