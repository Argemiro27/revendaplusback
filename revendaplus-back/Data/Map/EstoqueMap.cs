using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevendaPlus.Models;

namespace RevendaPlus.Data.Map
{
    public class EstoqueMap : IEntityTypeConfiguration<EstoqueModel>
    {
        public void Configure(EntityTypeBuilder<EstoqueModel> builder)
        {
            builder.HasKey(x => x.id);

            builder.HasOne<ProdutoModel>()
                .WithMany()
                .HasForeignKey(x => x.id_produto)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.quant_estoque).IsRequired().HasMaxLength(100);


            builder.HasIndex(x => x.id_produto)
                .IsUnique();
        }


    }
}
