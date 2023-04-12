using Employee.Data.Quers;
using Employee.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data.Handlers
{
    public class updateemployeeHaldlers : IRequestHandler<updateemployeequery, Employees>
    {
        public readonly IDataccess _dataccess;
        public updateemployeeHaldlers(IDataccess dataccess)
        {
            _dataccess = dataccess;
        }
        public Task<Employees> Handle(updateemployeequery request, CancellationToken cancellationToken)
        {


            return Task.FromResult(_dataccess.Editemployess(request.Employee));

        }
    }
}
