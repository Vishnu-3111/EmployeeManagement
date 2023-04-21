using FluentValidation.Validators;

namespace Employee.Fluent_Validator
{
    public class DesignationValidator : PropertyValidator
    {
        public DesignationValidator() : base("Invalid Designation")
        {


        }

        // Used to Validate Designation

        protected override bool IsValid(PropertyValidatorContext context)
        {
            List<string> Designationdetails = new List<string>();
            Designationdetails.Add("Project Manager");
            Designationdetails.Add("Team Leader");
            Designationdetails.Add("Junior Engineer");
            Designationdetails.Add("Senior Engineer");
            Designationdetails.Add("C.E.O");

            bool results = false;
            for (int i = 0; i < Designationdetails.Count; i++)
            {
                bool response = Designationdetails[i].Equals(context.PropertyValue.ToString());
                if (response == true)
                {
                    results = true;
                    break;
                }


            }

            return results;

        }
    }
}
