using Employee.Moduls.EmployeeManagement.Quers.GetEmployeeById;
using FluentValidation.TestHelper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

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
        public void FailsEmployeeIDNotEmpty()
        {
            var request = new GetEmployeeByID() { EmployeeID = 0 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        [Fact]
        public void FailsEmployeeIDNotGreaterthan()
        {
            var request = new GetEmployeeByID() { EmployeeID = -10, };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        [Fact]
        public void EmployeeIDPassValidation()
        {
            var request = new GetEmployeeByID() { EmployeeID = 3 };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        #endregion




    }
       
}
