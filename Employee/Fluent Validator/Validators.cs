using Employee.Model;
using FluentValidation;

namespace Employee.Fluent_Validator
{
    
    public class Validators:AbstractValidator<Employees>
    {
        public Validators() 
        {
            RuleFor(model => model.Empname).NotNull().NotEmpty().MaximumLength(20).WithMessage("Employee Name Cannot Empty");
            RuleFor(model => model.depName).NotNull().NotEmpty().MaximumLength(10);
            RuleFor(model => model.Pincode).GreaterThanOrEqualTo(600000).NotEmpty().NotNull().WithMessage("Invalid Pincode");
            RuleFor(model => model.Desgnation).NotNull().MaximumLength(10);
            RuleFor(model => model.MangerID).GreaterThan(6000).NotEmpty().WithMessage("Invalid Manager Id");
            RuleFor(model => model.salary).NotEmpty().NotNull();
        }

    }
}
