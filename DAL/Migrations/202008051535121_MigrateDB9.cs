namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDTOes", "ProductDTO_Id", "dbo.ProductDTOes");
            DropIndex("dbo.OrderDTOes", new[] { "ProductDTO_Id" });
            CreateTable(
                "dbo.ProductDTOClientProfiles",
                c => new
                    {
                        ProductDTO_Id = c.Int(nullable: false),
                        ClientProfile_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProductDTO_Id, t.ClientProfile_Id })
                .ForeignKey("dbo.ProductDTOes", t => t.ProductDTO_Id, cascadeDelete: true)
                .ForeignKey("dbo.ClientProfiles", t => t.ClientProfile_Id, cascadeDelete: true)
                .Index(t => t.ProductDTO_Id)
                .Index(t => t.ClientProfile_Id);
            
            DropColumn("dbo.OrderDTOes", "ProductDTO_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDTOes", "ProductDTO_Id", c => c.Int());
            DropForeignKey("dbo.ProductDTOClientProfiles", "ClientProfile_Id", "dbo.ClientProfiles");
            DropForeignKey("dbo.ProductDTOClientProfiles", "ProductDTO_Id", "dbo.ProductDTOes");
            DropIndex("dbo.ProductDTOClientProfiles", new[] { "ClientProfile_Id" });
            DropIndex("dbo.ProductDTOClientProfiles", new[] { "ProductDTO_Id" });
            DropTable("dbo.ProductDTOClientProfiles");
            CreateIndex("dbo.OrderDTOes", "ProductDTO_Id");
            AddForeignKey("dbo.OrderDTOes", "ProductDTO_Id", "dbo.ProductDTOes", "Id");
        }
    }
}
