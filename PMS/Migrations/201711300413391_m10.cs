namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectTasks", "project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectTasks", new[] { "project_Id" });
            RenameColumn(table: "dbo.ProjectTasks", name: "project_Id", newName: "ProjectId");
            AlterColumn("dbo.ProjectTasks", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectTasks", "ProjectId");
            AddForeignKey("dbo.ProjectTasks", "ProjectId", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectTasks", new[] { "ProjectId" });
            AlterColumn("dbo.ProjectTasks", "ProjectId", c => c.Int());
            RenameColumn(table: "dbo.ProjectTasks", name: "ProjectId", newName: "project_Id");
            CreateIndex("dbo.ProjectTasks", "project_Id");
            AddForeignKey("dbo.ProjectTasks", "project_Id", "dbo.Projects", "Id");
        }
    }
}
