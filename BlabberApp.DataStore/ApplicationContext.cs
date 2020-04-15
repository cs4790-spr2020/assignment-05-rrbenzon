using BlabberApp.Domain.Entities;
using BlabberApp.DataStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlabberApp.DataStore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new BlabMap(modelBuilder.Entity<Blab>());
            new UserMap(modelBuilder.Entity<User>());
        }
    }
}