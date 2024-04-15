using DatabaseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.DatabaseContext
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
