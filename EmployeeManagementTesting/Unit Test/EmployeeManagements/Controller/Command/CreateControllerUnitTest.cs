using Employee.Controllers;
using Employee.Model;
using Employee.Moduls.EmployeeManagement.Command.Create;
using MediatR;
using Moq;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagements.Controller
{

    public class CreateControllerUnitTest

    {
        Mock<IMediator> _mediatorMock;
        EmployeeController _employeeController;
        public CreateControllerUnitTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Theory]
        [MemberData(nameof(TestDataProvider.CreateObject), MemberType = typeof(TestDataProvider))]

        public async Task CreateEmployee_ReturnsValidResponse(CreateEmployee data)
        {
            #region"Assign"

            var entity = new BaseResponse() { ResponseValue = 1, Information = "Employee Details Created" };
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateEmployee>(), default)).ReturnsAsync(entity);

            #endregion

            #region"Act"
            var response = await _employeeController.CreateEmployee(data);
            #endregion

            #region"Assert"
            Assert.IsAssignableFrom<BaseResponse>(response);
            #endregion
        }
        #region Test Data Provider
        public class TestDataProvider
        {
            public static IEnumerable<object[]> CreateObject()
            {

                yield return new object[] {
                    new CreateEmployee()
                    {
                        EmployeeName = "vishnu",
                        Designation = "Senior Engineer",
                        percentage = 98,
                        Pincode = 654321,
                        ManagerID = 4321,
                        degree = "B.E",
                        DepartmentName = "gf",
                        Salary = 6543
                    }
                };
            }
           
        }
      
        #endregion
    }
}

