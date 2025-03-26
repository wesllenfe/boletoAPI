using BoletoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoletoAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Banco> Bancos { get; set; } = null!;
        public DbSet<Boleto> Boletos { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Banco entity
            modelBuilder.Entity<Banco>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Codigo).IsRequired().HasMaxLength(10);
                entity.Property(e => e.PercentualJuros).IsRequired().HasPrecision(10, 2);
                
                // Add unique constraint on Codigo
                entity.HasIndex(e => e.Codigo).IsUnique();
            });
            
            // Configure Boleto entity
            modelBuilder.Entity<Boleto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.NomePagador).IsRequired();
                entity.Property(e => e.CpfCnpjPagador).IsRequired();
                entity.Property(e => e.NomeBeneficiario).IsRequired();
                entity.Property(e => e.CpfCnpjBeneficiario).IsRequired();
                entity.Property(e => e.Valor).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.DataVencimento).IsRequired();
                entity.Property(e => e.Observacao).IsRequired(false);
                
                // Configure relationship with Banco
                entity.HasOne(e => e.Banco)
                      .WithMany(b => b.Boletos)
                      .HasForeignKey(e => e.BancoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

