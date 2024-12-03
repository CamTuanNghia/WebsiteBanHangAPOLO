namespace WebsiteBanHangAPOLO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ProductCategory", "Alias", c => c.String());
            AddColumn("dbo.tb_ProductCategory", "SeoTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_ProductCategory", "SeoDescription", c => c.String(maxLength: 500));
            AddColumn("dbo.tb_ProductCategory", "SeoKeywords", c => c.String(maxLength: 200));
            AddColumn("dbo.tb_Product", "Alias", c => c.String());
            AddColumn("dbo.tb_Product", "ProductCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "ProductCode");
            DropColumn("dbo.tb_Product", "Alias");
            DropColumn("dbo.tb_ProductCategory", "SeoKeywords");
            DropColumn("dbo.tb_ProductCategory", "SeoDescription");
            DropColumn("dbo.tb_ProductCategory", "SeoTitle");
            DropColumn("dbo.tb_ProductCategory", "Alias");
        }
    }
}
