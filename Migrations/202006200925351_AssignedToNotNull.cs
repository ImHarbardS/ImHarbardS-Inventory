namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignedToNotNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "AssignedTo", "dbo.Employees");
            DropIndex("dbo.Items", new[] { "AssignedTo" });
            AlterColumn("dbo.Items", "AssignedTo", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "AssignedTo");
            AddForeignKey("dbo.Items", "AssignedTo", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "AssignedTo", "dbo.Employees");
            DropIndex("dbo.Items", new[] { "AssignedTo" });
            AlterColumn("dbo.Items", "AssignedTo", c => c.Int());
            CreateIndex("dbo.Items", "AssignedTo");
            AddForeignKey("dbo.Items", "AssignedTo", "dbo.Employees", "Id");
        }
    }
}
