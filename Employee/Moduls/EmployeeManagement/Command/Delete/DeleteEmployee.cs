using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Net;
using System;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;
using LoggerExtensions = Serilog.LoggerExtensions;
using Employee.LoggerExtention;

namespace Employee.Moduls.Command.Delete
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteEmployee : IRequest<BaseResponse>
    {
        public int EmployeeID { get; set; }
    }
    public class DeleteEmployeeHandlers : IRequestHandler<DeleteEmployee, BaseResponse>
    {
       
        private readonly EmpDbContext _dbContext;
        private IloggerError _logger;
        public DeleteEmployeeHandlers(EmpDbContext dbContext,IloggerError logger)
        {
            _dbContext = dbContext;
            _logger = logger;
           
        }
        //This Handler delete the Employee details using Employee ID
        public async Task<BaseResponse> Handle(DeleteEmployee command, CancellationToken cancellationToken)
        {
            var employees = await _dbContext.EmployeeManagement.Where(a => a.EmployeeId == command.EmployeeID).FirstOrDefaultAsync();
           
            try
            {
                //
                if (employees != null)
                {
                    BaseResponse response = new BaseResponse();
                  //  _dbContext.educationalqualification.Remove(employeequalification);
                    _dbContext.EmployeeManagement.Remove(employees);
                    response.ResponseValue = await _dbContext.SaveChangesAsync();
                    response.Information = "Record is Deleted";
                    return response;
                }
                else
                {
                    throw new InvalidIDExceptions();
                }
            }
            catch (Exception ex ) 
            {
                _logger.Error("error accored");
                throw ex;
              
            }
        }
    }
}
