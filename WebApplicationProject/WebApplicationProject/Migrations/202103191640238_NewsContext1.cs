namespace WebApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsContext1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Votes", "Vote_NewsId", c => c.Int());
            AddColumn("dbo.Votes", "Vote_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Votes", new[] { "Vote_NewsId", "Vote_UserId" });
            AddForeignKey("dbo.Votes", new[] { "Vote_NewsId", "Vote_UserId" }, "dbo.Votes", new[] { "NewsId", "UserId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", new[] { "Vote_NewsId", "Vote_UserId" }, "dbo.Votes");
            DropIndex("dbo.Votes", new[] { "Vote_NewsId", "Vote_UserId" });
            DropColumn("dbo.Votes", "Vote_UserId");
            DropColumn("dbo.Votes", "Vote_NewsId");
        }
    }
}
