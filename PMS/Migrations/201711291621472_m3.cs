namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CodeName = c.String(),
                        Description = c.String(),
                        PossibleStartDate = c.DateTime(nullable: false),
                        PossibleEndDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.project_Id)
                .Index(t => t.project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectFiles", "project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectFiles", new[] { "project_Id" });
            DropTable("dbo.ProjectFiles");
            DropTable("dbo.Projects");
        }
    }
}
