using employesControl_V2.Models;
using Microsoft.EntityFrameworkCore;

namespace employesControl_V2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, UserName = "admin", Password = Helper.DataProtection.EncriptiStringValue("admin"), Role = "manager" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}