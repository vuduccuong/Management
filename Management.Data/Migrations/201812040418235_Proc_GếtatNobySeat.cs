namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Proc_GếtatNobySeat : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetSeatNoBySeat",
                p => new
                {
                    IDSeat = p.Int(),
                    DateBook = p.String()
                },
                @"select ID as [IDSeatNo],SeatNb,Status from SeatNos where IDSeat = @IDSeat and DateBook>= cast(@DateBook as date) and DateBook < cast(DATEADD(d,1,@DateBook) as date)"
                );
        }
        
        public override void Down()
        {
            DropStoredProcedure("GetSeatNoBySeat");
        }
    }
}
