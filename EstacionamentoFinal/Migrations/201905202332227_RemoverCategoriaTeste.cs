namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverCategoriaTeste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Veiculos", "Categoria_IdCategoria", "dbo.CategoriaVeiculo");
            DropIndex("dbo.Veiculos", new[] { "Categoria_IdCategoria" });
            DropColumn("dbo.Veiculos", "Categoria_IdCategoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Veiculos", "Categoria_IdCategoria", c => c.Int());
            CreateIndex("dbo.Veiculos", "Categoria_IdCategoria");
            AddForeignKey("dbo.Veiculos", "Categoria_IdCategoria", "dbo.CategoriaVeiculo", "IdCategoria");
        }
    }
}
