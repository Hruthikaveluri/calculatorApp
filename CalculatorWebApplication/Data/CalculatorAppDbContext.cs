using CalculatorWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

namespace CalculatorWebApplication.Data
{
    public class CalculatorAppDbContext : DbContext
    {
        public CalculatorAppDbContext(DbContextOptions<CalculatorAppDbContext> options)
        : base(options)
        {
        }
        string connection= @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Hruthika; Integrated Security=True";
        public DbSet<CalculatorC> calculator { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
