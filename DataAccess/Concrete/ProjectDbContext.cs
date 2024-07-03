using Microsoft.EntityFrameworkCore;
using SerimCase.Entities.Concrete;
using System.Drawing;

namespace SerimCase.DataAccess.Concrete
{
    public class ProjectDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ProjectDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlServer(_configuration.GetSection("Database:ConnectionString").Value);
        }


        public DbSet<Customer> Customers { get; set; }
    }
}
