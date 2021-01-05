namespace ETAPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdatedTask1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tasks", "Weightage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Weightage", c => c.Int(nullable: false));
        }
    }
}
