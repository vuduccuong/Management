namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStatusWhenDelCustomer : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Proc_UpdateStatusWhenDelCustomer",
                p => new
                {
                    ID = p.Int()
                },
                @"update SeatNos set Status = 1 where ID = (select IDSeatNo from Bookings where IDCustomer = @ID)"
                );
        }
        
        public override void Down()
        {
            DropStoredProcedure("Proc_UpdateStatusWhenDelCustomer");
        }
    }
}
