namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectTasks", "project_Id", c => c.Int());
            CreateIndex("dbo.ProjectTasks", "project_Id");
            AddForeignKey("dbo.ProjectTasks", "project_Id", "dbo.Projects", "Id");
            DropColumn("dbo.ProjectTasks", "ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectTasks", "ProjectId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProjectTasks", "project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectTasks", new[] { "project_Id" });
            DropColumn("dbo.ProjectTasks", "project_Id");
        }
    }
}
