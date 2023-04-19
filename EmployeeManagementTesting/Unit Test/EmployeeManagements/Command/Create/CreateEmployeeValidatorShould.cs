using Employee.Moduls.EmployeeManagement.Command.Create;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementTesting
{
    public class CreateEmployeeValidatorShould
    {
        CreateEmployeeValidator validator;
        public CreateEmployeeValidatorShould()
        {
            validator =new CreateEmployeeValidator();
        }
        #region Unit Test for Employee Name
        [Fact]
        public void EmployeeNameNotNull()
      {
            var request = new CreateEmployee() {EmployeeName=null,Designation= "Senior", percentage=98,Pincode=654321,ManagerID=4321,degree="B.E",DepartmentName="gf",Salary=6543};
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        [Fact]
        public void EmployeeNameNotempty()
        {
            var request = new CreateEmployee() { EmployeeName = "", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        [Fact]
        public void EmployeeNameNameValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr56", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        [Fact]
        public void EmployeeNameShouldNotHaveValidationError()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "gf", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeName, request);
        }
        #endregion 
        #region Unit Test For Department Name
        [Fact]
        public void DepartmentNameNotNullValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = null, Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        [Fact]
        public void DepartmentNameEmptyValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName ="", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        [Fact]
        public void DepartmentNameNameValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndu98", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }

        [Fact]
        public void DepartmentNameMaximumLengthValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujhuytrmnjuytrewd", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        [Fact]
        public void DepartmentNameShouldNotHaveValidationError()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndu", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.DepartmentName, request);
        }
        #endregion
        #region Unit Test For Pincode
        [Fact]
        public void PincodeNotEmptyValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 0, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);
        }
        [Fact]
        public void PincodeSetValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98,Pincode=54326, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);
        }
        [Fact]
        public void PincodeShouldNotHaveError()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 543261, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Pincode, request);
        }
        #endregion
        #region Unit Test For Designation
        [Fact]
        public void DesignationNotEmptyValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Designation, request);
        }
      
        [Fact]
        public void DesignationSetValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Seor", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.Designation, request);
        }
        [Fact]
        public void DesignationShouldNotHaveError()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Senior", percentage = 98, Pincode = 654321, ManagerID = 4321, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Designation, request);
        }
        #endregion
        #region Unit Test Validation For ManagerID
        [Fact]
        public void ManagerNotEmptyValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 0, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.ManagerID, request);
        }
        [Fact]
        public void ManagerSetValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 431, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.ManagerID, request);
        }
        [Fact]
        public void ManagerShouldNotHaveError()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4371, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.ManagerID, request);
        }
        #endregion
        #region Unit test for Degree Validator
        [Fact]
        public void DegereeNotEmptyValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.degree, request);
        }
        [Fact]
        public void DegereeSetValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4361, degree = "ftr", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.degree, request);
        }
        [Fact]
        public void DegereeShouldNotHaveError()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 98, Pincode = 654321, ManagerID = 4361, degree = "B.E", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.degree, request);
        }
        #endregion
        #region Unit Test For Percentage Validator
        [Fact]
        public void PercentageNotEmptyValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 0, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.percentage, request);
        }
        [Fact]
        public void PercentageInclusiveBetweenValidator()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 101, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldHaveValidationErrorFor(x => x.percentage, request);
        }
        [Fact]
        public void PercentageShouldNotHaveError()
        {
            var request = new CreateEmployee() { EmployeeName = "nr", Designation = "Proje", percentage = 45, Pincode = 654321, ManagerID = 4361, degree = "", DepartmentName = "ndujh", Salary = 6543 };
            validator.ShouldNotHaveValidationErrorFor(x => x.percentage, request);
        }

        #endregion


       
    }
}