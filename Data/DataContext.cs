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
        public DbSet<Lider> Lideres { get; set; }

    }
}