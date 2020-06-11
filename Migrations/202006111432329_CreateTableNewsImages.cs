namespace ltweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableNewsImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        NewsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .Index(t => t.NewsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsImages", "NewsId", "dbo.News");
            DropIndex("dbo.NewsImages", new[] { "NewsId" });
            DropTable("dbo.NewsImages");
        }
    }
}
