namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDTOes", "OrdersDTO_Id", "dbo.OrderDTOes");
            DropForeignKey("dbo.UserDTOOrderDTOes", "UserDTO_Id", "dbo.UserDTOes");
            DropForeignKey("dbo.UserDTOOrderDTOes", "OrderDTO_Id", "dbo.OrderDTOes");
            DropIndex("dbo.ProductDTOes", new[] { "OrdersDTO_Id" });
            DropIndex("dbo.UserDTOOrderDTOes", new[] { "UserDTO_Id" });
            DropIndex("dbo.UserDTOOrderDTOes", new[] { "OrderDTO_Id" });
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
            DropColumn("dbo.ProductDTOes", "OrdertId");
            DropColumn("dbo.ProductDTOes", "OrdersDTO_Id");
            DropTable("dbo.OrderDTOes");
            DropTable("dbo.UserDTOes");
            DropTable("dbo.UserDTOOrderDTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserDTOOrderDTOes",
                c => new
                    {
                        UserDTO_Id = c.String(nullable: false, maxLength: 128),
                        OrderDTO_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserDTO_Id, t.OrderDTO_Id });
            
            CreateTable(
                "dbo.UserDTOes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Password = c.String(),
                        UserName = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        Role = c.String(),
                        Age = c.Int(nullable: false),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductDTOes", "OrdersDTO_Id", c => c.Int());
            AddColumn("dbo.ProductDTOes", "OrdertId", c => c.Int());
            DropForeignKey("dbo.ProductDTOClientProfiles", "ClientProfile_Id", "dbo.ClientProfiles");
            DropForeignKey("dbo.ProductDTOClientProfiles", "ProductDTO_Id", "dbo.ProductDTOes");
            DropIndex("dbo.ProductDTOClientProfiles", new[] { "ClientProfile_Id" });
            DropIndex("dbo.ProductDTOClientProfiles", new[] { "ProductDTO_Id" });
            DropColumn("dbo.ClientProfiles", "Age");
            DropColumn("dbo.ClientProfiles", "Role");
            DropColumn("dbo.ClientProfiles", "UserName");
            DropColumn("dbo.ClientProfiles", "Password");
            DropColumn("dbo.ClientProfiles", "Email");
            DropTable("dbo.ProductDTOClientProfiles");
            CreateIndex("dbo.UserDTOOrderDTOes", "OrderDTO_Id");
            CreateIndex("dbo.UserDTOOrderDTOes", "UserDTO_Id");
            CreateIndex("dbo.ProductDTOes", "OrdersDTO_Id");
            AddForeignKey("dbo.UserDTOOrderDTOes", "OrderDTO_Id", "dbo.OrderDTOes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserDTOOrderDTOes", "UserDTO_Id", "dbo.UserDTOes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductDTOes", "OrdersDTO_Id", "dbo.OrderDTOes", "Id");
        }
    }
}
