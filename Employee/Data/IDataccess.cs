using Employee.Model;

namespace Employee.Data
{
    public interface IDataccess
    {
        public Employees Addemployess(Employees employees);
        public Employees Editemployess(Employees employees);
        public List<Employees> getemployee();
        public Employees getemployeebyid(int id);
        public int Deleteemployeebyid(int id);
    }
}
