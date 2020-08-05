namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserDTOProductDTOes", "UserDTO_Id", "dbo.UserDTOes");
            DropForeignKey("dbo.UserDTOProductDTOes", "ProductDTO_Id", "dbo.ProductDTOes");
            DropIndex("dbo.UserDTOProductDTOes", new[] { "UserDTO_Id" });
            DropIndex("dbo.UserDTOProductDTOes", new[] { "ProductDTO_Id" });
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
            
            AddColumn("dbo.ClientProfiles", "Email", c => c.String());
            AddColumn("dbo.ClientProfiles", "Password", c => c.String());
            AddColumn("dbo.ClientProfiles", "UserName", c => c.String());
            AddColumn("dbo.ClientProfiles", "Role", c => c.String());
            AddColumn("dbo.ClientProfiles", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDTOes", "UserDTO_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProductDTOes", "UserDTO_Id");
            AddForeignKey("dbo.ProductDTOes", "UserDTO_Id", "dbo.UserDTOes", "Id");
            DropColumn("dbo.UserDTOes", "Photo");
            DropTable("dbo.UserDTOProductDTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserDTOProductDTOes",
                c => new
                    {
                        UserDTO_Id = c.String(nullable: false, maxLength: 128),
                        ProductDTO_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserDTO_Id, t.ProductDTO_Id });
            
            AddColumn("dbo.UserDTOes", "Photo", c => c.Binary());
            DropForeignKey("dbo.ProductDTOes", "UserDTO_Id", "dbo.UserDTOes");
            DropForeignKey("dbo.ProductDTOClientProfiles", "ClientProfile_Id", "dbo.ClientProfiles");
            DropForeignKey("dbo.ProductDTOClientProfiles", "ProductDTO_Id", "dbo.ProductDTOes");
            DropIndex("dbo.ProductDTOClientProfiles", new[] { "ClientProfile_Id" });
            DropIndex("dbo.ProductDTOClientProfiles", new[] { "ProductDTO_Id" });
            DropIndex("dbo.ProductDTOes", new[] { "UserDTO_Id" });
            DropColumn("dbo.ProductDTOes", "UserDTO_Id");
            DropColumn("dbo.ClientProfiles", "Age");
            DropColumn("dbo.ClientProfiles", "Role");
            DropColumn("dbo.ClientProfiles", "UserName");
            DropColumn("dbo.ClientProfiles", "Password");
            DropColumn("dbo.ClientProfiles", "Email");
            DropTable("dbo.ProductDTOClientProfiles");
            CreateIndex("dbo.UserDTOProductDTOes", "ProductDTO_Id");
            CreateIndex("dbo.UserDTOProductDTOes", "UserDTO_Id");
            AddForeignKey("dbo.UserDTOProductDTOes", "ProductDTO_Id", "dbo.ProductDTOes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserDTOProductDTOes", "UserDTO_Id", "dbo.UserDTOes", "Id", cascadeDelete: true);
        }
    }
}
