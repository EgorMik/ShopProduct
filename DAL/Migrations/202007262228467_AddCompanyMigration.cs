namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "UserDTO_Id", "dbo.UserDTOes");
            DropIndex("dbo.Orders", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Orders", new[] { "UserDTO_Id" });
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
            
            CreateTable(
                "dbo.UserDTOOrderDTOes",
                c => new
                    {
                        UserDTO_Id = c.String(nullable: false, maxLength: 128),
                        OrderDTO_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserDTO_Id, t.OrderDTO_Id })
                .ForeignKey("dbo.UserDTOes", t => t.UserDTO_Id, cascadeDelete: true)
                .ForeignKey("dbo.OrderDTOes", t => t.OrderDTO_Id, cascadeDelete: true)
                .Index(t => t.UserDTO_Id)
                .Index(t => t.OrderDTO_Id);
            
            AddColumn("dbo.ProductDTOes", "OrdertId", c => c.Int());
            AddColumn("dbo.ProductDTOes", "OrdersDTO_Id", c => c.Int());
            CreateIndex("dbo.ProductDTOes", "OrdersDTO_Id");
            AddForeignKey("dbo.ProductDTOes", "OrdersDTO_Id", "dbo.OrderDTOes", "Id");
            DropColumn("dbo.Orders", "Customer_CustomerId");
            DropColumn("dbo.Orders", "UserDTO_Id");
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            AddColumn("dbo.Orders", "UserDTO_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "Customer_CustomerId", c => c.Int());
            DropForeignKey("dbo.UserDTOOrderDTOes", "OrderDTO_Id", "dbo.OrderDTOes");
            DropForeignKey("dbo.UserDTOOrderDTOes", "UserDTO_Id", "dbo.UserDTOes");
            DropForeignKey("dbo.ProductDTOes", "OrdersDTO_Id", "dbo.OrderDTOes");
            DropIndex("dbo.UserDTOOrderDTOes", new[] { "OrderDTO_Id" });
            DropIndex("dbo.UserDTOOrderDTOes", new[] { "UserDTO_Id" });
            DropIndex("dbo.ProductDTOes", new[] { "OrdersDTO_Id" });
            DropColumn("dbo.ProductDTOes", "OrdersDTO_Id");
            DropColumn("dbo.ProductDTOes", "OrdertId");
            DropTable("dbo.UserDTOOrderDTOes");
            DropTable("dbo.OrderDTOes");
            CreateIndex("dbo.Orders", "UserDTO_Id");
            CreateIndex("dbo.Orders", "Customer_CustomerId");
            AddForeignKey("dbo.Orders", "UserDTO_Id", "dbo.UserDTOes", "Id");
            AddForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers", "CustomerId");
        }
    }
}
