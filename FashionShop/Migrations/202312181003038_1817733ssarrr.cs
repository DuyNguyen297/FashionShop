namespace FashionShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1817733ssarrr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banner",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Image = c.String(),
                        Title = c.String(storeType: "ntext"),
                        Content = c.String(storeType: "ntext"),
                        SeqNum = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        UpdateUserId = c.String(),
                        CreateUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.CreateUserId)
                .Index(t => t.CreateUserId);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Image = c.String(),
                        Title = c.String(storeType: "ntext"),
                        Content = c.String(storeType: "ntext"),
                        SeqNum = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        UpdateUserId = c.String(),
                        CreateUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.CreateUserId)
                .Index(t => t.CreateUserId);
            
            AddColumn("dbo.Product", "Outstanding", c => c.Boolean(nullable: false));
            AddColumn("dbo.Branch", "Outstanding", c => c.Boolean(nullable: false));
            AddColumn("dbo.Branch", "Image", c => c.String());
            AddColumn("dbo.Category", "Outstanding", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slide", "CreateUserId", "dbo.Account");
            DropForeignKey("dbo.Banner", "CreateUserId", "dbo.Account");
            DropIndex("dbo.Slide", new[] { "CreateUserId" });
            DropIndex("dbo.Banner", new[] { "CreateUserId" });
            DropColumn("dbo.Category", "Outstanding");
            DropColumn("dbo.Branch", "Image");
            DropColumn("dbo.Branch", "Outstanding");
            DropColumn("dbo.Product", "Outstanding");
            DropTable("dbo.Slide");
            DropTable("dbo.Banner");
        }
    }
}
