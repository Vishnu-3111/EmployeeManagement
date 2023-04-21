using Employee.Controllers;
using Employee.Moduls.EmployeeManagement.Quers.GetEmployeeList;
using MediatR;
using Moq;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagements.Controller
{
    public class GetListEmployeeControllerUnitTest
    {
        Mock<IMediator> _mediatorMock;
        EmployeeController _employeeController;
        public GetListEmployeeControllerUnitTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Fact]

        public async Task GetListEmployee_ReturnsCorrectResponse()
        {
            #region"Assign"
            var entity = new List<Employee.Model.EmployeeManagement>();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllEmployee>(), default)).ReturnsAsync(entity);

            #endregion

            #region"Act"

            var response = await _employeeController.GetallEmployees();

            #endregion

            #region"Assert"
            Assert.IsAssignableFrom<List<Employee.Model.EmployeeManagement>>(response);
            #endregion
        }

      
    }
}
