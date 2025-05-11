using Microsoft.EntityFrameworkCore;
using Pagamentos.Domain;

public class PagamentoDbContext : DbContext
{
    public PagamentoDbContext(DbContextOptions<PagamentoDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cartao> Cartao { get; set; }
    public DbSet<Transacao> Transacao { get; internal set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cartao>()
            .HasKey(c => c.Numero);
    }
}

