﻿using Employee.Moduls.EmployeeManagement.Command.Create;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using EntityFrameworkCoreMock;
using Employee.Model;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagements.Command.Create
{
    public class CreateEmployeeShould
    {
         
        DbContextMock<EmpDbContext> dbContextMock;
        CreateEmployeeHandler handler;
         List<Employee.Model.EmployeeManagement> Employeetable=new List<Employee.Model.EmployeeManagement>();
        DbContextOptions<EmpDbContext> dbContextOptions { get; set; } = new DbContextOptionsBuilder<EmpDbContext>().Options;
        public CreateEmployeeShould()
        {
            dbContextMock = new DbContextMock<EmpDbContext>(dbContextOptions);
            handler = new CreateEmployeeHandler(this.dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.EmployeeManagement, Employeetable);
        }
        [Fact]
        public void passvalidation()
        {
          
            var request = new CreateEmployee() { EmployeeName = "vishnu", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            var response = handler.Handle(request, CancellationToken.None);
            dbContextMock.Setup(c => c.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            
            Assert.True(response.Result.ResponseValue!=null);
                //False(response.Result.ResponseValue != null);
        }
    }
}
