using Employee.Model;
using Employee.Moduls.EmployeeManagement.Quers.GetEmployeeList;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagements.Query
{
    public class GetEmployeeSholud
    {
        DbContextMock<EmpDbContext> dbContextMock;
        GetEmployeeHandlers handler;
        List<Employee.Model.EmployeeManagement> Employeetable = new List<Employee.Model.EmployeeManagement>() { new Employee.Model.EmployeeManagement() { EmployeeId = 1, EmployeeName = "vishnu", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 } };
        DbContextOptions<EmpDbContext> dbContextOptions { get; set; } = new DbContextOptionsBuilder<EmpDbContext>().Options;
        public GetEmployeeSholud()
        {
            dbContextMock = new DbContextMock<EmpDbContext>(dbContextOptions);
            handler = new GetEmployeeHandlers(this.dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.EmployeeManagement, Employeetable);
        }
        [Fact]
        public void passvalidation()
        {
            var request = new GetEmployee();
            var response = handler.Handle(request, CancellationToken.None);
            Assert.True(response.Result.Count > 0);
        }
    }
}
