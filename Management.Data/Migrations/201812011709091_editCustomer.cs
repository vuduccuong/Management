namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class editCustomer : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Proc_GetCustDetail",
                p => new
                {
                    ID = p.Int()
                },
                @"Select bk.ID as [IDBook], CONVERT(nvarchar(50),bk.DateBook, 101) as [DateBook],
                  cust.ID as [IDCustomer], cust.Name as [NameCustomer], cust.PhoneNumber as [PhoneNumber],cust.Email as [Email], cust.Address as [Address], 
                  s.ID as [IDSeat], s.Row, sn.ID as [IDSeatNo], sn.SeatNb, sn.Status, c.Name as [NameCar] from Bookings bk inner join Customers cust on bk.IDCustomer = cust.ID
							inner join Seats s on bk.IDSeat = s.ID
							inner join SeatNos sn on bk.IDSeatNo = sn.ID
							inner join Cars c on bk.IDCar = c.ID
							where bk.ID = @ID"
                );
        }

        public override void Down()
        {
            DropStoredProcedure("Proc_GetCustDetail");
        }
    }
}
