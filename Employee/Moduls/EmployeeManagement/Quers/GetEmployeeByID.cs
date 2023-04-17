using Employee.Model;
using MediatR;

namespace Employee.Moduls.EmployeeManagement.Quers
{
    /// <summary>
    /// used to get a particular data from the database by using EmployeeID
    /// </summary>
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
        /// <summary>
        /// Used to get a particular data from the database by using EmployeeID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Model.EmployeeManagement> Handle(GetEmployeeByID request, CancellationToken cancellationToken)
        {

            return Task.FromResult(_dbContext.EmployeeManagement.Where(x => x.EmployeeId == request.EmployeeID).FirstOrDefault());

        }

    }

}
