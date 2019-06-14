namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterar_controler_mov : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movimentacoes", "Finalizada", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movimentacoes", "Pagamento", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movimentacoes", "Pagamento");
            DropColumn("dbo.Movimentacoes", "Finalizada");
        }
    }
}
