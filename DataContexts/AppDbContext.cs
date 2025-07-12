using Microsoft.EntityFrameworkCore;
using rr_protrack_back.Models;

namespace rr_protrack_back.DataContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Programa> Programa { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Vendedor> Vendedor { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

    }

}
