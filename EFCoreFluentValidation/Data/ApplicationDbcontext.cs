using Microsoft.EntityFrameworkCore;

namespace EFCoreFluentValidation.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Approach 1 to connect to the database
        //private readonly IConfiguration _configuration;

        //public ApplicationDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = _configuration.GetConnectionString("DefaultConnection");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        //Appproach 2 to connect to the database.
        //We need to register ApplicationDbContext in the service container.
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
