namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editSearchCarByPointTIme : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("GetCarByPointTime");
            CreateStoredProcedure("GetCarByPointTime",
               p => new
               {
                   StartPoint = p.String(),
                   EndPoint = p.String(),
                   DateBook = p.String(),
                   Time = p.Int(),
               },
               @"
select c.ID IDCar,rt.ID IDRoute, c.Name as NameCar,c.Code as Code,rt.StartPoint as StartPoint, rt.EndPoint as EndPoint, rt.TimeStart ,COUNT( sn.Status) AS Count from SeatNos sn
 inner join Seats s on s.ID = sn.IDSeat
 inner join Cars c  on s.IDCar = c.ID
 inner join Routers rt on c.IDRouter = rt.ID
 where IDSeat in (
 select IDSeat from Cars where ID in (select c.ID IDCar from Cars c inner join Routers rt on c.IDRouter = rt.ID
where IDRouter in( 
Select ID from Routers where StartPoint =@StartPoint and EndPoint = @EndPoint and cast(TimeStart as int) >= @Time))) 
 and DateBook>=cast(@DateBook as date) and DateBook< DATEADD(d,1,cast(@DateBook as date))
 and sn.Status=0 and rt.StartPoint =@StartPoint and rt.EndPoint = @EndPoint and cast(rt.TimeStart as int) >= @Time
 group by c.ID, c.Name,c.Code, rt.EndPoint, rt.StartPoint, rt.TimeStart,rt.ID
"
                );
        }

        public override void Down()
        {
            DropStoredProcedure("GetCarByPointTime");
        }
    }
}
