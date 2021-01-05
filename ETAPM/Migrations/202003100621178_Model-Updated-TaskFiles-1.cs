namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdatedTaskFiles1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskFiles", "Task_TaskId", "dbo.Tasks");
            DropIndex("dbo.TaskFiles", new[] { "Task_TaskId" });
            DropColumn("dbo.TaskFiles", "TaskId");
            RenameColumn(table: "dbo.TaskFiles", name: "Task_TaskId", newName: "TaskId");
            AlterColumn("dbo.TaskFiles", "TaskId", c => c.Int(nullable: false));
            AlterColumn("dbo.TaskFiles", "TaskId", c => c.Int(nullable: false));
            CreateIndex("dbo.TaskFiles", "TaskId");
            AddForeignKey("dbo.TaskFiles", "TaskId", "dbo.Tasks", "TaskId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskFiles", "TaskId", "dbo.Tasks");
            DropIndex("dbo.TaskFiles", new[] { "TaskId" });
            AlterColumn("dbo.TaskFiles", "TaskId", c => c.Int());
            AlterColumn("dbo.TaskFiles", "TaskId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.TaskFiles", name: "TaskId", newName: "Task_TaskId");
            AddColumn("dbo.TaskFiles", "TaskId", c => c.String(nullable: false));
            CreateIndex("dbo.TaskFiles", "Task_TaskId");
            AddForeignKey("dbo.TaskFiles", "Task_TaskId", "dbo.Tasks", "TaskId");
        }
    }
}
