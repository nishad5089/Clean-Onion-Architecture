using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Onion.Application.Interfaces;
using Onion.Domain.Entity;

namespace Onion.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
        public DbSet<Student> Students { get; set; }

        public Task<int> SaveChangesAsync () {
            return base.SaveChangesAsync ();
        }
         public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext> {
            public ApplicationDbContext CreateDbContext (string[] args) {
                IConfigurationRoot configuration = new ConfigurationBuilder ()
                    .SetBasePath (Directory.GetCurrentDirectory ())
                    .AddJsonFile (@Directory.GetCurrentDirectory () + "../../../Presentation/Onion.Api/appsettings.json")
                    .Build ();
                var builder = new DbContextOptionsBuilder<ApplicationDbContext> ();
                var connectionString = configuration.GetConnectionString ("OnionDBConnection");
                builder.UseSqlServer (connectionString);
                return new ApplicationDbContext (builder.Options);
            }
        }
    }
}