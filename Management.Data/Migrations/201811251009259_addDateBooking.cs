namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeatNos", "DateBook", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SeatNos", "DateBook");
        }
    }
}
