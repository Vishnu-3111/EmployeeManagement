using Employee.Model;
using MediatR;
using Serilog;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Moduls.EmployeeManagement.Command.Update
{

    public class UpdateEmployee : IRequest<BaseResponse>
    {
        /// <summary>
        /// Propertys Get and Set Values for Update Opertion in EmployeeManagement Table
        /// </summary>
        public int Id { get; set; }
        public string Employeename { get; set; }

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
        /// <summary>
        /// Dependency injection for EmpDbContext Class for Acessing database
        /// for Update propose
        /// </summary>
        public readonly EmpDbContext dbContext;
        public UpdateEmployeeHandlers(EmpDbContext _dbContext)
        {


            dbContext = _dbContext;
        }
        /// <summary>
        /// Handler method performs for Update operation by getting values from Controller 
        /// and return responce to Controller
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>This method returns How many rows affected and status of update </returns>
        public Task<BaseResponse> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {

            BaseResponse response = new BaseResponse();
            
            try
            {
                
                var entity = dbContext.EmployeeManagement.Where(x => x.EmployeeId == request.Id).FirstOrDefault();

                if (entity != null)
                {


                    entity.EmployeeId = request.Id;
                    entity.EmployeeName = request.Employeename;
                    entity.Pincode = request.Pincode;
                    entity.DepartmentName = request.DepartmentName;
                    entity.Salary = request.Salary;
                    entity.Designation = request.Designation;
                    entity.ManagerID = request.ManagerID;
                    entity.degree = request.degree;
                    entity.percentage = request.percentage;
                    dbContext.Update(entity);
                    response.ResponseValue = dbContext.SaveChanges();
                    response.Information = "Employee details Updated";
                    return Task.FromResult(response);

                }
                else
                {
                    throw new InvalidIDExceptions();
                }
            }
            catch (Exception ex )
            {
                Log.Error("");
                throw;
                
            }
          




        }
    }
}
