using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.Models
{
    [Table("CategoriaVeiculo")]
    public class CategoriaVeiculo
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Tamanho { get; set; }
        public double Valor { get; set; }
    }
}