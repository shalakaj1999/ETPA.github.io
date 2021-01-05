namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelAddedNotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        DataId = c.Int(nullable: false),
                        Message = c.String(),
                        IsRead = c.Boolean(nullable: false),
                        NotificationToAppUserId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.AppUsers", t => t.NotificationToAppUserId, cascadeDelete: true)
                .Index(t => t.NotificationToAppUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "NotificationToAppUserId", "dbo.AppUsers");
            DropIndex("dbo.Notifications", new[] { "NotificationToAppUserId" });
            DropTable("dbo.Notifications");
        }
    }
}
