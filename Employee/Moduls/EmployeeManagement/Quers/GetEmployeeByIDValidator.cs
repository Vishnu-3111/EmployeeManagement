using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Quers
{
    public class GetEmployeeByIDValidator : AbstractValidator<GetEmployeeByID>
    {
        /// <summary>
        /// This class used to validate user to enter a comployee id in correct format
        /// </summary>
        public GetEmployeeByIDValidator()
        {
            RuleFor(x => x.EmployeeID).NotEmpty().NotNull();
        }
    }
}
