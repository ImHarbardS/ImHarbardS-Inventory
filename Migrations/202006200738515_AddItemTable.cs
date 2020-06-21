namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AssignedTo = c.Int(),
                        AssignedBy = c.Int(),
                        Comments = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.AssignedTo)
                .Index(t => t.AssignedTo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "AssignedTo", "dbo.Employees");
            DropIndex("dbo.Items", new[] { "AssignedTo" });
            DropTable("dbo.Items");
        }
    }
}
