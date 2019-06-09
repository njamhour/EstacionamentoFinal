namespace EstacionamentoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Setores",
                c => new
                    {
                        IdSetor = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.IdSetor);
            
            AddColumn("dbo.Vagas", "Setor_IdSetor", c => c.Int());
            CreateIndex("dbo.Vagas", "Setor_IdSetor");
            AddForeignKey("dbo.Vagas", "Setor_IdSetor", "dbo.Setores", "IdSetor");
            DropColumn("dbo.Vagas", "Identificador");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vagas", "Identificador", c => c.String());
            DropForeignKey("dbo.Vagas", "Setor_IdSetor", "dbo.Setores");
            DropIndex("dbo.Vagas", new[] { "Setor_IdSetor" });
            DropColumn("dbo.Vagas", "Setor_IdSetor");
            DropTable("dbo.Setores");
        }
    }
}
