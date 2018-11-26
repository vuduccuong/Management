namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSearchCarByRoute1 : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("Proc_SearchCarByRoute");
            CreateStoredProcedure("Proc_SearchCarByRoute",
                p => new
                {
                    IDRouter = p.Int(),
                    TimeStart = p.String()
                },
            @"Select  c.ID,c.Name from Cars c inner join Routers rt on c.IDRouter = rt.ID
                where rt.ID = @IDRouter and cast(rt.TimeStart as int) >= cast(@TimeStart as int)"
            );
        }

        public override void Down()
        {
            DropStoredProcedure("Proc_SearchCarByRoute");
        }
    }
}
