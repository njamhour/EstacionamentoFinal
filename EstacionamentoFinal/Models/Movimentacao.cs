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
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime Entrada { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime Saida { get; set; }
        public bool Finalizada { get; set; }
        public double Pagamento { get; set; }
        public int Diferenca { get; set; }
    }
}