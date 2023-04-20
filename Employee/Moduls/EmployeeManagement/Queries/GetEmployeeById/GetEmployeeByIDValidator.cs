using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Quers.GetEmployeeById
{
    public class GetEmployeeByIDValidator : AbstractValidator<GetEmployeeByID>
    {
        /// <summary>
        ///  used to validate user to enter a comployee id in correct format
        /// </summary>
        public GetEmployeeByIDValidator()
        {
            RuleFor(x => x.EmployeeID).NotEmpty().GreaterThan(0);
        }
    }
}
