namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Proc_Status_Seat1 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Proc_Status_Seat1",
                p => new
                {
                    IDCar = p.Int()
                },
            @"Create Table #TempTable(
	            NameCar nvarchar(200),
	            Row varchar(3),
	            Seats varchar(2), 
	            selected_seats numeric(10)
            );
            with List as (
	                        Select a.Row, Row_number() over(partition By a.ID order by a.ID) as [Seats], a.IDCar, a.ID
	                        from Seats a join SeatNos b on a.ID = b.IDSeat
	                        where a.IDCar = @IDCar
                        )
            insert into #TempTable
                Select d.Name NameCar , l.Row Row, l.Seats, 
                case 
                    when c.Status = 1 then 1
                    else 0
                end selected_seats
                from List l left join SeatNos c on l.ID  = c.IDSeat and l.Seats = c.SeatNb
                            left join Cars d on l.IDCar = d.ID

            declare @alias_period_list as varchar(max)
            declare @period_list as varchar(max)
            declare @dynamic_pivot_query as varchar(max)
            select @alias_period_list = stuff((select distinct ',['+Seats +']' from #TempTable for xml path('')),1,1,'')
            select @period_list = stuff((select distinct ',['+Seats +']' from #TempTable for xml path('')),1,1,'')
            set @dynamic_pivot_query = 
                                        'select [NameCar],[Row],'+ @alias_period_list+'from (select [NameCar],[Row],[Seats],[selected_seats] 
                                         from #TempTable) as S Pivot(SUM(selected_seats) FOR [Seats] in ('+@period_list+')) as P'
            Create table #aa(
                NameCar nvarchar(max),
                Row nvarchar(max),
                a nvarchar (max),
                b nvarchar (max),
                c nvarchar (max),
                d nvarchar (max),
                e nvarchar (max)
            )
            insert into #aa            
                exec(@dynamic_pivot_query)
            select NameCar,Row, a as[row1],b as[row2],c as[row3],d as[row4],e as[row5] from #aa
            drop table #TempTable
            drop table #aa"
        );
        }

        public override void Down()
        {
            DropStoredProcedure("Proc_Status_Seat1");
        }
    }
}
