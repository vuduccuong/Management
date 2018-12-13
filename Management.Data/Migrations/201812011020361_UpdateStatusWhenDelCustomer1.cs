namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStatusWhenDelCustomer1 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Proc_UpdateStatusWhenDelCustomer1",
                p => new
                {
                    ID = p.Int()
                },
                @"select IDSeatNo from Bookings where IDCustomer = @ID"
                );
        }
        
        public override void Down()
        {
            DropStoredProcedure("Proc_UpdateStatusWhenDelCustomer1");
        }
    }
}
