namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarVaga : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vagas", "Identificador", c => c.String());
            DropColumn("dbo.Vagas", "Identificacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vagas", "Identificacao", c => c.String());
            DropColumn("dbo.Vagas", "Identificador");
        }
    }
}
