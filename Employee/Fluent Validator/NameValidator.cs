using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Employee.Fluent_Validator
{
    public class NameValidator : PropertyValidator
    {
        public NameValidator() : base(" Invalid Name")
        {

        }
        //This Validator Only allows Albhabets
        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex(@"^[a-z]+$", RegexOptions.IgnoreCase);
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
