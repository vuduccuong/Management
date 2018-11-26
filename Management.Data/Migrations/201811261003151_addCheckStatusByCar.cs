namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCheckStatusByCar : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Proc_SearchSeatByCar",
                p => new
                {
                    IDCar = p.Int()
                },
                @"select s.ID, s.Row from cars c inner join Seats s on c.ID = s.IDCar where c.ID = @IDCar"
                );

            CreateStoredProcedure("Proc_CheckStatusBySeat",

                p => new {
                    IDSeat = p.Int(),
                    DateBook = p.String()
                },
                @"select s.ID as [IDSeat], sn.ID as [IDSeatNo],sn.SeatNb, sn.Status from SeatNos sn inner join Seats s on sn.IDSeat = s.ID
                    where s.ID = @IDSeat and DateBook >= cast(@DateBook as date) and DateBook < cast(DATEADD(day, 1, @DateBook) as date)"
                );
        }
        
        public override void Down()
        {
            DropStoredProcedure("Proc_SearchSeatByCar");
            DropStoredProcedure("Proc_CheckStatusBySeat");
        }
    }
}
