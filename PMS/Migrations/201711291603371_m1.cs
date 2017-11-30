namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "roll_Id", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "roll_Id" });
            RenameColumn(table: "dbo.Users", name: "roll_Id", newName: "RoleId");
            AlterColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            AlterColumn("dbo.Users", "RoleId", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "roll_Id");
            CreateIndex("dbo.Users", "roll_Id");
            AddForeignKey("dbo.Users", "roll_Id", "dbo.Roles", "Id");
        }
    }
}
