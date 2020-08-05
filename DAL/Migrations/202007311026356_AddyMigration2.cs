namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddyMigration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserDTOOrderDTOes", "UserDTO_Id", "dbo.UserDTOes");
            DropForeignKey("dbo.UserDTOOrderDTOes", "OrderDTO_Id", "dbo.OrderDTOes");
            DropIndex("dbo.UserDTOOrderDTOes", new[] { "UserDTO_Id" });
            DropIndex("dbo.UserDTOOrderDTOes", new[] { "OrderDTO_Id" });
            RenameColumn(table: "dbo.ProductDTOes", name: "OrdersDTO_Id", newName: "OrderDTO_Id");
            RenameIndex(table: "dbo.ProductDTOes", name: "IX_OrdersDTO_Id", newName: "IX_OrderDTO_Id");
            CreateTable(
                "dbo.Counts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Counts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDTOProductDTOes",
                c => new
                    {
                        UserDTO_Id = c.String(nullable: false, maxLength: 128),
                        ProductDTO_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserDTO_Id, t.ProductDTO_Id })
                .ForeignKey("dbo.UserDTOes", t => t.UserDTO_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductDTOes", t => t.ProductDTO_Id, cascadeDelete: true)
                .Index(t => t.UserDTO_Id)
                .Index(t => t.ProductDTO_Id);
            
            AddColumn("dbo.UserDTOes", "OrderDTO_Id", c => c.Int());
            CreateIndex("dbo.UserDTOes", "OrderDTO_Id");
            AddForeignKey("dbo.UserDTOes", "OrderDTO_Id", "dbo.OrderDTOes", "Id");
            DropColumn("dbo.ProductDTOes", "OrdertId");
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
            
            AddColumn("dbo.ProductDTOes", "OrdertId", c => c.Int());
            DropForeignKey("dbo.UserDTOes", "OrderDTO_Id", "dbo.OrderDTOes");
            DropForeignKey("dbo.UserDTOProductDTOes", "ProductDTO_Id", "dbo.ProductDTOes");
            DropForeignKey("dbo.UserDTOProductDTOes", "UserDTO_Id", "dbo.UserDTOes");
            DropIndex("dbo.UserDTOProductDTOes", new[] { "ProductDTO_Id" });
            DropIndex("dbo.UserDTOProductDTOes", new[] { "UserDTO_Id" });
            DropIndex("dbo.UserDTOes", new[] { "OrderDTO_Id" });
            DropColumn("dbo.UserDTOes", "OrderDTO_Id");
            DropTable("dbo.UserDTOProductDTOes");
            DropTable("dbo.Counts");
            RenameIndex(table: "dbo.ProductDTOes", name: "IX_OrderDTO_Id", newName: "IX_OrdersDTO_Id");
            RenameColumn(table: "dbo.ProductDTOes", name: "OrderDTO_Id", newName: "OrdersDTO_Id");
            CreateIndex("dbo.UserDTOOrderDTOes", "OrderDTO_Id");
            CreateIndex("dbo.UserDTOOrderDTOes", "UserDTO_Id");
            AddForeignKey("dbo.UserDTOOrderDTOes", "OrderDTO_Id", "dbo.OrderDTOes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserDTOOrderDTOes", "UserDTO_Id", "dbo.UserDTOes", "Id", cascadeDelete: true);
        }
    }
}
