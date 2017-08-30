namespace Demo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreRemark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "Remark");
        }
    }
}
