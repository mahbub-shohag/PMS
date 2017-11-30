namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        DefaultPassword = c.String(),
                        UserStatus = c.Boolean(nullable: false),
                        roll_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.roll_Id)
                .Index(t => t.roll_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "roll_Id", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "roll_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
