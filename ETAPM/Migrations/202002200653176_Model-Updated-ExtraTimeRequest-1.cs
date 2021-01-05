namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdatedExtraTimeRequest1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ExtraTimeRequests", "TaskId");
            AddForeignKey("dbo.ExtraTimeRequests", "TaskId", "dbo.Tasks", "TaskId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExtraTimeRequests", "TaskId", "dbo.Tasks");
            DropIndex("dbo.ExtraTimeRequests", new[] { "TaskId" });
        }
    }
}
