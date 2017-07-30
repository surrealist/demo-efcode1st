namespace Demo.Data.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddShopName : DbMigration {
        public override void Up() {
            AddColumn("dbo.StoreSettings", "ShopName", c => c.String(maxLength: 200));
            Sql("UPDATE dbo.StoreSettings SET ShopName=N'ร้าน' + CompanyName;");
        }

        public override void Down() {
            DropColumn("dbo.StoreSettings", "ShopName");
        }
    }
}
