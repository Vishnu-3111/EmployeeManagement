using Employee.Data.Quers;
using Employee.Model;
using MediatR;

namespace Employee.Data.Handlers
{
    public class DetailsEmployeeHandlers : IRequestHandler<GetemployeequeryId, Employees>
    {
        private readonly IDataccess _dataAccess;
        public DetailsEmployeeHandlers(IDataccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<Employees> Handle(GetemployeequeryId request, CancellationToken cancellationToken)
        {

            return Task.FromResult(_dataAccess.Getemployeebyid(request.EmployeeId));

        }

    }
}
