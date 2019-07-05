using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.Models
{
    [Table("Vagas")]
    public class Vaga
    {
        [Key]
        public int IdVaga { get; set; }
        public Setor Setor { get; set; }
        public string Identificador { get; set; }
        public bool Ocupado { get; set; }

    }
}