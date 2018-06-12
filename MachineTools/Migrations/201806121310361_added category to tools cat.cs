namespace MachineTools.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcategorytotoolscat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MachineTools", "Category_Id", c => c.Int());
            CreateIndex("dbo.MachineTools", "Category_Id");
            AddForeignKey("dbo.MachineTools", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MachineTools", "Category_Id", "dbo.Categories");
            DropIndex("dbo.MachineTools", new[] { "Category_Id" });
            DropColumn("dbo.MachineTools", "Category_Id");
        }
    }
}
