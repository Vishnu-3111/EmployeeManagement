using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{
    public class Employees
    {
        [Key]
       public int EmpId { get; set; }
        public string Empname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Desgnation { get; set; }
        public int Pincode { get; set; }
        public int MangerID { get; set; }
        public int salary { get; set; }
        public string depName { get; set; }
    }
    public class employeevalidator : AbstractValidator<Employees>
    {
        public employeevalidator()
        {
            RuleFor(model => model.Empname).NotEmpty().Length(3,20);
            RuleFor(model => model.depName).MaximumLength(3);
            RuleFor(model => model.Pincode).NotEmpty();
            RuleFor(model => model.Desgnation).Length(3, 10);
            RuleFor(model => model.MangerID).NotEmpty();
            RuleFor(model => model.salary).NotEmpty();

        }
    }
}
