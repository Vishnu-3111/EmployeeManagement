using FluentValidation.Validators;

namespace Employee.Fluent_Validator
{
    public class PincodeValidators : PropertyValidator
    {
        public PincodeValidators() : base("Invalid Pincode")
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string GetData = context.PropertyValue.ToString();
            if (GetData.Length < 6)
            {
                return false;
            }
            else
            {
                return true;
            }


        }
    }
}
