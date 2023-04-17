using Azure.Core;
using Employee.Model;
using Employee.Moduls.EmployeeManagement.Exeception_Handlings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Xceed.Wpf.Toolkit;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Moduls.EmployeeManagement.Command.Update
{
    
    public class UpdateEmployee : IRequest<ResultResponce>
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
        public List<Model.Educationalqualification> EducationalQualification { get; set; }

    }
    public class UpdateEmployeeHandlers : IRequestHandler<UpdateEmployee, ResultResponce>
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
        public Task<ResultResponce> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {

            ResultResponce response = new ResultResponce();
            
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
                    entity.EducationalQualifications = request.EducationalQualification;
                    dbContext.Update(entity);
                    response.ResponseValue = dbContext.SaveChanges();
                    response.Information = "Employee details Updated";
                    return Task.FromResult(response);

                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
               
                throw new InvalidIDException();
                
            }
          




        }
    }
}
