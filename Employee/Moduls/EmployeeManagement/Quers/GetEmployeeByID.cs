using Employee.Model;
using MediatR;

namespace Employee.Moduls.EmployeeManagement.Quers
{
    public class GetEmployeeByID : IRequest<Employees>
    {
        public int EmployeeID { get; set; }
    }
    public class GetEmployeeByIDHandlers : IRequestHandler<GetEmployeeByID, Employees>
    {
        private readonly EmpDbContext _dbContext;
        public GetEmployeeByIDHandlers(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Employees> Handle(GetEmployeeByID request, CancellationToken cancellationToken)
        {

            return Task.FromResult(_dbContext.Employees.Where(x => x.EmpId == request.EmployeeID).FirstOrDefault());

        }

    }

}
