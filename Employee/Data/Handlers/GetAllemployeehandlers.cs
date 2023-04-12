using Employee.Data.Quers;
using Employee.Model;
using MediatR;

namespace Employee.Data.Handlers
{
    public class GetAllemployeehandlers : IRequestHandler<Getemployeequery, List<Employees>>
    {
        private readonly IDataccess _dataccess;
        public GetAllemployeehandlers(IDataccess dataAccess)
        {
            _dataccess = dataAccess;
        }



        public Task<List<Employees>> Handle(Getemployeequery request, CancellationToken cancellationToken)
        {
            _dataccess.Getemployee().ToList();
            return Task.FromResult(_dataccess.Getemployee());

        }
    }
}
