namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requireds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CategoriaVeiculo", "Tamanho", c => c.String(nullable: false));
            AlterColumn("dbo.Setores", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Veiculos", "Placa", c => c.String(nullable: false));
            AlterColumn("dbo.Veiculos", "Cor", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Veiculos", "Cor", c => c.String());
            AlterColumn("dbo.Veiculos", "Placa", c => c.String());
            AlterColumn("dbo.Setores", "Nome", c => c.String());
            AlterColumn("dbo.CategoriaVeiculo", "Tamanho", c => c.String());
        }
    }
}
