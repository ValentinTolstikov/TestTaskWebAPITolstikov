using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasCheckConstraint("ck_INN_client", "ISNUMERIC ( INN ) <> 0");
            modelBuilder.Entity<Founder>().HasCheckConstraint("ck_INN_founder", "ISNUMERIC ( INN ) <> 0");

            modelBuilder.Entity<UserType>().HasData(new UserType (1,"ИП"),
                                                    new UserType (2,"ЮЛ"));

            modelBuilder.Entity<Client>().HasData(new Client(1, "1234567891", "ИП Смирнов", DateTime.Now, DateTime.Now, 1),
                                                  new Client(2, "1234567812", "ИП Федоров", DateTime.Now, DateTime.Now, 1),
                                                  new Client(3, "1234567891", "ИП Симонов", DateTime.Now, DateTime.Now, 1),
                                                  new Client(4, "123456781212", "ООО Рога и копыта", DateTime.Now, DateTime.Now, 2));

            modelBuilder.Entity<Founder>().HasData(new Founder(1, "123456784212","Иванов","Петр","Иванович", DateTime.Now, DateTime.Now, 4),
                                                   new Founder(2, "423456784212", "Иванов", "Сергей", "Петрович", DateTime.Now, DateTime.Now, 4));
        }
    }
}
