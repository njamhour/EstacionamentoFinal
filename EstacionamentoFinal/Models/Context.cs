using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbEstacionamentoFinal") { }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Veiculo> Veiculos{ get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<CategoriaVeiculo> CategoriaVeiculo { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
    }
}