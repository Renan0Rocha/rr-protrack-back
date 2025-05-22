

using Microsoft.EntityFrameworkCore;

namespace ApiLocadora.DataContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        public DbSet<Filme> Filmes { get; set; }
    }
}
