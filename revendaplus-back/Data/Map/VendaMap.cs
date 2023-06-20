using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevendaPlus.Models;

namespace RevendaPlus.Data.Map
{
    public class VendaMap : IEntityTypeConfiguration<VendaModel>
    {
        public void Configure(EntityTypeBuilder<VendaModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasIndex(x => x.id_produto).IsUnique();
            builder.HasOne<EstoqueModel>()
                .WithMany()
                .HasForeignKey(x => x.id_produto)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.data_hora)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.quant_vendida).IsRequired().HasMaxLength(100);
            builder.Property(x => x.descricao).IsRequired().HasMaxLength(100);
        }


    }
}
