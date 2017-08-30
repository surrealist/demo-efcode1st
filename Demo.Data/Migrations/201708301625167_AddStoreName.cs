namespace Demo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Name", c => c.String(maxLength: 100));
            AddColumn("dbo.StoreSettings", "StoreName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Stores", "Remark", c => c.String(maxLength: 1024));
            DropColumn("dbo.StoreSettings", "ShopName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StoreSettings", "ShopName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Stores", "Remark", c => c.String());
            DropColumn("dbo.StoreSettings", "StoreName");
            DropColumn("dbo.Stores", "Name");
        }
    }
}
