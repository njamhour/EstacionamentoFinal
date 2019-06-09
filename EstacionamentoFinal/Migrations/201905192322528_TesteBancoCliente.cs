namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TesteBancoCliente : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Nome", c => c.String(nullable: false));
        }
    }
}
