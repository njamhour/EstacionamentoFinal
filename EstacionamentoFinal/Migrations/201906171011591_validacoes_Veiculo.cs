namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validacoes_Veiculo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Veiculos", "Estacionado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Veiculos", "Estacionado");
        }
    }
}
