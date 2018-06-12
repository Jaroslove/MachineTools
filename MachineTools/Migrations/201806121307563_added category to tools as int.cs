namespace MachineTools.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcategorytotoolsasint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MachineTools", "Category_Id", "dbo.Categories");
            DropIndex("dbo.MachineTools", new[] { "Category_Id" });
            AddColumn("dbo.MachineTools", "IdCategory", c => c.Int(nullable: false));
            DropColumn("dbo.MachineTools", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MachineTools", "Category_Id", c => c.Int());
            DropColumn("dbo.MachineTools", "IdCategory");
            CreateIndex("dbo.MachineTools", "Category_Id");
            AddForeignKey("dbo.MachineTools", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
