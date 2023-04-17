
using Employee.Fluent_Validator;
using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Command.Create
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployee>
    {/// <summary>
    /// This class used to validating the user entered details are in correct format
    /// in createemployee class
    /// </summary>
        public CreateEmployeeValidator()
        {
            RuleFor(model => model.EmployeeName).NotNull().NotEmpty().SetValidator(new NameValidation());
            RuleFor(model => model.DepartmentName).NotNull().NotEmpty().MaximumLength(10).SetValidator(new NameValidation());
            RuleFor(model => model.Pincode).NotEmpty().NotNull().SetValidator(new PincodeValidators());
            RuleFor(model => model.Designation).NotNull().NotEmpty().SetValidator(new DesignationValidator());
            RuleFor(model => model.ManagerID).SetValidator(new ManagerValidator()).NotEmpty();
            RuleFor(model => model.Salary).NotEmpty().NotNull().SetValidator(new SalaryValidator());
            RuleForEach(x => x.EducationalQualification).ChildRules(child =>
            {
                child.RuleFor(x => x.degree).NotEmpty().NotNull().SetValidator(new DegreeValidator());
            }
           );

            RuleForEach(x => x.EducationalQualification).ChildRules(child =>
            {
                child.RuleFor(x => x.percentage).NotEmpty().NotNull().InclusiveBetween(0, 100);
            }
            );
        }
    }
}
