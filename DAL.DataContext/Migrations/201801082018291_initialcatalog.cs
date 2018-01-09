namespace DAL.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcatalog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Engineers",
                c => new
                    {
                        EngineerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EngineerId);
            
            CreateTable(
                "dbo.TaskEngineers",
                c => new
                    {
                        EngineerId = c.Int(nullable: false),
                        ShiftId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EngineerId, t.ShiftId })
                .ForeignKey("dbo.Engineers", t => t.EngineerId, cascadeDelete: true)
                .ForeignKey("dbo.Shifts", t => t.ShiftId, cascadeDelete: true)
                .Index(t => t.EngineerId)
                .Index(t => t.ShiftId);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ShiftId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskEngineers", "ShiftId", "dbo.Shifts");
            DropForeignKey("dbo.TaskEngineers", "EngineerId", "dbo.Engineers");
            DropIndex("dbo.TaskEngineers", new[] { "ShiftId" });
            DropIndex("dbo.TaskEngineers", new[] { "EngineerId" });
            DropTable("dbo.Shifts");
            DropTable("dbo.TaskEngineers");
            DropTable("dbo.Engineers");
        }
    }
}
