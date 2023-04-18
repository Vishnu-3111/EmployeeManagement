using Employee.Model;
using MediatR;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Moduls.EmployeeManagement.Quers
{
    /// <summary>
    /// used to get a particular data from the database by using EmployeeID
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
        /// <summary>
        /// Used to get a particular data from the database by using EmployeeID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<Model.EmployeeManagement>> Handle(GetEmployeeByID request, CancellationToken cancellationToken)
        {
            try
            {
                var Employeelist=_dbContext.EmployeeManagement.Where(x=>x.EmployeeId==request.EmployeeID).ToList();
                /*var Employeelist = (from ls in _dbContext.EmployeeManagement
                                    where ls.EmployeeId == request.EmployeeID
                                    select new Model.EmployeeManagement
                                    {
                                        EmployeeId = ls.EmployeeId,
                                        EmployeeName = ls.EmployeeName,
                                        Designation = ls.Designation,
                                        DepartmentName = ls.DepartmentName,
                                        EducationalQualifications = (from ec in _dbContext.educationalqualification
                                                                     where ec.EmployeeManagementEmployeeId == request.EmployeeID
                                                                     select new Model.Educationalqualification
                                                                     {
                                                                         degree = ec.degree,
                                                                         percentage = ec.percentage,
                                                                         EmployeeManagementEmployeeId = ec.EmployeeManagementEmployeeId
                                                                     }).ToList()

                                    }).ToList();*/
                if (Employeelist != null) {
                    return Task.FromResult(Employeelist);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception )
            {
                throw new InvalidIDExceptions();
            }
        }

    }

}
