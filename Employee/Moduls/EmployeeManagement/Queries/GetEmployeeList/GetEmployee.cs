﻿using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace Employee.Moduls.EmployeeManagement.Quers.GetEmployeeList
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

        // This handler used to Fetch all records from the Database

        public Task<List<Model.EmployeeManagement>> Handle(GetEmployee request, CancellationToken cancellationToken)
        {


            var Employeelist = _dbContext.EmployeeManagement.ToListAsync();


            if (Employeelist != null)
            {
                return Employeelist;
            }
            else
            {
                throw new NoDataFound();
            }


        }
    }
}
