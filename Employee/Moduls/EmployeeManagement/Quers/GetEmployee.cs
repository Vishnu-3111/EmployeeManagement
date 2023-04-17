using Employee.Model;
using Employee.Moduls.EmployeeManagement.Command.Create;
using MediatR;

namespace Employee.Moduls.EmployeeManagement.Quers
{
    /// <summary>
    /// Get all records from the Employee Management Table
    /// </summary>
    public class GetEmployee : IRequest<List<Model.EmployeeManagement>>
    {
    }
    public class GetEmployeeHandlers : IRequestHandler<GetEmployee, List<Model.EmployeeManagement>>
    {
        private readonly EmpDbContext _dbContext;
        public GetEmployeeHandlers(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// This handler used to Fetch all records from the Database
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<Model.EmployeeManagement>> Handle(GetEmployee request, CancellationToken cancellationToken)
        {



            var Employeelist = (from ls in _dbContext.EmployeeManagement
                                select new Model.EmployeeManagement
                                {
                                    EmployeeId = ls.EmployeeId,
                                    EmployeeName = ls.EmployeeName,
                                    Designation = ls.Designation,
                                    DepartmentName = ls.DepartmentName,
                                   EducationalQualifications = (from ec in _dbContext.educationalqualification
                                                                 where ec.EmployeeManagementEmployeeId == ls.EmployeeId
                                                                 select new Model.Educationalqualification
                                                                 {
                                                                     degree = ec.degree,
                                                                     percentage = ec.percentage,
                                                                     EmployeeManagementEmployeeId=ec.EmployeeManagementEmployeeId
                                                                 }).ToList()

                                }).ToList();
           return Task.FromResult(Employeelist);
        }
    }
}
