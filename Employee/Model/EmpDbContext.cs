using Employee.Moduls.EmployeeManagement.Command.Create;
using Microsoft.EntityFrameworkCore;

namespace Employee.Model
{
    /// <summary>
    /// Connection to access Database Table
    /// </summary>
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmployeeManagement> EmployeeManagement { get; set; }
        public DbSet<Educationalqualification> educationalqualification { get; set; }
    }
}
