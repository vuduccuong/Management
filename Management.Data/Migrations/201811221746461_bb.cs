namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bb : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("Proc_CarDetal");
            DropStoredProcedure("Proc_CarDetal1");
            CreateStoredProcedure("Proc_CarDetal", @"Select a.ID,a.Name as [NameCar], a.Code,a.Status,b.Name as [NameDriver],c.StartPoint,c.EndPoint,c.TimeStart from Cars a inner join Drivers b on a.IDDriver = b.ID
					inner join  Routers c on a.IDRouter = c.ID
					order by a.CreatedDate");

        }

        public override void Down()
        {
            DropStoredProcedure("Proc_CarDetal");
        }
    }
}
