using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaPlus.Models
{
    public class ProdutoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int quantidade { get; set; }
        public float taxa_lucro { get; set; }
        public float preco_unit_compra { get; set; }
        public float preco_venda { get; set; }
        public float preco_total_compra { get; set; }
        public DateTime data_hora { get; set; }
        public string? nome_produto { get; set; }
        public string? categoria { get; set; }

        public string? sku { get; set; }


    }
}