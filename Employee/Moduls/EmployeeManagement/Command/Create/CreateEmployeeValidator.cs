
using Employee.Fluent_Validator;
using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Command.Create
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployee>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(model => model.Empname).NotNull().NotEmpty().SetValidator(new NameValidation());
            RuleFor(model => model.depName).NotNull().NotEmpty().MaximumLength(10).SetValidator(new NameValidation());
            RuleFor(model => model.Pincode).NotEmpty().NotNull().SetValidator(new PincodeValidators());
            RuleFor(model => model.Desgnation).NotNull().MaximumLength(10);
            RuleFor(model => model.MangerID).SetValidator(new ManagerValidator()).NotEmpty();
            RuleFor(model => model.salary).NotEmpty().NotNull().SetValidator(new SalaryValidator());
        }
    }
}
