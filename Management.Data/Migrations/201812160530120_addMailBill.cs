namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMailBill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "CustomerMail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "CustomerMail");
        }
    }
}
