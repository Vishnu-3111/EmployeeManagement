using Employee.Controllers;
using Employee.Model;
using Employee.Moduls.EmployeeManagement.Command.Create;
using Employee.Moduls.EmployeeManagement.Command.Update;
using MediatR;
using Moq;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagements.Controller
{
    public class UpdateControllerUnitTest
    {
        Mock<IMediator> _mediatorMock;
        EmployeeController _employeeController;
        public UpdateControllerUnitTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Theory]
        [MemberData(nameof(TestDataProvider.CreateObject), MemberType = typeof(TestDataProvider))]
        public async Task UpdateEmployee_ReturnsCorrectResponse(UpdateEmployee data)
        {
            #region"Assign"

            var entity = new BaseResponse() { ResponseValue = 1, Information = "Employee Details Updated" };
            _mediatorMock.Setup(x => x.Send(It.IsAny<UpdateEmployee>(), default)).ReturnsAsync(entity);


            #endregion

            #region"Act"
            
            var response = await _employeeController.UpdateEemployee(data);
            #endregion

            #region"Assert"
            Assert.IsAssignableFrom<BaseResponse>(response);
            #endregion
        }

       
        public class TestDataProvider
        {
            public static IEnumerable<object[]> CreateObject()
            {

                yield return new object[] {
                    new UpdateEmployee()
                    {
                        EmployeeID = 1,
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
                yield return new object[] {
                    new UpdateEmployee()
                    {
                     
                    }
                };

            }
        }
    }
}
