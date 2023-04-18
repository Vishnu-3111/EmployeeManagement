using FluentValidation.Validators;

namespace Employee.Fluent_Validator
{
    public class DegreeValidator:PropertyValidator
    {
        public DegreeValidator():base("Enter Valid Degree")
        {

        }
        /// <summary>
        /// This method allows to user enter a Valid Degrees by fluent validation Control
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>

        protected override bool IsValid(PropertyValidatorContext context)
        { 
            List<string> DegreeList = new List<string>();
            DegreeList.Add("B.E");
            DegreeList.Add("B.Sc");
            DegreeList.Add("MSC");
            DegreeList.Add("B.tec");

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
