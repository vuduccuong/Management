namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class getBookWithIDCus : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetBookWhereIDCus",

                p => new
                {
                    IDCustomer = p.Int()
                },
                @"Select * from Bookings where IDCustomer = @IDCustomer"
                );
        }

        public override void Down()
        {
            DropStoredProcedure("GetBookWhereIDCus");
        }
    }
}
