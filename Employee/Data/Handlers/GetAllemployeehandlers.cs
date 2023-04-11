using Employee.Data.Quers;
using Employee.Model;
using MediatR;

namespace Employee.Data.Handlers
{
    public class GetAllemployeehandlers : IRequestHandler<getemployeequery, List<Employees>>
    {
        private readonly IDataccess _dataccess;
        public GetAllemployeehandlers(IDataccess dataAccess)
        {
            _dataccess = dataAccess;
        }

        

        public Task<List<Employees>> Handle(getemployeequery request, CancellationToken cancellationToken)
        {
            _dataccess.getemployee().ToList();
            return Task.FromResult(_dataccess.getemployee());

        }
    }
}
