using Microsoft.EntityFrameworkCore;

namespace Employee.Model
{
    /// <summary>
    /// Connection to access Database Table
    /// </summary>
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options)
        {
        }

        public virtual DbSet<EmployeeManagement> EmployeeManagement { get; set; }

    }
}
