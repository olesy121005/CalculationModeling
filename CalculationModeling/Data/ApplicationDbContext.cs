using CalculationModeling.Models;
using CalculationModeling.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculationModeling.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CalculationParameters> CalculationParameters { get; set; }
        public DbSet<CalculationResult> CalculationResults { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
