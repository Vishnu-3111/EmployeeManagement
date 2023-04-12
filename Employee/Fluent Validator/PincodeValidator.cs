using Employee.Model;
using FluentValidation;
using FluentValidation.Validators;

namespace Employee.Fluent_Validator
{
    public class PincodeValidator : PropertyValidator<Employees,int>
    {
        public PincodeValidator(string errormessage = "default message") : base(errormessage)
        {
        }

        public override string Name => throw new NotImplementedException();

        public override bool IsValid(ValidationContext<Employees> context, int value)
        {
            throw new NotImplementedException();
        }

       
    }
}
