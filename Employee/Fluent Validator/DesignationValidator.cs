using FluentValidation.Validators;

namespace Employee.Fluent_Validator
{
    public class DesignationValidator:PropertyValidator
    {
        public DesignationValidator() :base("Enter Valid Designation")
        {
           

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            List<string> Designationdetails = new List<string>();
            Designationdetails.Add("Project Manager");
            Designationdetails.Add("TeamLeader");
            Designationdetails.Add("Junior Engineer");
            Designationdetails.Add("Senior Senior");
            var result = context.PropertyValue.ToString();
            bool results=false;
            for(int i = 0; i < Designationdetails.Count; i++)
            {
                bool response=Designationdetails[i].Equals(result);
                if(response==true)
                {
                    results=true;
                    break;
                }
                

            }

            return results;
            
            
            
        }
    }
}
