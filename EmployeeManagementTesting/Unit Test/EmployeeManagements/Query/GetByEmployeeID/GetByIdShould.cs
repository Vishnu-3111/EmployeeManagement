using Employee.Model;
using Employee.Moduls.EmployeeManagement.Quers.GetEmployeeById;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagements.Query
{
    public class GetByIdShould
    {
        DbContextMock<EmpDbContext> dbContextMock;
        GetEmployeeByIDHandlers handler;
        List<Employee.Model.EmployeeManagement> Employeetable = new List<Employee.Model.EmployeeManagement>() { new Employee.Model.EmployeeManagement() { EmployeeId = 1, EmployeeName = "vishnu", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 } };
        DbContextOptions<EmpDbContext> dbContextOptions { get; set; } = new DbContextOptionsBuilder<EmpDbContext>().Options;
        public GetByIdShould()
        {
            dbContextMock = new DbContextMock<EmpDbContext>(dbContextOptions);
            handler = new GetEmployeeByIDHandlers(this.dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.EmployeeManagement, Employeetable);
        }
        [Fact]
        public void passvalidation()
        {
            var request = new GetEmployeeByID() { EmployeeID = 1 };
            var response = handler.Handle(request, CancellationToken.None);
            Assert.True(response.Result.Count > 0);
        }

        [Fact]
        public void ExceptionValidation()
        {
            var request = new GetEmployeeByID() { };
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            Assert.IsType<InvalidIDExceptions>(response.Result);
        }
    }
}
