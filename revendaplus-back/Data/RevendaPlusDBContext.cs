using Microsoft.EntityFrameworkCore;
using RevendaPlus.Data.Map;
using RevendaPlus.Models;

namespace RevendaPlus.Data
{
    public class RevendaPlusDBContext : DbContext
    {
        public RevendaPlusDBContext(DbContextOptions<RevendaPlusDBContext> options) : base(options)
        {
            
        }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<EstoqueModel> ItensEstoque { get; set; }

        public DbSet<VendaModel> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
