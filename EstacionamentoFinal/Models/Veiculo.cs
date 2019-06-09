using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int IdVeiculo { get; set; }
        //[Required(ErrorMessage = "Campo obrigatorio!")]
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public string Fabricante { get; set; }
        public CategoriaVeiculo CategoriaVeiculo { get; set; }
        
    }
}