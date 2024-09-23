using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
        : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserType>().HasData(new UserType (1,"ИП"),
                                                    new UserType (2,"ЮЛ"));
        }
    }
}
