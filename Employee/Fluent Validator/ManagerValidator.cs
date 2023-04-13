using FluentValidation.Validators;

namespace Employee.Fluent_Validator
{
    public class ManagerValidator : PropertyValidator
    {
        public ManagerValidator() : base("Invalid ID")
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string GetData = context.PropertyValue.ToString();
            if (GetData.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
