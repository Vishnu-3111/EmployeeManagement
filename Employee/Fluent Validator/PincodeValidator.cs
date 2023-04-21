using FluentValidation.Validators;

namespace Employee.Fluent_Validator
{
    public class PincodeValidator : PropertyValidator
    {
        public PincodeValidator() : base("Invalid Pincode")
        {

        }
        //Pincode Length should be greater than 6 digts
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
