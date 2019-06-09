namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoTabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(),
                        Veiculo_IdVeiculo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCliente)
                .ForeignKey("dbo.Veiculos", t => t.Veiculo_IdVeiculo, cascadeDelete: true)
                .Index(t => t.Veiculo_IdVeiculo);
            
            CreateTable(
                "dbo.Veiculos",
                c => new
                    {
                        IdVeiculo = c.Int(nullable: false, identity: true),
                        Placa = c.String(nullable: false),
                        Modelo = c.String(),
                        Porte = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdVeiculo);
            
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        IdVaga = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Cliente_IdCliente = c.Int(),
                    })
                .PrimaryKey(t => t.IdVaga)
                .ForeignKey("dbo.Clientes", t => t.Cliente_IdCliente)
                .Index(t => t.Cliente_IdCliente);
            
            AlterColumn("dbo.Funcionarios", "Nome", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Funcionarios", "CPF", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vagas", "Cliente_IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Veiculo_IdVeiculo", "dbo.Veiculos");
            DropIndex("dbo.Vagas", new[] { "Cliente_IdCliente" });
            DropIndex("dbo.Clientes", new[] { "Veiculo_IdVeiculo" });
            AlterColumn("dbo.Funcionarios", "CPF", c => c.String());
            AlterColumn("dbo.Funcionarios", "Nome", c => c.String());
            DropTable("dbo.Vagas");
            DropTable("dbo.Veiculos");
            DropTable("dbo.Clientes");
        }
    }
}
