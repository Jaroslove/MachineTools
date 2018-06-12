namespace MachineTools.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcategorytotools : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MachineTools", "Complex_Id", "dbo.Complexes");
            DropIndex("dbo.MachineTools", new[] { "Complex_Id" });
            AddColumn("dbo.MachineTools", "Category_Id", c => c.Int());
            CreateIndex("dbo.MachineTools", "Category_Id");
            AddForeignKey("dbo.MachineTools", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.MachineTools", "Complex_Id");
            DropTable("dbo.Complexes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Complexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MachineTools", "Complex_Id", c => c.Int());
            DropForeignKey("dbo.MachineTools", "Category_Id", "dbo.Categories");
            DropIndex("dbo.MachineTools", new[] { "Category_Id" });
            DropColumn("dbo.MachineTools", "Category_Id");
            CreateIndex("dbo.MachineTools", "Complex_Id");
            AddForeignKey("dbo.MachineTools", "Complex_Id", "dbo.Complexes", "Id");
        }
    }
}
