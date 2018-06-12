namespace MachineTools.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedforeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MachineTools", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.MachineTools", new[] { "Category_Id1" });
            DropColumn("dbo.MachineTools", "Category_Id");
            RenameColumn(table: "dbo.MachineTools", name: "Category_Id1", newName: "Category_Id");
            Sql("UPDATE [dbo].[MachineTools] SET Category_Id = 2 WHERE Category_Id IS NULL");
            AlterColumn("dbo.MachineTools", "Category_Id", c => c.Int(nullable: false, defaultValue: 2));
            CreateIndex("dbo.MachineTools", "Category_Id");
            AddForeignKey("dbo.MachineTools", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MachineTools", "Category_Id", "dbo.Categories");
            DropIndex("dbo.MachineTools", new[] { "Category_Id" });
            AlterColumn("dbo.MachineTools", "Category_Id", c => c.Int());
            RenameColumn(table: "dbo.MachineTools", name: "Category_Id", newName: "Category_Id1");
            AddColumn("dbo.MachineTools", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MachineTools", "Category_Id1");
            AddForeignKey("dbo.MachineTools", "Category_Id1", "dbo.Categories", "Id");
        }
    }
}
