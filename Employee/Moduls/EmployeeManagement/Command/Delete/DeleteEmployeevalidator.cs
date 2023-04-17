
using Employee.Moduls.Command.Delete;
using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Command.Delete
{
    public class DeleteEmployeevalidator : AbstractValidator<DeleteEmployee>
    {
        /// <summary>
        /// used to validate user entered vaild employee id
        /// </summary>
        public DeleteEmployeevalidator()
        {
            RuleFor(x => x.EmployeeID).NotEmpty().NotNull();
        }
    }
}
