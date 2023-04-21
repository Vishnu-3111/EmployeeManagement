using Employee.Controllers;
using Employee.Moduls.EmployeeManagement.Quers.GetEmployeeById;
using MediatR;
using Moq;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagements.Controller
{
    public class GetByEmployeeIDControllerUnitTest
    {
        Mock<IMediator> _mediatorMock;
        EmployeeController _employeeController;
        public GetByEmployeeIDControllerUnitTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Theory]
        [InlineData(1)]

        public async Task GetByEmployeeId_ReturnsCorrectResponse(int id)
        {
            #region"Assign"
            var entity = new List<Employee.Model.EmployeeManagement>();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetEmployeeByID>(), default)).ReturnsAsync(entity);

            #endregion

            #region"Act"

            var response = await _employeeController.GetEmployeebyid(id);

            #endregion

            #region"Assert"
            Assert.IsAssignableFrom<List<Employee.Model.EmployeeManagement>>(response);
            #endregion
        }
    }
}
