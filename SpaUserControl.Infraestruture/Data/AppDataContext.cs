using SpaUserControl.Domain.Models;
using SpaUserControl.Infraestruture.Data.Map;
using System.Data.Entity;

namespace SpaUserControl.Infraestruture.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(): base("AppConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
