namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigirVaga : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vagas", "Identificacao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vagas", "Identificacao");
        }
    }
}
