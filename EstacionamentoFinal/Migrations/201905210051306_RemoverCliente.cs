namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Veiculos", "CategoriaVeiculo_IdCategoria", c => c.Int());
            CreateIndex("dbo.Veiculos", "CategoriaVeiculo_IdCategoria");
            AddForeignKey("dbo.Veiculos", "CategoriaVeiculo_IdCategoria", "dbo.CategoriaVeiculo", "IdCategoria");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veiculos", "CategoriaVeiculo_IdCategoria", "dbo.CategoriaVeiculo");
            DropIndex("dbo.Veiculos", new[] { "CategoriaVeiculo_IdCategoria" });
            DropColumn("dbo.Veiculos", "CategoriaVeiculo_IdCategoria");
        }
    }
}
