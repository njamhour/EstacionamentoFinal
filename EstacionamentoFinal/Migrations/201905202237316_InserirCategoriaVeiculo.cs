namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InserirCategoriaVeiculo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Veiculos", "Cliente_IdCliente", "dbo.Clientes");
            DropIndex("dbo.Veiculos", new[] { "Cliente_IdCliente" });
            CreateTable(
                "dbo.CategoriaVeiculo",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Tamanho = c.String(),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            AddColumn("dbo.Clientes", "Veiculo_IdVeiculo", c => c.Int());
            AddColumn("dbo.Veiculos", "Categoria_IdCategoria", c => c.Int());
            AlterColumn("dbo.Funcionarios", "Nome", c => c.String());
            AlterColumn("dbo.Veiculos", "Placa", c => c.String());
            CreateIndex("dbo.Clientes", "Veiculo_IdVeiculo");
            CreateIndex("dbo.Veiculos", "Categoria_IdCategoria");
            AddForeignKey("dbo.Veiculos", "Categoria_IdCategoria", "dbo.CategoriaVeiculo", "IdCategoria");
            AddForeignKey("dbo.Clientes", "Veiculo_IdVeiculo", "dbo.Veiculos", "IdVeiculo");
            DropColumn("dbo.Veiculos", "Porte");
            DropColumn("dbo.Veiculos", "Cliente_IdCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Veiculos", "Cliente_IdCliente", c => c.Int());
            AddColumn("dbo.Veiculos", "Porte", c => c.String());
            DropForeignKey("dbo.Clientes", "Veiculo_IdVeiculo", "dbo.Veiculos");
            DropForeignKey("dbo.Veiculos", "Categoria_IdCategoria", "dbo.CategoriaVeiculo");
            DropIndex("dbo.Veiculos", new[] { "Categoria_IdCategoria" });
            DropIndex("dbo.Clientes", new[] { "Veiculo_IdVeiculo" });
            AlterColumn("dbo.Veiculos", "Placa", c => c.String(nullable: false));
            AlterColumn("dbo.Funcionarios", "Nome", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Veiculos", "Categoria_IdCategoria");
            DropColumn("dbo.Clientes", "Veiculo_IdVeiculo");
            DropTable("dbo.CategoriaVeiculo");
            CreateIndex("dbo.Veiculos", "Cliente_IdCliente");
            AddForeignKey("dbo.Veiculos", "Cliente_IdCliente", "dbo.Clientes", "IdCliente");
        }
    }
}
