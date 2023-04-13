using Employee.Fluent_Validator;
using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Command.Update
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployee>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(model => model.Id).NotEmpty().NotNull();
            RuleFor(model => model.Empname).NotNull().NotEmpty().SetValidator(new NameValidation());
            RuleFor(model => model.depName).NotNull().NotEmpty().SetValidator(new NameValidation());
            RuleFor(model => model.Pincode).NotNull().SetValidator(new PincodeValidators());
            RuleFor(model => model.Desgnation).NotNull().MaximumLength(10);
            RuleFor(model => model.MangerID).SetValidator(new ManagerValidator()).NotEmpty();
            RuleFor(model => model.salary).NotEmpty().NotNull().SetValidator(new SalaryValidator());
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
