using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Employee.Fluent_Validator
{
    public class SalaryValidator : PropertyValidator
    {
        public SalaryValidator() : base("Invalid Salary")
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex(@"^[0-9]*$", RegexOptions.IgnoreCase);
            if (context.PropertyValue != null)
            {

                return regex.IsMatch(context.PropertyValue.ToString());
            }
            else
            {
                return false;
            }
        }
    }
}
