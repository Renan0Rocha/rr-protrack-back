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

        public DbSet<Insercao> Insercao { get; set; }

        public DbSet<OrdemBloco> OrdemBloco { get; set; }

        public DbSet<OrdemBlocoContrato> OrdemBlocoContrato { get; set; }

        public DbSet<Contrato> Contrato { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Endereco)
                .WithMany(c => c.Clientes)
                .HasForeignKey(c => c.EnderecoId)
                .IsRequired(true);
            
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Vendedor)
                .WithMany(c => c.Clientes)
                .HasForeignKey(c => c.VendedorId)
                .IsRequired(true);

            modelBuilder.Entity<OrdemBloco>()
                .HasOne(o => o.Programa)
                .WithMany(c => c.OrdemBlocos)
                .HasForeignKey(o => o.ProgramaId)
                .IsRequired(true);

            modelBuilder.Entity<OrdemBlocoContrato>()
                .ToTable("ordem_bloco_contrato")
                .HasKey(x => x.Id);

            modelBuilder.Entity<OrdemBlocoContrato>()
                .HasOne(obc => obc.Contrato)
                .WithMany(c => c.OrdemBlocoContrato)
                .HasForeignKey(obc => obc.ContratoId);

            modelBuilder.Entity<OrdemBlocoContrato>()
                .HasOne(obc => obc.OrdemBloco)
                .WithMany(ob => ob.OrdemBlocoContrato)
                .HasForeignKey(obc => obc.OrdemBlocoId);

            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Insercao)
                .WithMany(i => i.Contratos)
                .HasForeignKey(c => c.InsercaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }

}
