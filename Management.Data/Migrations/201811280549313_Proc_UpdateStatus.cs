namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Proc_UpdateStatus : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Proc_UpdateStatus1",
                p => new
                {
                    Status = p.Int(),
                    ID = p.Int(),
                },
        @"update SeatNos set Status = @Status where ID = @ID"
                );
        }

        public override void Down()
        {
            DropStoredProcedure("Proc_UpdateStatus1");
        }
    }
}
