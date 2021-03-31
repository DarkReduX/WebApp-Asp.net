namespace WebApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsContext2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", new[] { "Vote_NewsId", "Vote_UserId" }, "dbo.Votes");
            DropIndex("dbo.Votes", new[] { "Vote_NewsId", "Vote_UserId" });
            DropColumn("dbo.Votes", "Vote_NewsId");
            DropColumn("dbo.Votes", "Vote_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Votes", "Vote_UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Votes", "Vote_NewsId", c => c.Int());
            CreateIndex("dbo.Votes", new[] { "Vote_NewsId", "Vote_UserId" });
            AddForeignKey("dbo.Votes", new[] { "Vote_NewsId", "Vote_UserId" }, "dbo.Votes", new[] { "NewsId", "UserId" });
        }
    }
}
