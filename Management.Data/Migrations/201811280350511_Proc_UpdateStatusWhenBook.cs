namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Proc_UpdateStatusWhenBook : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Proc_UpdateStatus",
                p => new
                {
                    ID = p.Int(),
                    Status = p.Int(),
                },
        @"update SeatNos set Status = @Status where ID = @ID"
                );
        }
        
        public override void Down()
        {
            DropStoredProcedure("Proc_UpdateStatus");
        }
    }
}
