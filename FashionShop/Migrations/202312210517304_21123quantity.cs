namespace FashionShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21123quantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VoucherCategory", "Quantity", c => c.Int());
            AddColumn("dbo.VoucherCustomer", "Quantity", c => c.Int());
            AddColumn("dbo.VoucherProduct", "Quantity", c => c.Int());
            AddColumn("dbo.VoucherShip", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VoucherShip", "Quantity");
            DropColumn("dbo.VoucherProduct", "Quantity");
            DropColumn("dbo.VoucherCustomer", "Quantity");
            DropColumn("dbo.VoucherCategory", "Quantity");
        }
    }
}
