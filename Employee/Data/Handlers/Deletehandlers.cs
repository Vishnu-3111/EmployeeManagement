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
        public async Task<int> Handle(DeleteemployeequeryId request, CancellationToken cancellationToken)
        {
            var employeedetails = dataccess.getemployeebyid(request.EmpId);
            if (employeedetails == null) return default;
           
                return dataccess.Deleteemployeebyid(request.EmpId);
            
           
        }
    }
}
