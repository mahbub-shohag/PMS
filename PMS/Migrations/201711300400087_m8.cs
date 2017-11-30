namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserProjects", "UserId", "dbo.Users");
            DropIndex("dbo.UserProjects", new[] { "ProjectId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.UserProjects", new[] { "UserId" });
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        CommentedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.ProjectTasks", t => t.TaskId)
                .ForeignKey("dbo.Users", t => t.CommentedBy)
                .Index(t => t.ProjectId)
                .Index(t => t.TaskId)
                .Index(t => t.CommentedBy);
            
            CreateTable(
                "dbo.ProjectTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        Priority = c.String(),
                        ProjectId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateIndex("dbo.UserProjects", "ProjectId");
            CreateIndex("dbo.Users", "RoleId");
            CreateIndex("dbo.UserProjects", "UserId");
            AddForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects", "Id");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
            AddForeignKey("dbo.UserProjects", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProjects", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Comments", "CommentedBy", "dbo.Users");
            DropForeignKey("dbo.Comments", "TaskId", "dbo.ProjectTasks");
            DropForeignKey("dbo.ProjectTasks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropIndex("dbo.UserProjects", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.UserProjects", new[] { "ProjectId" });
            DropIndex("dbo.Comments", new[] { "CommentedBy" });
            DropIndex("dbo.Comments", new[] { "TaskId" });
            DropIndex("dbo.ProjectTasks", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            DropTable("dbo.ProjectTasks");
            DropTable("dbo.Comments");
            CreateIndex("dbo.UserProjects", "UserId");
            CreateIndex("dbo.Users", "RoleId");
            CreateIndex("dbo.UserProjects", "ProjectId");
            AddForeignKey("dbo.UserProjects", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
