namespace WebApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReadedPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReadedPosts",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PostId })
                .ForeignKey("dbo.News", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReadedPosts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReadedPosts", "PostId", "dbo.News");
            DropIndex("dbo.ReadedPosts", new[] { "PostId" });
            DropIndex("dbo.ReadedPosts", new[] { "UserId" });
            DropTable("dbo.ReadedPosts");
        }
    }
}
