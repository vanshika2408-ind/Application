using Application.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public class ApplicationDbContext :DbContext
    {

        // Use the generic DbContextOptions<ApplicationDbContext>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
