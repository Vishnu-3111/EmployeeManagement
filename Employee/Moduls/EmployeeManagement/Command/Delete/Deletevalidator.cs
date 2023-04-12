
using Employee.Moduls.Command.Delete;
using FluentValidation;

namespace Employee.Moduls.EmployeeManagement.Command.Delete
{
    public class Deletevalidator : AbstractValidator<DeleteEmployee>
    {
        public Deletevalidator()
        {
            RuleFor(x => x.EmployeeID).NotEmpty().NotNull();
        }
    }
}
