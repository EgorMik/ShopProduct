namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDTOes", "ProductDTO_Id", c => c.Int());
            CreateIndex("dbo.OrderDTOes", "ProductDTO_Id");
            AddForeignKey("dbo.OrderDTOes", "ProductDTO_Id", "dbo.ProductDTOes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDTOes", "ProductDTO_Id", "dbo.ProductDTOes");
            DropIndex("dbo.OrderDTOes", new[] { "ProductDTO_Id" });
            DropColumn("dbo.OrderDTOes", "ProductDTO_Id");
        }
    }
}
