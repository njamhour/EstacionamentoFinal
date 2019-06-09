namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverAnotacaoVagas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vagas", "Identificacao", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vagas", "Identificacao", c => c.String(nullable: false));
        }
    }
}
