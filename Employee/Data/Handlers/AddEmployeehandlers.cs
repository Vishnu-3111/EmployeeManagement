using Employee.Data.Quers;
using Employee.Model;
using MediatR;
using System.Collections.Generic;

namespace Employee.Data.Handlers
{
    public class AddEmployeehandlers : IRequestHandler<Addemployeequery, Employees>
    {
        private readonly IDataccess _dataaccess;
        public AddEmployeehandlers(IDataccess dataaccess)
        {
            this._dataaccess = dataaccess;
        }
        public Task<Employees> Handle(Addemployeequery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataaccess.Addemployess(request.Employees));
        }
    }
}
