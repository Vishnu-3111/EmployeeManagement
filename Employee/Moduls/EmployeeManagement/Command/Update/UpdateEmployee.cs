using Employee.Model;
using MediatR;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Moduls.EmployeeManagement.Command.Update
{

    public class UpdateEmployee : IRequest<BaseResponse>
    {
        /// <summary>
        /// Propertys Get and Set Values for Update Opertion in EmployeeManagement 
        /// </summary>
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int Pincode { get; set; }
        public int ManagerID { get; set; }
        public int Salary { get; set; }
        public string DepartmentName { get; set; }
        public string degree { get; set; }
        public int percentage { get; set; }

    }
    public class UpdateEmployeeHandlers : IRequestHandler<UpdateEmployee, BaseResponse>
    {

        public readonly EmpDbContext dbContext;
        public UpdateEmployeeHandlers(EmpDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        /// <summary>
        /// Handler method performs for Update operation by getting values from Controller 
        /// and return responce to Controller
        /// </summary>


        public async Task<BaseResponse> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {
            BaseResponse response = new BaseResponse();

            var entity = dbContext.EmployeeManagement.Where(x => x.EmployeeId == request.EmployeeID).FirstOrDefault();

            if (entity != null)
            {
                entity.EmployeeId = request.EmployeeID;
                entity.EmployeeName = request.EmployeeName;
                entity.Pincode = request.Pincode;
                entity.DepartmentName = request.DepartmentName;
                entity.Salary = request.Salary;
                entity.Designation = request.Designation;
                entity.ManagerID = request.ManagerID;
                entity.degree = request.degree;
                entity.percentage = request.percentage;
                dbContext.Update(entity);
                response.ResponseValue = await dbContext.SaveChangesAsync();
                response.Information = "Employee details Updated";
                return response;

            }
            else
            {
                throw new InvalidIDExceptions();
            }

        }
    }
}
