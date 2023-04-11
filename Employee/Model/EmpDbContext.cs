using Microsoft.EntityFrameworkCore;

namespace Employee.Model
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employees> Employees { get; set; }
    }
}
