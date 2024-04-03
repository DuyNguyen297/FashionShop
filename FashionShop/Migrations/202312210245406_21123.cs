namespace FashionShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VoucherCategory",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TotalCondition = c.Decimal(precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        CategoryId = c.String(maxLength: 128),
                        VoucherId = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        UpdateUserId = c.String(),
                        CreateUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Voucher", t => t.VoucherId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.VoucherId);
            
            CreateTable(
                "dbo.Voucher",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        UpdateUserId = c.String(),
                        CreateUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VoucherCustomer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TotalCondition = c.Decimal(precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        CustomerId = c.String(maxLength: 128),
                        VoucherId = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        UpdateUserId = c.String(),
                        CreateUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Voucher", t => t.VoucherId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.VoucherId);
            
            CreateTable(
                "dbo.VoucherProduct",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TotalCondition = c.Decimal(precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        ProductId = c.String(maxLength: 128),
                        VoucherId = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        UpdateUserId = c.String(),
                        CreateUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Voucher", t => t.VoucherId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.VoucherId);
            
            CreateTable(
                "dbo.VoucherShip",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TotalCondition = c.Decimal(precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        VoucherId = c.String(nullable: false, maxLength: 128),
                        Code = c.String(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        UpdateUserId = c.String(),
                        CreateUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Voucher", t => t.VoucherId, cascadeDelete: true)
                .Index(t => t.VoucherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VoucherCategory", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.VoucherShip", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.VoucherProduct", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.VoucherProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.VoucherCustomer", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.VoucherCustomer", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.VoucherCategory", "CategoryId", "dbo.Category");
            DropIndex("dbo.VoucherShip", new[] { "VoucherId" });
            DropIndex("dbo.VoucherProduct", new[] { "VoucherId" });
            DropIndex("dbo.VoucherProduct", new[] { "ProductId" });
            DropIndex("dbo.VoucherCustomer", new[] { "VoucherId" });
            DropIndex("dbo.VoucherCustomer", new[] { "CustomerId" });
            DropIndex("dbo.VoucherCategory", new[] { "VoucherId" });
            DropIndex("dbo.VoucherCategory", new[] { "CategoryId" });
            DropTable("dbo.VoucherShip");
            DropTable("dbo.VoucherProduct");
            DropTable("dbo.VoucherCustomer");
            DropTable("dbo.Voucher");
            DropTable("dbo.VoucherCategory");
        }
    }
}
