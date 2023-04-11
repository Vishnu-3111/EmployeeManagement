using Employee.Model;
using MediatR;

namespace Employee.Data.Quers
{
    public record employeequery(Employees Employees) : IRequest<Employees>
    {

    }
    public class getemployeequery : IRequest<List<Employees>>
    {

    }
    public record employeequeryId (int id ): IRequest<Employees>
    {
        public int EmpId { get; set; }

    }
    public record updateemployeequery(Employees Employees) : IRequest<Employees>
    {
        public Employees Employee = Employees;
    }
    public record DeleteemployeequeryId : IRequest<int>
    {
        public int EmpId { get; set; }

    }





}
