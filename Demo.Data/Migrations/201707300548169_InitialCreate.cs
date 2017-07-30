namespace Demo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageCode = c.String(maxLength: 5),
                        CompanyName = c.String(maxLength: 200),
                        Address = c.String(),
                        Email = c.String(),
                        Store_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id)
                .Index(t => t.LanguageCode)
                .Index(t => t.Store_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreSettings", "Store_Id", "dbo.Stores");
            DropIndex("dbo.StoreSettings", new[] { "Store_Id" });
            DropIndex("dbo.StoreSettings", new[] { "LanguageCode" });
            DropTable("dbo.StoreSettings");
            DropTable("dbo.Stores");
        }
    }
}
