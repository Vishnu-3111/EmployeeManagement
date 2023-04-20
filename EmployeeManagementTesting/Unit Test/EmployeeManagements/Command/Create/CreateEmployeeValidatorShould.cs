using Employee.Moduls.EmployeeManagement.Command.Create;
using FluentValidation.TestHelper;

namespace EmployeeManagementTesting
{
    public class CreateEmployeeValidatorShould
    {
        CreateEmployeeValidator validator;
        public CreateEmployeeValidatorShould()
        {
            validator = new CreateEmployeeValidator();
        }
        #region Unit Test for Employee Name
        [Fact]
        public void FailsOnNameNotNull()
        {
            var request = new CreateEmployee() { EmployeeName = null, Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        [Fact]
        public void FailsOnNameNotempty()
        {
            var request = new CreateEmployee() { EmployeeName = "", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        [Fact]
        public void FailsOnNameNameValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr56", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        [Fact]
        public void EmployeeNamePassValidaton()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        #endregion 
        #region Unit Test For Department Name
        [Fact]
        public void FailsOnDepartmentNameNotNull()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = null, Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        [Fact]
        public void FailsOnDepartmentNameNotEmpty()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        [Fact]
        public void FailsOnDepartmentNameNameValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndu98", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }

        [Fact]
        public void FailsOnDepartmentNameMaximumLength()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujhuytrmnjuytrewd", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        [Fact]
        public void DepartmentNamePassValidation()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndu", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        #endregion
        #region Unit Test For Pincode
        [Fact]
        public void FailsOnPincodeNotEmpty()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 0, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);
        }
        [Fact]
        public void FailsOnPincodeSetValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 54326, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);
        }
        [Fact]
        public void PincodePassValidation()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 543261, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Pincode, request);
        }
        #endregion
        #region Unit Test For Designation

        [Fact]
        public void FailsOnDesignationNotEmpty()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Designation, request);
        }

        [Fact]
        public void FailsOnDesignationSetValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Seor", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Designation, request);
        }
        [Fact]
        public void DesignationPassValidation()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior Engineer", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Designation, request);
        }
        #endregion
        #region Unit Test Validation For ManagerID
        [Fact]
        public void FailsOnManagerNotEmpty()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 0, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.ManagerID, request);
        }
        [Fact]
        public void FailsOnManagerSetValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 431, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.ManagerID, request);
        }
        [Fact]
        public void ManagerPassValidation()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4371, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.ManagerID, request);
        }
        #endregion
        #region Unit test for Degree Validator
        [Fact]
        public void FailsOnDegereeNotEmpty()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.degree, request);
        }
        [Fact]
        public void FailsOnDegereeSetValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4361, degree = "ftr", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.degree, request);
        }
        [Fact]
        public void DegereePassValidation()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4361, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.degree, request);
        }
        #endregion
        #region Unit Test For Percentage Validator
        [Fact]
        public void FailsPercentageNotEmpty()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 0, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.percentage, request);
        }
        [Fact]
        public void FailsOnPercentageInclusiveBetween()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 101, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.percentage, request);
        }
        [Fact]
        public void PercentagePassValidation()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 45, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.percentage, request);
        }

        #endregion

    }
}