using Employee.Moduls.Command.Delete;
using Employee.Moduls.EmployeeManagement.Command.Delete;
using FluentValidation.TestHelper;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagement.Command.Delete
{
    public class DeleteEmployeeValidatorShould
    {
        DeleteEmployeevalidator validator;
        public DeleteEmployeeValidatorShould()
        {
            validator = new DeleteEmployeevalidator();
        }
        #region Unit Test For EmployeeID
        [Fact]
        public void FailsEmployeeIDNotEmpty()
        {
            var request = new DeleteEmployee() { EmployeeID = 0 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        [Fact]
        public void FailsEmployeeIDNotGreaterthan()
        {
            var request = new DeleteEmployee() { EmployeeID = -10, };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        [Fact]
        public void EmployeeIDPassValidation()
        {
            var request = new DeleteEmployee() { EmployeeID = 3 };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        #endregion
    }
}
