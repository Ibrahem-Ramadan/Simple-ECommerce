namespace ProductsSelection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSelectedProductsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SelectedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductPrice = c.Double(nullable: false),
                        ProductDiscription = c.String(),
                        ProductCategory = c.String(),
                        ProductImg = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SelectedProducts");
        }
    }
}
