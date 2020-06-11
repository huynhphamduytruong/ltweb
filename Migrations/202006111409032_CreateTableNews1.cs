namespace ltweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableNews1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.News", "CategoryId");
            AddForeignKey("dbo.News", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "CategoryId", "dbo.Categories");
            DropIndex("dbo.News", new[] { "CategoryId" });
        }
    }
}
