using Employee.Data.Quers;
using MediatR;

namespace Employee.Data.Handlers
{
    public class Deletehandlers : IRequestHandler<DeleteemployeequeryId, int>
    {
        private readonly IDataccess dataccess;
        public Deletehandlers(IDataccess dataccess)
        {
            this.dataccess = dataccess;
        }
        public Task<int> Handle(DeleteemployeequeryId request, CancellationToken cancellationToken)
        {
            var employeedetail = dataccess.Getemployeebyid(request.EmployeeId);
            if (employeedetail == null) return Task.FromResult<int>(default);

            return Task.FromResult(dataccess.Deleteemployeebyid(request.EmployeeId));


        }
    }
}
