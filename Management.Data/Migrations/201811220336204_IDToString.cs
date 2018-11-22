namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDToString : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cars");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Drivers");

            DropPrimaryKey("dbo.SeatNos");
            DropPrimaryKey("dbo.Seats");
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Cars", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Cars", "IDDriver", c => c.Guid(nullable: false));
            AlterColumn("dbo.Cars", "IDRouter", c => c.Guid(nullable: false));
            AlterColumn("dbo.Customers", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Drivers", "ID", c => c.Guid(nullable: false));

            AlterColumn("dbo.SeatNos", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.SeatNos", "IDSeat", c => c.Guid(nullable: false));
            AlterColumn("dbo.Seats", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Seats", "IDCar", c => c.Guid(nullable: false));
            AlterColumn("dbo.Tickets", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Tickets", "IDCar", c => c.String());
            AlterColumn("dbo.Tickets", "Customer", c => c.String());
            AddPrimaryKey("dbo.Cars", "ID");
            AddPrimaryKey("dbo.Customers", "ID");
            AddPrimaryKey("dbo.Drivers", "ID");

            AddPrimaryKey("dbo.SeatNos", "ID");
            AddPrimaryKey("dbo.Seats", "ID");
            AddPrimaryKey("dbo.Tickets", "ID");
            DropColumn("dbo.SeatNos", "isDel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SeatNos", "isDel", c => c.Boolean());
            DropPrimaryKey("dbo.Tickets");
            DropPrimaryKey("dbo.Seats");
            DropPrimaryKey("dbo.SeatNos");

            DropPrimaryKey("dbo.Drivers");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Cars");
            AlterColumn("dbo.Tickets", "Customer", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "IDCar", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Seats", "IDCar", c => c.Int(nullable: false));
            AlterColumn("dbo.Seats", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SeatNos", "IDSeat", c => c.Int(nullable: false));
            AlterColumn("dbo.SeatNos", "ID", c => c.Int(nullable: false, identity: true));

            AlterColumn("dbo.Drivers", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cars", "IDRouter", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "IDDriver", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tickets", "ID");
            AddPrimaryKey("dbo.Seats", "ID");
            AddPrimaryKey("dbo.SeatNos", "ID");

            AddPrimaryKey("dbo.Drivers", "ID");
            AddPrimaryKey("dbo.Customers", "ID");
            AddPrimaryKey("dbo.Cars", "ID");
        }
    }
}
