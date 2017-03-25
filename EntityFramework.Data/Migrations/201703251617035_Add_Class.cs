namespace EntityFramework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        SchoolId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Classes", new[] { "SchoolId" });
            DropTable("dbo.Classes");
        }
    }
}
