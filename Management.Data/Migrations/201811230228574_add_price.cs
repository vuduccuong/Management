namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_price : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Price", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Price");
        }
    }
}
