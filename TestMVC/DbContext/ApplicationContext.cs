using Microsoft.EntityFrameworkCore;
using EmployeeForm.Models;

namespace EmployeeForm.DbContext
{
    public class ApplicationContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
