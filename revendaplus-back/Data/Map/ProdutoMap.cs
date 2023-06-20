using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevendaPlus.Models;

namespace RevendaPlus.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.nome_produto).IsRequired().HasMaxLength(100);
            builder.Property(x => x.categoria).IsRequired().HasMaxLength(100);
            builder.Property(x => x.taxa_lucro).IsRequired().HasMaxLength(100);
            builder.Property(x => x.preco_unit_compra).IsRequired().HasMaxLength(15);
            builder.Property(x => x.preco_venda).IsRequired().HasMaxLength(15);
            builder.Property(x => x.sku).IsRequired().HasMaxLength(50);
            builder.Property(x => x.quantidade).IsRequired().HasMaxLength(20);
            builder.Property(x => x.preco_total_compra).IsRequired().HasMaxLength(100);

            builder.Property(x => x.data_hora)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }


    }
}
