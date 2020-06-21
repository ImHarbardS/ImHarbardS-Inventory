namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoleTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropIndex("dbo.Employees", new[] { "RoleId" });
            AlterColumn("dbo.Employees", "RoleId", c => c.Int());
            CreateIndex("dbo.Employees", "RoleId");
            AddForeignKey("dbo.Employees", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropIndex("dbo.Employees", new[] { "RoleId" });
            AlterColumn("dbo.Employees", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "RoleId");
            AddForeignKey("dbo.Employees", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
