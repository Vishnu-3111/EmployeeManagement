using Employee.Model;
using MediatR;

namespace Employee.Data.Quers
{
    public record Addemployeequery(Employees Employees) : IRequest<Employees>
    {

    }
    public class Getemployeequery : IRequest<List<Employees>>
    {

    }
    public record GetemployeequeryId(int id) : IRequest<Employees>
    {
        public int EmployeeId = id;

    }
    public record updateemployeequery(Employees Employees) : IRequest<Employees>
    {
        public Employees Employee = Employees;
    }
    public record DeleteemployeequeryId : IRequest<int>
    {
        public int EmployeeId { get; set; }

    }


}
