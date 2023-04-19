using Employee.Moduls.EmployeeManagement.Command.Create;
using Employee.Moduls.EmployeeManagement.Command.Update;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementTesting.Unit_Test.EmployeeManagement.Command.Update
{
    public class UpdateEmployeeValidatorShould
    {
        UpdateEmployeeValidator validator;
       public UpdateEmployeeValidatorShould()
        {
            validator = new UpdateEmployeeValidator();
        }

        #region Unit Test for Employee Name
        [Fact]
        public void UpdateEmployeeNameNotNull()
        {
            var request = new UpdateEmployee() { EmployeeName = null, Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        [Fact]
        public void UpdateEmployeeNameNotempty()
        {
            var request = new UpdateEmployee() { EmployeeName = "", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        [Fact]
        public void UpdateEmployeeNameNameValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr56", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        [Fact]
        public void UpdateEmployeeNameShouldNotHaveValidationError()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        #endregion 
        #region Unit Test For Department Name
        [Fact]
        public void UpdateDepartmentNameNotNullValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = null, Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        [Fact]
        public void UpdateDepartmentNameEmptyValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        [Fact]
        public void UpdateDepartmentNameNameValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndu98", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        [Fact]
        public void UpdateDepartmentNameShouldNotHaveValidationError()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndu", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        #endregion
        #region Unit Test For Pincode
        [Fact]
        public void UpdatePincodeNotEmptyValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 0, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);
        }
        [Fact]
        public void UpdatePincodeSetValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 54326, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);
        }
        [Fact]
        public void UpdatePincodeShouldNotHaveError()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 543261, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Pincode, request);
        }
        #endregion
        #region Unit Test For Designation
        [Fact]
        public void UpdateDesignationNotEmptyValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Designation, request);
        }

        [Fact]
        public void UpdateDesignationSetValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Seor", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Designation, request);
        }
        [Fact]
        public void UpdateDesignationShouldNotHaveError()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Designation, request);
        }
        #endregion
        #region Unit Test Validation For ManagerID
        [Fact]
        public void UpdateManagerNotEmptyValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 0, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.ManagerID, request);
        }
        [Fact]
        public void UpdateManagerSetValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 431, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.ManagerID, request);
        }
        [Fact]
        public void UpdateManagerShouldNotHaveError()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4371, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.ManagerID, request);
        }
        #endregion
        #region Unit test for Degree Validator
        [Fact]
        public void UpdateDegereeNotEmptyValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.degree, request);
        }
        [Fact]
        public void UpdateDegereeSetValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4361, degree = "ftr", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.degree, request);
        }
        [Fact]
        public void UpdateDegereeShouldNotHaveError()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4361, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.degree, request);
        }
        #endregion
        #region Unit Test For Percentage Validator
        [Fact]
        public void UpdatePercentageNotEmptyValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 0, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.percentage, request);
        }
        [Fact]
        public void UpdatePercentageInclusiveBetweenValidator()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 101, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.percentage, request);
        }
        [Fact]
        public void UpdatePercentageShouldNotHaveError()
        {
            var request = new UpdateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 45, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.percentage, request);
        }

        #endregion
        #region Unit Test For EmployeeID
        [Fact]
        public void UpdateEmployeeIDNotEmptyValidator()
        {
            var request = new UpdateEmployee() { EmployeeID=0,EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndu", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        [Fact]
        public void UpdateEmployeeIDNotGreaterthanValidator()
        {
            var request = new UpdateEmployee() { EmployeeID = -10, EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndu", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        [Fact]
        public void UpdateEmployeeIDShouldNotHaveValidationError()
        {
            var request = new UpdateEmployee() { EmployeeID = 3, EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndu", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeID, request);
        }
        #endregion

    }
}
