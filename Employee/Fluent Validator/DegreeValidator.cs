using FluentValidation.Validators;

namespace Employee.Fluent_Validator
{
    public class DegreeValidator:PropertyValidator
    {
        public DegreeValidator():base("Invalid Degree")
        {

        }
       
        //used to check degree Of employees 
        protected override bool IsValid(PropertyValidatorContext context)
        { 
            List<string> DegreeList = new List<string>();
            DegreeList.Add("B.E");
            DegreeList.Add("B.Sc");
            DegreeList.Add("M.SC");
            DegreeList.Add("B.tec");
            DegreeList.Add("M.E");
            DegreeList.Add("B.Com");
            DegreeList.Add("M.Com");
            DegreeList.Add("B.B.A");
            DegreeList.Add("M.B.A");

            bool results = false;
            for (int i = 0; i < DegreeList.Count; i++)
            {
                bool response = DegreeList[i].Equals(context.PropertyValue.ToString());
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
