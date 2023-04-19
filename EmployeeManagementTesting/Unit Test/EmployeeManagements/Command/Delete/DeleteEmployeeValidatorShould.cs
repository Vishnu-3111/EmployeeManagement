using Employee.Moduls.Command.Delete;
using Employee.Moduls.EmployeeManagement.Command.Delete;
using Employee.Moduls.EmployeeManagement.Quers;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void GetByEmployeeIDNotEmptyValidator()
        {
            var request = new DeleteEmployee() { EmployeeID = 0 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        [Fact]
        public void GetByEmployeeIDNotGreaterthanValidator()
        {
            var request = new DeleteEmployee() { EmployeeID = -10, };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        [Fact]
        public void GetByEmployeeIDShouldNotHaveValidationError()
        {
            var request = new DeleteEmployee() { EmployeeID = 3 };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        #endregion
    }
}
