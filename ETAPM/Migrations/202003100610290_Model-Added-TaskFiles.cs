namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelAddedTaskFiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskFiles",
                c => new
                    {
                        TaskFileId = c.Int(nullable: false, identity: true),
                        TaskId = c.String(nullable: false),
                        Task_TaskId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskFileId)
                .ForeignKey("dbo.Tasks", t => t.Task_TaskId)
                .Index(t => t.Task_TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskFiles", "Task_TaskId", "dbo.Tasks");
            DropIndex("dbo.TaskFiles", new[] { "Task_TaskId" });
            DropTable("dbo.TaskFiles");
        }
    }
}
