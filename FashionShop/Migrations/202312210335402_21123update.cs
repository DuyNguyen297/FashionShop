namespace FashionShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21123update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VoucherCustomer", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.VoucherProduct", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.VoucherShip", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.VoucherCategory", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.VoucherCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.VoucherCustomer", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.VoucherProduct", "ProductId", "dbo.Product");
            DropIndex("dbo.VoucherCategory", new[] { "CategoryId" });
            DropIndex("dbo.VoucherCategory", new[] { "VoucherId" });
            DropIndex("dbo.VoucherCustomer", new[] { "CustomerId" });
            DropIndex("dbo.VoucherCustomer", new[] { "VoucherId" });
            DropIndex("dbo.VoucherProduct", new[] { "ProductId" });
            DropIndex("dbo.VoucherProduct", new[] { "VoucherId" });
            DropIndex("dbo.VoucherShip", new[] { "VoucherId" });
            AddColumn("dbo.VoucherCategory", "Name", c => c.String());
            AddColumn("dbo.VoucherCategory", "StartDate", c => c.DateTime());
            AddColumn("dbo.VoucherCategory", "EndDate", c => c.DateTime());
            AddColumn("dbo.VoucherCustomer", "Name", c => c.String());
            AddColumn("dbo.VoucherCustomer", "StartDate", c => c.DateTime());
            AddColumn("dbo.VoucherCustomer", "EndDate", c => c.DateTime());
            AddColumn("dbo.VoucherProduct", "Name", c => c.String());
            AddColumn("dbo.VoucherProduct", "StartDate", c => c.DateTime());
            AddColumn("dbo.VoucherProduct", "EndDate", c => c.DateTime());
            AddColumn("dbo.VoucherShip", "Name", c => c.String());
            AddColumn("dbo.VoucherShip", "StartDate", c => c.DateTime());
            AddColumn("dbo.VoucherShip", "EndDate", c => c.DateTime());
            AlterColumn("dbo.VoucherCategory", "CategoryId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.VoucherCategory", "CreateUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.VoucherCustomer", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.VoucherCustomer", "CreateUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.VoucherProduct", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.VoucherProduct", "CreateUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.VoucherShip", "CreateUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.VoucherCategory", "CategoryId");
            CreateIndex("dbo.VoucherCategory", "CreateUserId");
            CreateIndex("dbo.VoucherCustomer", "CustomerId");
            CreateIndex("dbo.VoucherCustomer", "CreateUserId");
            CreateIndex("dbo.VoucherProduct", "ProductId");
            CreateIndex("dbo.VoucherProduct", "CreateUserId");
            CreateIndex("dbo.VoucherShip", "CreateUserId");
            AddForeignKey("dbo.VoucherCategory", "CreateUserId", "dbo.Account", "Id");
            AddForeignKey("dbo.VoucherCustomer", "CreateUserId", "dbo.Account", "Id");
            AddForeignKey("dbo.VoucherProduct", "CreateUserId", "dbo.Account", "Id");
            AddForeignKey("dbo.VoucherShip", "CreateUserId", "dbo.Account", "Id");
            AddForeignKey("dbo.VoucherCategory", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VoucherCustomer", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VoucherProduct", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
            DropColumn("dbo.VoucherCategory", "VoucherId");
            DropColumn("dbo.VoucherCustomer", "VoucherId");
            DropColumn("dbo.VoucherProduct", "VoucherId");
            DropColumn("dbo.VoucherShip", "VoucherId");
            DropColumn("dbo.VoucherShip", "Code");
            DropTable("dbo.Voucher");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.VoucherShip", "Code", c => c.String(nullable: false));
            AddColumn("dbo.VoucherShip", "VoucherId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.VoucherProduct", "VoucherId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.VoucherCustomer", "VoucherId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.VoucherCategory", "VoucherId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.VoucherProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.VoucherCustomer", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.VoucherCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.VoucherShip", "CreateUserId", "dbo.Account");
            DropForeignKey("dbo.VoucherProduct", "CreateUserId", "dbo.Account");
            DropForeignKey("dbo.VoucherCustomer", "CreateUserId", "dbo.Account");
            DropForeignKey("dbo.VoucherCategory", "CreateUserId", "dbo.Account");
            DropIndex("dbo.VoucherShip", new[] { "CreateUserId" });
            DropIndex("dbo.VoucherProduct", new[] { "CreateUserId" });
            DropIndex("dbo.VoucherProduct", new[] { "ProductId" });
            DropIndex("dbo.VoucherCustomer", new[] { "CreateUserId" });
            DropIndex("dbo.VoucherCustomer", new[] { "CustomerId" });
            DropIndex("dbo.VoucherCategory", new[] { "CreateUserId" });
            DropIndex("dbo.VoucherCategory", new[] { "CategoryId" });
            AlterColumn("dbo.VoucherShip", "CreateUserId", c => c.String());
            AlterColumn("dbo.VoucherProduct", "CreateUserId", c => c.String());
            AlterColumn("dbo.VoucherProduct", "ProductId", c => c.String(maxLength: 128));
            AlterColumn("dbo.VoucherCustomer", "CreateUserId", c => c.String());
            AlterColumn("dbo.VoucherCustomer", "CustomerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.VoucherCategory", "CreateUserId", c => c.String());
            AlterColumn("dbo.VoucherCategory", "CategoryId", c => c.String(maxLength: 128));
            DropColumn("dbo.VoucherShip", "EndDate");
            DropColumn("dbo.VoucherShip", "StartDate");
            DropColumn("dbo.VoucherShip", "Name");
            DropColumn("dbo.VoucherProduct", "EndDate");
            DropColumn("dbo.VoucherProduct", "StartDate");
            DropColumn("dbo.VoucherProduct", "Name");
            DropColumn("dbo.VoucherCustomer", "EndDate");
            DropColumn("dbo.VoucherCustomer", "StartDate");
            DropColumn("dbo.VoucherCustomer", "Name");
            DropColumn("dbo.VoucherCategory", "EndDate");
            DropColumn("dbo.VoucherCategory", "StartDate");
            DropColumn("dbo.VoucherCategory", "Name");
            CreateIndex("dbo.VoucherShip", "VoucherId");
            CreateIndex("dbo.VoucherProduct", "VoucherId");
            CreateIndex("dbo.VoucherProduct", "ProductId");
            CreateIndex("dbo.VoucherCustomer", "VoucherId");
            CreateIndex("dbo.VoucherCustomer", "CustomerId");
            CreateIndex("dbo.VoucherCategory", "VoucherId");
            CreateIndex("dbo.VoucherCategory", "CategoryId");
            AddForeignKey("dbo.VoucherProduct", "ProductId", "dbo.Product", "Id");
            AddForeignKey("dbo.VoucherCustomer", "CustomerId", "dbo.Customer", "Id");
            AddForeignKey("dbo.VoucherCategory", "CategoryId", "dbo.Category", "Id");
            AddForeignKey("dbo.VoucherCategory", "VoucherId", "dbo.Voucher", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VoucherShip", "VoucherId", "dbo.Voucher", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VoucherProduct", "VoucherId", "dbo.Voucher", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VoucherCustomer", "VoucherId", "dbo.Voucher", "Id", cascadeDelete: true);
        }
    }
}
