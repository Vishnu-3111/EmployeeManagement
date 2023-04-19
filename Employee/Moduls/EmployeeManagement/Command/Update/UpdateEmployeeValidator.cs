using Employee.Fluent_Validator;
using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Command.Update
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployee>
    {/// <summary>
     /// This class used to validating the user entered details are in correct format
     /// in Updateemployee class
     /// </summary>
        public UpdateEmployeeValidator()
        {
            RuleFor(model => model.EmployeeID).NotEmpty().GreaterThan(0);
            RuleFor(model => model.EmployeeName).NotNull().NotEmpty().SetValidator(new NameValidation());
            RuleFor(model => model.DepartmentName).NotNull().NotEmpty().SetValidator(new NameValidation());
            RuleFor(model => model.Pincode).NotNull().SetValidator(new PincodeValidators());
            RuleFor(model => model.Designation).NotNull().NotEmpty().SetValidator(new DesignationValidator());
            RuleFor(model => model.ManagerID).SetValidator(new ManagerValidator()).NotEmpty();
            RuleFor(model => model.Salary).NotEmpty().NotNull().SetValidator(new SalaryValidator());
            RuleFor(model => model.degree).NotEmpty().NotNull().SetValidator(new DegreeValidator());
            RuleFor(model => model.percentage).NotEmpty().NotNull().InclusiveBetween(0,100);
            /*  RuleForEach(x => x.EducationalQualification).ChildRules(child =>
              {
                  child.RuleFor(x => x.degree).NotEmpty().NotNull().SetValidator(new DegreeValidator());
              }
             );

              RuleForEach(x => x.EducationalQualification).ChildRules(child =>
              {
                  child.RuleFor(x => x.percentage).NotEmpty().NotNull().InclusiveBetween(0, 100);
              }
              );*/
        }

    }
}
