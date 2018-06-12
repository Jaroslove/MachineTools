namespace MachineTools.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcomplextomanufactory : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.MachineTools", "Complex_Id");
            AddForeignKey("dbo.MachineTools", "Complex_Id", "dbo.Complexes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MachineTools", "Complex_Id", "dbo.Complexes");
            DropIndex("dbo.MachineTools", new[] { "Complex_Id" });
            DropColumn("dbo.MachineTools", "Complex_Id");
            DropTable("dbo.Complexes");
        }
    }
}
