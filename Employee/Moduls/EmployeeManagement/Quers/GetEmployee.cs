using Employee.Model;
using Employee.Moduls.EmployeeManagement.Command.Create;
using MediatR;

namespace Employee.Moduls.EmployeeManagement.Quers
{
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
                                                                 where ec.EmployeesEmpId == ls.EmployeeId
                                                                 select new Model.Educationalqualification
                                                                 {
                                                                     EmployeesEmpId = ec.EmployeesEmpId,
                                                                     degree = ec.degree,
                                                                     percentage = ec.percentage
                                                                 }).ToList<Model.Educationalqualification>()

                                }).ToList<Model.EmployeeManagement>();
            return Task.FromResult(Employeelist);
        }
    }
}
