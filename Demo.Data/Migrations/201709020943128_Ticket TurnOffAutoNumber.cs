namespace Demo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketTurnOffAutoNumber : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tickets", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tickets", "Id");
        }
    }
}
