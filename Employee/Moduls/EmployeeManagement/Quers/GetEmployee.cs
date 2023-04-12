using Employee.Model;
using MediatR;

namespace Employee.Moduls.EmployeeManagement.Quers
{
    public class GetEmployee : IRequest<List<Employees>>
    {
    }
    public class GetEmployeeHandlers : IRequestHandler<GetEmployee, List<Employees>>
    {
        private readonly EmpDbContext _dbContext;
        public GetEmployeeHandlers(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Employees>> Handle(GetEmployee request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dbContext.Employees.ToList());
        }
    }
}
