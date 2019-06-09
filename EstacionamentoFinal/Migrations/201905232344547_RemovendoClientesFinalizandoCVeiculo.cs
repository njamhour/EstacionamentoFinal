namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoClientesFinalizandoCVeiculo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Veiculo_IdVeiculo", "dbo.Veiculos");
            DropIndex("dbo.Clientes", new[] { "Veiculo_IdVeiculo" });
            AddColumn("dbo.Veiculos", "Cor", c => c.String());
            AddColumn("dbo.Veiculos", "Fabricante", c => c.String());
            DropTable("dbo.Clientes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.String(),
                        Veiculo_IdVeiculo = c.Int(),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            DropColumn("dbo.Veiculos", "Fabricante");
            DropColumn("dbo.Veiculos", "Cor");
            CreateIndex("dbo.Clientes", "Veiculo_IdVeiculo");
            AddForeignKey("dbo.Clientes", "Veiculo_IdVeiculo", "dbo.Veiculos", "IdVeiculo");
        }
    }
}
