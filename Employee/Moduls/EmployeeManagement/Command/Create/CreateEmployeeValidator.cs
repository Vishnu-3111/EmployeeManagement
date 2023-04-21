
using Employee.Fluent_Validator;
using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Command.Create
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployee>
    {
        // used to validating the user entered details are in correct format in createEmployee class

        public CreateEmployeeValidator()
        {
            RuleFor(model => model.EmployeeName).NotNull().NotEmpty().SetValidator(new NameValidator());
            RuleFor(model => model.DepartmentName).NotNull().NotEmpty().MaximumLength(20).SetValidator(new NameValidator());
            RuleFor(model => model.Pincode).NotEmpty().SetValidator(new PincodeValidator());
            RuleFor(model => model.Designation).NotEmpty().SetValidator(new DesignationValidator()).When(x => x.Designation != null);
            RuleFor(model => model.ManagerID).SetValidator(new ManagerValidator()).NotEmpty();
            RuleFor(model => model.degree).NotEmpty().SetValidator(new DegreeValidator()).When(x => x.degree != null);
            RuleFor(model => model.percentage).NotEmpty().InclusiveBetween(0, 100);

        }
    }
}
