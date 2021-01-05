namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsAddedTaskStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskStatus",
                c => new
                    {
                        TaskStatusId = c.Int(nullable: false),
                        TaskStatusName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.TaskStatusId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskStatus");
        }
    }
}
