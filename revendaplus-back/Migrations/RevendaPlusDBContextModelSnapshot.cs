﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RevendaPlus.Data;

#nullable disable

namespace revendaplus_back.Migrations
{
    [DbContext(typeof(RevendaPlusDBContext))]
    partial class RevendaPlusDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RevendaPlus.Models.EstoqueModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("id_produto")
                        .HasColumnType("int");

                    b.Property<int>("quant_estoque")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_produto")
                        .IsUnique();

                    b.ToTable("ItensEstoque");
                });

            modelBuilder.Entity("RevendaPlus.Models.ProdutoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("data_hora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("nome_produto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("preco_total_compra")
                        .HasMaxLength(100)
                        .HasColumnType("real");

                    b.Property<float>("preco_unit_compra")
                        .HasMaxLength(15)
                        .HasColumnType("real");

                    b.Property<float>("preco_venda")
                        .HasMaxLength(15)
                        .HasColumnType("real");

                    b.Property<int>("quantidade")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("sku")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("taxa_lucro")
                        .HasMaxLength(100)
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("RevendaPlus.Models.VendaModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("data_hora")
                        .HasColumnType("datetime2");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_produto")
                        .HasColumnType("int");

                    b.Property<int>("quant_vendida")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("RevendaPlus.Models.EstoqueModel", b =>
                {
                    b.HasOne("RevendaPlus.Models.ProdutoModel", null)
                        .WithMany()
                        .HasForeignKey("id_produto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
