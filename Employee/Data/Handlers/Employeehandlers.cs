using Employee.Data.Quers;
using Employee.Model;
using MediatR;
using System.Collections.Generic;

namespace Employee.Data.Handlers
{
    public class Employeehandlers : IRequestHandler<employeequery, Employees>
    {
        private readonly IDataccess _dataaccess;
        public Employeehandlers(IDataccess dataaccess)
        {
            this._dataaccess = dataaccess;
        }
        public Task<Employees> Handle(employeequery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataaccess.Addemployess(request.Employees));
        }
    }
}
