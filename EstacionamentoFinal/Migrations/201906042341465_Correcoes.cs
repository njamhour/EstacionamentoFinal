namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movimentacoes",
                c => new
                    {
                        IdMovimentacao = c.Int(nullable: false, identity: true),
                        Entrada = c.DateTime(nullable: false),
                        Saida = c.DateTime(nullable: false),
                        Vaga_IdVaga = c.Int(),
                        Veiculo_IdVeiculo = c.Int(),
                    })
                .PrimaryKey(t => t.IdMovimentacao)
                .ForeignKey("dbo.Vagas", t => t.Vaga_IdVaga)
                .ForeignKey("dbo.Veiculos", t => t.Veiculo_IdVeiculo)
                .Index(t => t.Vaga_IdVaga)
                .Index(t => t.Veiculo_IdVeiculo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimentacoes", "Veiculo_IdVeiculo", "dbo.Veiculos");
            DropForeignKey("dbo.Movimentacoes", "Vaga_IdVaga", "dbo.Vagas");
            DropIndex("dbo.Movimentacoes", new[] { "Veiculo_IdVeiculo" });
            DropIndex("dbo.Movimentacoes", new[] { "Vaga_IdVaga" });
            DropTable("dbo.Movimentacoes");
        }
    }
}
