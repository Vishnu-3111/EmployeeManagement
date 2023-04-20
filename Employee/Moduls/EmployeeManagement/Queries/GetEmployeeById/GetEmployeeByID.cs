using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Moduls.EmployeeManagement.Quers.GetEmployeeById
{
    /// <summary>
    /// used to get employee information 
    /// </summary>
    public class GetEmployeeByID : IRequest<List<Model.EmployeeManagement>>
    {
        public int EmployeeID { get; set; }
    }
    public class GetEmployeeByIDHandlers : IRequestHandler<GetEmployeeByID, List<Model.EmployeeManagement>>
    {
        private readonly EmpDbContext _dbContext;
        public GetEmployeeByIDHandlers(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Model.EmployeeManagement>> Handle(GetEmployeeByID request, CancellationToken cancellationToken)
        {

            var Employeelist = _dbContext.EmployeeManagement.Where(x => x.EmployeeId == request.EmployeeID).ToListAsync();

            if (Employeelist.Result.Count > 0)
            {
                return Employeelist;
            }
            else
            {
                throw new InvalidIDExceptions();
            }


        }

    }

}
