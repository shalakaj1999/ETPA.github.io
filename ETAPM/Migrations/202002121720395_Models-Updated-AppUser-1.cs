namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsUpdatedAppUser1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AppUsers", "LastName", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.AppUsers", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppUsers", "FullName", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.AppUsers", "LastName");
            DropColumn("dbo.AppUsers", "FirstName");
        }
    }
}
