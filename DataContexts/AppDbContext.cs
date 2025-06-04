

using Microsoft.EntityFrameworkCore;
using rr_protrack_back.Models;

namespace rr_protrack_back.DataContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Estudio> Estudios { get; set; }

        public DbSet<Programa> Programa { get; set; }

        public DbSet<Cliente> Cliente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>()
                .HasOne(e => e.Estudio)
                .WithMany(e => e.Filmes)
                .HasForeignKey(e => e.EstudioId)
                .IsRequired(true);
        }

    }

}
