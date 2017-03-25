namespace EntityFramework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class School_Adress_Column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schools", "Adress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schools", "Adress");
        }
    }
}
