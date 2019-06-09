using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        public int IdFuncionario { get; set; }
        //[Required(ErrorMessage = "Campo obrigatório!")]
        //[MaxLength(50, ErrorMessage = "Maximo 50 caracteres!")]
        public string Nome { get; set; }
        //[Required(ErrorMessage = "Campo obrigatório")]
        //[MaxLength(11, ErrorMessage = "Preencher corretamente")]
        //[MinLength(11, ErrorMessage = "Preencher corretamente")]
        public string CPF { get; set; }
    }
}