using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaPlus.Models
{
    public class VendaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int id_produto { get; set; }
        public int quant_vendida { get; set; }
        public DateTime data_hora { get; set; }
        public string? descricao { get; set; }
    }
}