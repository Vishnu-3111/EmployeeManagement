using Employee.Model;
using MediatR;

namespace Employee.Moduls.EmployeeManagement.Quers
{
    public class GetEmployeeByID : IRequest<Model.EmployeeManagement>
    {
        public int EmployeeID { get; set; }
    }
    public class GetEmployeeByIDHandlers : IRequestHandler<GetEmployeeByID, Model.EmployeeManagement>
    {
        private readonly EmpDbContext _dbContext;
        public GetEmployeeByIDHandlers(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Model.EmployeeManagement> Handle(GetEmployeeByID request, CancellationToken cancellationToken)
        {

            return Task.FromResult(_dbContext.EmployeeManagement.Where(x => x.EmployeeId == request.EmployeeID).FirstOrDefault());

        }

    }

}
