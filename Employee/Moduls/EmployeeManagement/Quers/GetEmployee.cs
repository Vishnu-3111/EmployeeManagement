using Employee.Model;
using MediatR;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

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


            try
            {
                var Employeelist = _dbContext.EmployeeManagement.ToList();
               /* var Employeelist = (from ls in _dbContext.EmployeeManagement
                                    select new Model.EmployeeManagement
                                    {
                                        EmployeeId = ls.EmployeeId,
                                        EmployeeName = ls.EmployeeName,
                                        Designation = ls.Designation,
                                        DepartmentName = ls.DepartmentName,
                                        Pincode = ls.Pincode,
                                        ManagerID = ls.ManagerID,
                                        Salary=ls.Salary,
                                        EducationalQualifications = (from ec in _dbContext.educationalqualification
                                                                     where ec.EmployeeManagementEmployeeId == ls.EmployeeId
                                                                     select new Model.Educationalqualification
                                                                     {
                                                                         degree = ec.degree,
                                                                         percentage = ec.percentage,
                                                                         EmployeeManagementEmployeeId = ec.EmployeeManagementEmployeeId
                                                                     }).ToList()

                                    }).ToList();*/
                if (Employeelist != null)
                {
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
