namespace Demo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreName1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoreSettings", "StoreDisplayName", c => c.String(maxLength: 200));
            DropColumn("dbo.StoreSettings", "StoreName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StoreSettings", "StoreName", c => c.String(maxLength: 200));
            DropColumn("dbo.StoreSettings", "StoreDisplayName");
        }
    }
}
