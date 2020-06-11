namespace ltweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableAdvertise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdRegions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Advertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        AdRegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdRegions", t => t.AdRegionId, cascadeDelete: true)
                .Index(t => t.AdRegionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertises", "AdRegionId", "dbo.AdRegions");
            DropForeignKey("dbo.AdRegions", "RegionId", "dbo.Regions");
            DropIndex("dbo.Advertises", new[] { "AdRegionId" });
            DropIndex("dbo.AdRegions", new[] { "RegionId" });
            DropTable("dbo.Advertises");
            DropTable("dbo.AdRegions");
        }
    }
}
