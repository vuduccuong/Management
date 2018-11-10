namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbDoAn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Code = c.String(nullable: false, maxLength: 255),
                        IDtype = c.Int(nullable: false),
                        IDDriver = c.Int(nullable: false),
                        IDRouter = c.Int(nullable: false),
                        isDel = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        isDel = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(maxLength: 255),
                        PhoneNumber = c.String(nullable: false, maxLength: 15, unicode: false),
                        Description = c.String(maxLength: 255),
                        isDel = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Routers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.String(nullable: false, maxLength: 255),
                        End = c.String(nullable: false, maxLength: 255),
                        TimeStart = c.String(nullable: false),
                        Description = c.String(maxLength: 255),
                        isDel = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SeatNos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDSeat = c.Int(nullable: false),
                        SeatNb = c.Int(nullable: false),
                        Status = c.Boolean(),
                        isDel = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDCar = c.Int(nullable: false),
                        Row = c.String(),
                        isDel = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDCar = c.Int(nullable: false),
                        Customer = c.Int(nullable: false),
                        SeatNb = c.Int(nullable: false),
                        isDel = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
            DropTable("dbo.Seats");
            DropTable("dbo.SeatNos");
            DropTable("dbo.Routers");
            DropTable("dbo.Drivers");
            DropTable("dbo.Customers");
            DropTable("dbo.Cars");
        }
    }
}
