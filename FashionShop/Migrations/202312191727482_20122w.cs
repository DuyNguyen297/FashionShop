namespace FashionShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20122w : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ward", "Code", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ward", "Code", c => c.String(nullable: false));
        }
    }
}
