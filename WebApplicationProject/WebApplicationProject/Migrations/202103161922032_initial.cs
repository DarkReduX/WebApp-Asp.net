namespace WebApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsId = c.Int(nullable: false),
                        ip = c.String(nullable: false),
                        type = c.String(nullable: false),
                        continentCode = c.String(nullable: false),
                        continentName = c.String(nullable: false),
                        countryCode = c.String(nullable: false),
                        countryName = c.String(nullable: false),
                        regionCode = c.String(nullable: false),
                        regionName = c.String(nullable: false),
                        city = c.String(nullable: false),
                        zip = c.String(),
                        latitude = c.String(nullable: false),
                        longitude = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .Index(t => t.NewsId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        header = c.String(nullable: false),
                        info = c.String(nullable: false),
                        Image = c.Binary(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ips", "NewsId", "dbo.News");
            DropIndex("dbo.Ips", new[] { "NewsId" });
            DropTable("dbo.News");
            DropTable("dbo.Ips");
        }
    }
}
