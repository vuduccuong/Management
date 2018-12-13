namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DatedBill = c.DateTime(nullable: false),
                        CustomerName = c.String(),
                        CustomerPhone = c.String(),
                        IDCar = c.Int(nullable: false),
                        SeatName = c.String(),
                        dateBook = c.String(),
                        CountMoney = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bills");
        }
    }
}
