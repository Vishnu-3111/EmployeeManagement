using Employee.Model;

namespace Employee.Data
{
    public class Dataccess : IDataccess
    {
        private readonly EmpDbContext _dbContext;
        public Dataccess(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employees Addemployess(Employees employees)
        {
            var employeesList = new Employees();
            employeesList.Empname = employees.Empname;
            employeesList.salary = employees.salary;
            employeesList.depName = employees.depName;
            employeesList.Pincode = employees.Pincode;
            employeesList.MangerID = employees.MangerID;
            employeesList.Desgnation = employees.Desgnation;

            _dbContext.Employees.Add(employeesList);
            _dbContext.SaveChanges();
            return (employeesList);
        }

        public Employees Editemployess(Employees employees)
        {
            _dbContext.Employees.Update(employees);
            _dbContext.SaveChanges();
            return employees;


        }
        public List<Employees> Getemployee()
        {
            var result = _dbContext.Employees.ToList();
            return result;
        }
        public Employees Getemployeebyid(int id)
        {
            var result = _dbContext.Employees.Where(x => x.EmpId == id).FirstOrDefault();
            return result;
        }
        public int Deleteemployeebyid(int id)
        {
            var result = _dbContext.Employees.Where(x => x.EmpId == id).FirstOrDefault();
            if (result != null)
            {
                _dbContext.Employees.Remove(result);
            }
            return _dbContext.SaveChanges();


        }
    }
}
