namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdatedTaskFiles2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskFiles", "FileName", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaskFiles", "FileName");
        }
    }
}
