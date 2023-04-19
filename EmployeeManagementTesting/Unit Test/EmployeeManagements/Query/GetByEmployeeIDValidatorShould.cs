using Employee.Moduls.EmployeeManagement.Command.Update;
using Employee.Moduls.EmployeeManagement.Quers;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagement.Query
{
    public class GetByEmployeeIDValidatorShould
    {
        GetEmployeeByIDValidator validator;
        public GetByEmployeeIDValidatorShould()
        {
            validator = new GetEmployeeByIDValidator();
        }
        #region Unit Test For EmployeeID
        [Fact]
        public void GetByEmployeeIDNotEmptyValidator()
        {
            var request = new GetEmployeeByID() { EmployeeID=0 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        [Fact]
        public void GetByEmployeeIDNotGreaterthanValidator()
        {
            var request = new GetEmployeeByID() { EmployeeID = -10,};
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        [Fact]
        public void GetByEmployeeIDShouldNotHaveValidationError()
        {
            var request = new GetEmployeeByID() {EmployeeID = 3 };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        #endregion
    }
}
