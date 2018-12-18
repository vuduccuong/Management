namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Status", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "Status");
        }
    }
}
