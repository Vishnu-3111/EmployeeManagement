using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Quers
{
    public class GetEmployeeByIDValidator : AbstractValidator<GetEmployeeByID>
    {
        public GetEmployeeByIDValidator()
        {
            RuleFor(x => x.EmployeeID).NotEmpty().NotNull();
        }
    }
}
