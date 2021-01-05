namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsAddedTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Weightage = c.Int(nullable: false),
                        Progress = c.Int(nullable: false),
                        TaskStatusId = c.Int(nullable: false),
                        ParentTaskId = c.Int(),
                        AssignedByAppUserId = c.Int(nullable: false),
                        AssignedToAppUserId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.AppUsers", t => t.AssignedByAppUserId, cascadeDelete: false)
                .ForeignKey("dbo.AppUsers", t => t.AssignedToAppUserId, cascadeDelete: false)
                .ForeignKey("dbo.Tasks", t => t.ParentTaskId)
                .ForeignKey("dbo.TaskStatus", t => t.TaskStatusId, cascadeDelete: false)
                .Index(t => t.TaskStatusId)
                .Index(t => t.ParentTaskId)
                .Index(t => t.AssignedByAppUserId)
                .Index(t => t.AssignedToAppUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskStatusId", "dbo.TaskStatus");
            DropForeignKey("dbo.Tasks", "ParentTaskId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "AssignedToAppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Tasks", "AssignedByAppUserId", "dbo.AppUsers");
            DropIndex("dbo.Tasks", new[] { "AssignedToAppUserId" });
            DropIndex("dbo.Tasks", new[] { "AssignedByAppUserId" });
            DropIndex("dbo.Tasks", new[] { "ParentTaskId" });
            DropIndex("dbo.Tasks", new[] { "TaskStatusId" });
            DropTable("dbo.Tasks");
        }
    }
}
