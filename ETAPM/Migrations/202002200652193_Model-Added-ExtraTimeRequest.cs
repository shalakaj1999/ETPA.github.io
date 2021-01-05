namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelAddedExtraTimeRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExtraTimeRequests",
                c => new
                    {
                        ExtraTimeRequestId = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Message = c.String(),
                        RequestStatusId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExtraTimeRequestId)
                .ForeignKey("dbo.RequestStatus", t => t.RequestStatusId, cascadeDelete: true)
                .Index(t => t.RequestStatusId);
            
            CreateTable(
                "dbo.RequestStatus",
                c => new
                    {
                        RequestStatusId = c.Int(nullable: false, identity: true),
                        RequestStatusName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RequestStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExtraTimeRequests", "RequestStatusId", "dbo.RequestStatus");
            DropIndex("dbo.ExtraTimeRequests", new[] { "RequestStatusId" });
            DropTable("dbo.RequestStatus");
            DropTable("dbo.ExtraTimeRequests");
        }
    }
}
