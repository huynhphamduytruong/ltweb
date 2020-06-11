namespace ltweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableNews2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.News", "RegionId", c => c.Int(nullable: false));
            AddColumn("dbo.News", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.News", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.News", "RegionId");
            AddForeignKey("dbo.News", "RegionId", "dbo.Regions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "RegionId", "dbo.Regions");
            DropIndex("dbo.News", new[] { "RegionId" });
            AlterColumn("dbo.News", "Description", c => c.String());
            AlterColumn("dbo.News", "Title", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.News", "UserId");
            DropColumn("dbo.News", "RegionId");
            DropTable("dbo.Regions");
        }
    }
}
