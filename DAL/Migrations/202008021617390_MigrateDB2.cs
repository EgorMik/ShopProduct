namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDTOClientProfiles", "ProductDTO_Id", "dbo.ProductDTOes");
            DropForeignKey("dbo.ProductDTOClientProfiles", "ClientProfile_Id", "dbo.ClientProfiles");
            DropForeignKey("dbo.ProductDTOes", "UserDTO_Id", "dbo.UserDTOes");
            DropForeignKey("dbo.UserDTOes", "OrderDTO_Id", "dbo.OrderDTOes");
            DropIndex("dbo.ProductDTOes", new[] { "OrderDTO_Id" });
            DropIndex("dbo.ProductDTOes", new[] { "UserDTO_Id" });
            DropIndex("dbo.UserDTOes", new[] { "OrderDTO_Id" });
            DropIndex("dbo.ProductDTOClientProfiles", new[] { "ProductDTO_Id" });
            DropIndex("dbo.ProductDTOClientProfiles", new[] { "ClientProfile_Id" });
            CreateTable(
                "dbo.CartLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Int(),
                        Products_Id = c.Int(),
                        ClientProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductDTOes", t => t.Products_Id)
                .ForeignKey("dbo.ClientProfiles", t => t.ClientProfile_Id)
                .Index(t => t.Products_Id)
                .Index(t => t.ClientProfile_Id);
            
            AddColumn("dbo.ClientProfiles", "OrderDTO_Id", c => c.Int());
            CreateIndex("dbo.ClientProfiles", "OrderDTO_Id");
            DropColumn("dbo.ProductDTOes", "OrderDTO_Id");
            DropColumn("dbo.ProductDTOes", "UserDTO_Id");
            DropColumn("dbo.UserDTOes", "OrderDTO_Id");
            DropTable("dbo.ProductDTOClientProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductDTOClientProfiles",
                c => new
                    {
                        ProductDTO_Id = c.Int(nullable: false),
                        ClientProfile_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProductDTO_Id, t.ClientProfile_Id });
            
            AddColumn("dbo.UserDTOes", "OrderDTO_Id", c => c.Int());
            AddColumn("dbo.ProductDTOes", "UserDTO_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.ProductDTOes", "OrderDTO_Id", c => c.Int());
            DropForeignKey("dbo.CartLines", "ClientProfile_Id", "dbo.ClientProfiles");
            DropForeignKey("dbo.CartLines", "Products_Id", "dbo.ProductDTOes");
            DropIndex("dbo.CartLines", new[] { "ClientProfile_Id" });
            DropIndex("dbo.CartLines", new[] { "Products_Id" });
            DropIndex("dbo.ClientProfiles", new[] { "OrderDTO_Id" });
            DropColumn("dbo.ClientProfiles", "OrderDTO_Id");
            DropTable("dbo.CartLines");
            CreateIndex("dbo.ProductDTOClientProfiles", "ClientProfile_Id");
            CreateIndex("dbo.ProductDTOClientProfiles", "ProductDTO_Id");
            CreateIndex("dbo.UserDTOes", "OrderDTO_Id");
            CreateIndex("dbo.ProductDTOes", "UserDTO_Id");
            CreateIndex("dbo.ProductDTOes", "OrderDTO_Id");
            AddForeignKey("dbo.UserDTOes", "OrderDTO_Id", "dbo.OrderDTOes", "Id");
            AddForeignKey("dbo.ProductDTOes", "UserDTO_Id", "dbo.UserDTOes", "Id");
            AddForeignKey("dbo.ProductDTOClientProfiles", "ClientProfile_Id", "dbo.ClientProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductDTOClientProfiles", "ProductDTO_Id", "dbo.ProductDTOes", "Id", cascadeDelete: true);
        }
    }
}
