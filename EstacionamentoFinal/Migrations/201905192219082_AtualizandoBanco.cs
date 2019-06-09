namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizandoBanco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Veiculo_IdVeiculo", "dbo.Veiculos");
            DropForeignKey("dbo.Vagas", "Cliente_IdCliente", "dbo.Clientes");
            DropIndex("dbo.Clientes", new[] { "Veiculo_IdVeiculo" });
            DropIndex("dbo.Vagas", new[] { "Cliente_IdCliente" });
            AddColumn("dbo.Veiculos", "Cliente_IdCliente", c => c.Int());
            AlterColumn("dbo.Veiculos", "Porte", c => c.String());
            CreateIndex("dbo.Veiculos", "Cliente_IdCliente");
            AddForeignKey("dbo.Veiculos", "Cliente_IdCliente", "dbo.Clientes", "IdCliente");
            DropColumn("dbo.Clientes", "Veiculo_IdVeiculo");
            DropColumn("dbo.Vagas", "Status");
            DropColumn("dbo.Vagas", "Cliente_IdCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vagas", "Cliente_IdCliente", c => c.Int());
            AddColumn("dbo.Vagas", "Status", c => c.String());
            AddColumn("dbo.Clientes", "Veiculo_IdVeiculo", c => c.Int(nullable: false));
            DropForeignKey("dbo.Veiculos", "Cliente_IdCliente", "dbo.Clientes");
            DropIndex("dbo.Veiculos", new[] { "Cliente_IdCliente" });
            AlterColumn("dbo.Veiculos", "Porte", c => c.String(nullable: false));
            DropColumn("dbo.Veiculos", "Cliente_IdCliente");
            CreateIndex("dbo.Vagas", "Cliente_IdCliente");
            CreateIndex("dbo.Clientes", "Veiculo_IdVeiculo");
            AddForeignKey("dbo.Vagas", "Cliente_IdCliente", "dbo.Clientes", "IdCliente");
            AddForeignKey("dbo.Clientes", "Veiculo_IdVeiculo", "dbo.Veiculos", "IdVeiculo", cascadeDelete: true);
        }
    }
}
