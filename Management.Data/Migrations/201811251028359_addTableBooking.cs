namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableBooking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDCar = c.Int(nullable: false),
                        IDCustomer = c.Int(nullable: false),
                        DateBook = c.DateTime(nullable: false),
                        IDSeat = c.Int(nullable: false),
                        IDSeatNo = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bookings");
        }
    }
}
