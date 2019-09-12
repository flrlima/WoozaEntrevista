namespace Wooza.Entrevista.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DDD",
                c => new
                    {
                        DddId = c.Guid(nullable: false),
                        DddDigito = c.String(nullable: false, maxLength: 2),
                        DddEstadoSigla = c.String(nullable: false, maxLength: 80),
                        DddCidade = c.String(),
                    })
                .PrimaryKey(t => t.DddId);
            
            CreateTable(
                "dbo.Planos",
                c => new
                    {
                        PlanoId = c.Guid(nullable: false),
                        CodigoDoPlano = c.Int(nullable: false),
                        Minuto = c.Int(nullable: false),
                        FranquiaDeInternet = c.Double(nullable: false),
                        Valor = c.Double(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Operadora = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanoId);
            
            CreateTable(
                "dbo.PlanoDDD",
                c => new
                    {
                        PlanoId = c.Guid(nullable: false),
                        DDDId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlanoId, t.DDDId })
                .ForeignKey("dbo.Planos", t => t.PlanoId, cascadeDelete: true)
                .ForeignKey("dbo.DDD", t => t.DDDId, cascadeDelete: true)
                .Index(t => t.PlanoId)
                .Index(t => t.DDDId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanoDDD", "DDDId", "dbo.DDD");
            DropForeignKey("dbo.PlanoDDD", "PlanoId", "dbo.Planos");
            DropIndex("dbo.PlanoDDD", new[] { "DDDId" });
            DropIndex("dbo.PlanoDDD", new[] { "PlanoId" });
            DropTable("dbo.PlanoDDD");
            DropTable("dbo.Planos");
            DropTable("dbo.DDD");
        }
    }
}
