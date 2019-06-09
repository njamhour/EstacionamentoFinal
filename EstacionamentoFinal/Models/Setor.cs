using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.Models
{
    [Table("Setores")]
    public class Setor
    {
        [Key]
        public int IdSetor { get; set; }
        public string Nome { get; set; }
    }
}