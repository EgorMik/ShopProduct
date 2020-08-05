namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageVisits", "PageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PageVisits", "PageUrl");
        }
    }
}
