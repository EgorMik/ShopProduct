namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageVisits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Visits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PageVisits");
        }
    }
}
