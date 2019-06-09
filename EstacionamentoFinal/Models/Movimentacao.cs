using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.Models
{
    [Table("Movimentacoes")]
    public class Movimentacao
    {
        [Key]
        public int IdMovimentacao { get; set; }
        public Veiculo Veiculo { get; set; }
        public Vaga Vaga { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
    }
}