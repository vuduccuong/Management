namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillConfirmCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "ConfirmCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "ConfirmCode");
        }
    }
}
