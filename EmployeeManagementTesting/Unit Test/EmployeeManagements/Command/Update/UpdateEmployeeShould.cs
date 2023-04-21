using Employee.Model;
using Employee.Moduls.EmployeeManagement.Command.Update;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using static Employee.Moduls.EmployeeManagement.Exeception_Handlings.InvalidIDException;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagements.Command.Update
{
    public class UpdateEmployeeShould
    {

        DbContextMock<EmpDbContext> dbContextMock;
        UpdateEmployeeHandlers handler;
        List<Employee.Model.EmployeeManagement> Employeetable = new List<Employee.Model.EmployeeManagement>() { new Employee.Model.EmployeeManagement() { EmployeeId = 1, EmployeeName = "vishnu", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 } };
        DbContextOptions<EmpDbContext> dbContextOptions { get; set; } = new DbContextOptionsBuilder<EmpDbContext>().Options;
        public UpdateEmployeeShould()
        {
            dbContextMock = new DbContextMock<EmpDbContext>(dbContextOptions);
            handler = new UpdateEmployeeHandlers(this.dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.EmployeeManagement, Employeetable);
        }
        [Fact]
        public void passvalidator()
        {
            var request = new UpdateEmployee() { EmployeeID = 1, EmployeeName = "vishn", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            dbContextMock.Setup(c => c.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            var response = handler.Handle(request, CancellationToken.None);
            Assert.True(response.Result.ResponseValue != 0);

        }

        [Fact]
        public void ExceptionValidator()
        {
            var request = new UpdateEmployee() { };
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            Assert.IsType<InvalidIDExceptions>(response.Result);
        }

    }
}
