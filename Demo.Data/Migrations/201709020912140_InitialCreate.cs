namespace Demo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Color = c.String(),
                        NextTicketId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Remark = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageCode = c.String(maxLength: 5),
                        StoreDisplayName = c.String(maxLength: 200),
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
            DropForeignKey("dbo.Tickets", "Service_Id", "dbo.Services");
            DropIndex("dbo.StoreSettings", new[] { "Store_Id" });
            DropIndex("dbo.StoreSettings", new[] { "LanguageCode" });
            DropIndex("dbo.Tickets", new[] { "Service_Id" });
            DropTable("dbo.StoreSettings");
            DropTable("dbo.Stores");
            DropTable("dbo.Tickets");
            DropTable("dbo.Services");
        }
    }
}
