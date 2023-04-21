using Employee.Model;
using Employee.Moduls.Command.Delete;
using Employee.Moduls.EmployeeManagement.Command.Update;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagements.Command.Delete
{
    public class DeleteEmployeeShould
    {
        DbContextMock<EmpDbContext> dbContextMock;
        DeleteEmployeeHandlers handler;
        List<Employee.Model.EmployeeManagement> Employeetable = new List<Employee.Model.EmployeeManagement>() { new Employee.Model.EmployeeManagement() { EmployeeId = 1, EmployeeName = "vishnu", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 } };
        DbContextOptions<EmpDbContext> dbContextOptions { get; set; } = new DbContextOptionsBuilder<EmpDbContext>().Options;
        public DeleteEmployeeShould()
        {
            dbContextMock = new DbContextMock<EmpDbContext>(dbContextOptions);
            handler = new DeleteEmployeeHandlers(this.dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.EmployeeManagement, Employeetable);
        }
        [Fact]
        public void passvalidator()
        {
            var request = new DeleteEmployee() { EmployeeID = 1 };
            dbContextMock.Setup(c => c.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            var response = handler.Handle(request, CancellationToken.None);
            Assert.True(response.Result.ResponseValue != 0);

        }

        [Fact]
        public void ExceptionValidator()
        {
            var request = new DeleteEmployee() { };
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            Assert.IsType<InvalidIDExceptions>(response.Result);
        }
    }
}
