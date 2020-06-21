namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        ManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ManagerId)
                .Index(t => t.ManagerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ManagerId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "ManagerId" });
            DropTable("dbo.Employees");
        }
    }
}
