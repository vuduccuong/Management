namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getIDBook : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Proc_GetByIDCus",

                p => new
                {
                    IDCustomer = p.Int(),
                },
                @"Select * from Books where IDCustomer = @IDCustomer");
        }
        
        public override void Down()
        {
            DropStoredProcedure("Proc_GetByIDCus");
        }
    }
}
