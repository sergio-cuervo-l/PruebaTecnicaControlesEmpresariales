using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Dominio.Entities;

namespace PruebaTecnica.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee => Set<Employee>();
        public DbSet<User> Users => Set<User>();
    }
}
