using Employee.Controllers;
using Employee.Model;
using Employee.Moduls.Command.Delete;
using MediatR;
using Moq;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagements.Controller
{
    public class DeleteControllerUnitTest
    {
        Mock<IMediator> _mediatorMock;
        EmployeeController _employeeController;
        public DeleteControllerUnitTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Theory]
        [InlineData(1)]

        public async Task DeleteEmployee_ReturnsCorrectResponse(int id)
        {
            #region"Assign"

            var entity = new BaseResponse() { ResponseValue = 1, Information = "Employee Details Deleted" };
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteEmployee>(), default)).ReturnsAsync(entity);

            #endregion

            #region"Act"
            var response = await _employeeController.DeleteEmployee(id);
            #endregion

            #region"Assert"
            Assert.IsAssignableFrom<BaseResponse>(response);
            #endregion
        }

        [Theory]
        [InlineData(1)]

        public async Task DeleteEmployee_ReturnsFailResponse(int id)
        {
            #region"Assign"

            var entity = new BaseResponse() { ResponseValue = 0, Information = "" };
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteEmployee>(), default)).ReturnsAsync(entity);


            #endregion

            #region"Act"
            var response = await _employeeController.DeleteEmployee(id);
            #endregion

            #region"Assert"

            Assert.NotEqual(1, response.ResponseValue);
            #endregion
        }

    }
}
