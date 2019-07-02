namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaVeiculo",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Tamanho = c.String(),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        IdFuncionario = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.String(),
                    })
                .PrimaryKey(t => t.IdFuncionario);
            
            CreateTable(
                "dbo.Movimentacoes",
                c => new
                    {
                        IdMovimentacao = c.Int(nullable: false, identity: true),
                        Entrada = c.DateTime(nullable: false),
                        Saida = c.DateTime(nullable: false),
                        Finalizada = c.Boolean(nullable: false),
                        Pagamento = c.Double(nullable: false),
                        Diferenca = c.Int(nullable: false),
                        Vaga_IdVaga = c.Int(),
                        Veiculo_IdVeiculo = c.Int(),
                    })
                .PrimaryKey(t => t.IdMovimentacao)
                .ForeignKey("dbo.Vagas", t => t.Vaga_IdVaga)
                .ForeignKey("dbo.Veiculos", t => t.Veiculo_IdVeiculo)
                .Index(t => t.Vaga_IdVaga)
                .Index(t => t.Veiculo_IdVeiculo);
            
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        IdVaga = c.Int(nullable: false, identity: true),
                        Identificador = c.String(),
                        Ocupado = c.Boolean(nullable: false),
                        Setor_IdSetor = c.Int(),
                    })
                .PrimaryKey(t => t.IdVaga)
                .ForeignKey("dbo.Setores", t => t.Setor_IdSetor)
                .Index(t => t.Setor_IdSetor);
            
            CreateTable(
                "dbo.Setores",
                c => new
                    {
                        IdSetor = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.IdSetor);
            
            CreateTable(
                "dbo.Veiculos",
                c => new
                    {
                        IdVeiculo = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        Cor = c.String(),
                        Modelo = c.String(),
                        Fabricante = c.String(),
                        Estacionado = c.Boolean(nullable: false),
                        CategoriaVeiculo_IdCategoria = c.Int(),
                    })
                .PrimaryKey(t => t.IdVeiculo)
                .ForeignKey("dbo.CategoriaVeiculo", t => t.CategoriaVeiculo_IdCategoria)
                .Index(t => t.CategoriaVeiculo_IdCategoria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimentacoes", "Veiculo_IdVeiculo", "dbo.Veiculos");
            DropForeignKey("dbo.Veiculos", "CategoriaVeiculo_IdCategoria", "dbo.CategoriaVeiculo");
            DropForeignKey("dbo.Movimentacoes", "Vaga_IdVaga", "dbo.Vagas");
            DropForeignKey("dbo.Vagas", "Setor_IdSetor", "dbo.Setores");
            DropIndex("dbo.Veiculos", new[] { "CategoriaVeiculo_IdCategoria" });
            DropIndex("dbo.Vagas", new[] { "Setor_IdSetor" });
            DropIndex("dbo.Movimentacoes", new[] { "Veiculo_IdVeiculo" });
            DropIndex("dbo.Movimentacoes", new[] { "Vaga_IdVaga" });
            DropTable("dbo.Veiculos");
            DropTable("dbo.Setores");
            DropTable("dbo.Vagas");
            DropTable("dbo.Movimentacoes");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.CategoriaVeiculo");
        }
    }
}
