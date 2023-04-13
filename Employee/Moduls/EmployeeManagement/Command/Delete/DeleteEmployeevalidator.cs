
using Employee.Moduls.Command.Delete;
using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Command.Delete
{
    public class DeleteEmployeevalidator : AbstractValidator<DeleteEmployee>
    {
        public DeleteEmployeevalidator()
        {
            RuleFor(x => x.EmployeeID).NotEmpty().NotNull();
        }
    }
}
