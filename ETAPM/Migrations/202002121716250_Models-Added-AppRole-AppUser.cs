namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsAddedAppRoleAppUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppRoles",
                c => new
                    {
                        AppRoleId = c.Int(nullable: false),
                        AppRoleName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.AppRoleId);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        AppUserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 256),
                        MobileNo = c.String(nullable: false, maxLength: 10),
                        EmailId = c.String(nullable: false, maxLength: 256),
                        Password = c.String(nullable: false, maxLength: 256),
                        AppRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppUserId)
                .ForeignKey("dbo.AppRoles", t => t.AppRoleId, cascadeDelete: true)
                .Index(t => t.AppRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUsers", "AppRoleId", "dbo.AppRoles");
            DropIndex("dbo.AppUsers", new[] { "AppRoleId" });
            DropTable("dbo.AppUsers");
            DropTable("dbo.AppRoles");
        }
    }
}
