namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusVaga : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vagas", "Ocupado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vagas", "Ocupado");
        }
    }
}
