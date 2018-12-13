namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AAAaaa : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Proc_UpdateStatus2",
                p => new
                {
                    Status = p.Boolean(),
                    ID = p.Int(),
                },
                @"UPDATE SeatNos set Status = @Status where ID = @ID");
        }
        
        public override void Down()
        {
            DropStoredProcedure("Proc_UpdateStatus2");
        }
    }
}
