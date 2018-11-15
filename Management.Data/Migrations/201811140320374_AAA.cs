namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AAA : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Routers", newName: "Routes");
            DropTable("dbo.TypeCars");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TypeCars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            RenameTable(name: "dbo.Routes", newName: "Routers");
        }
    }
}
