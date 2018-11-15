namespace Management.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableHistoryAction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoryActions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        ActionName = c.String(),
                        ActionDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HistoryActions");
        }
    }
}
