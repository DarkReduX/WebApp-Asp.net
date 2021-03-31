namespace WebApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Votes", "UserLike", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Votes", "UserLike");
        }
    }
}
