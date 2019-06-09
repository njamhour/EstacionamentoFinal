namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverValidacaoBanco : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Funcionarios", "CPF", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Funcionarios", "CPF", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
