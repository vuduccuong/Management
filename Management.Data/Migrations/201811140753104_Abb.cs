namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Abb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routers", "StartPoint", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Routers", "EndPoint", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Routers", "Start");
            DropColumn("dbo.Routers", "End");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routers", "End", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Routers", "Start", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Routers", "EndPoint");
            DropColumn("dbo.Routers", "StartPoint");
        }
    }
}
