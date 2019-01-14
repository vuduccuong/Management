namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetIDSeatNoByRow2 : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("Proc_GetIDSeatNoByRow");
            CreateStoredProcedure("Proc_GetIDSeatNoByRow",

                p => new
                {
                    IDCar = p.Int(),
                    Row = p.String(),
                    DateBook = p.String(),
                    SeatNb = p.Int(),
                },
                @"Select sn.ID,sn.IDSeat from SeatNos sn inner join Seats s on sn.IDSeat = s.ID
inner join Cars c on c.ID = s.IDCar
where c.ID = @IDCar and s.Row = @Row and sn.DateBook >= cast(@DateBook as date) and sn.DateBook < DATEADD(d,1,cast(@DateBook as date)) 
and sn.SeatNb = @SeatNb");
        }

        public override void Down()
        {
            DropStoredProcedure("Proc_GetIDSeatNoByRow");
        }
    }
}
