namespace WebsiteBanHangAPOLO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class truetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_ProductSubCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(),
                        Descripttion = c.String(maxLength: 250),
                        Icon = c.String(),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(maxLength: 500),
                        SeoKeywords = c.String(maxLength: 200),
                        ParentCategoryID = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_ProductCategory", t => t.ParentCategoryID, cascadeDelete: true)
                .Index(t => t.ParentCategoryID);
            
            CreateTable(
                "dbo.tb_SubCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(),
                        SeoTitle = c.String(maxLength: 150),
                        Descripttion = c.String(maxLength: 150),
                        SeoDecripttion = c.String(maxLength: 150),
                        SeoKeywords = c.String(maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                        Position = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Category", t => t.ParentID, cascadeDelete: true)
                .Index(t => t.ParentID);
            
            AddColumn("dbo.tb_New", "SubCategory_ID", c => c.Int());
            AddColumn("dbo.tb_Post", "SubCategory_ID", c => c.Int());
            AddColumn("dbo.tb_Product", "ProductSubCategory_ID", c => c.Int());
            CreateIndex("dbo.tb_New", "SubCategory_ID");
            CreateIndex("dbo.tb_Post", "SubCategory_ID");
            CreateIndex("dbo.tb_Product", "ProductSubCategory_ID");
            AddForeignKey("dbo.tb_Product", "ProductSubCategory_ID", "dbo.tb_ProductSubCategory", "ID");
            AddForeignKey("dbo.tb_New", "SubCategory_ID", "dbo.tb_SubCategory", "ID");
            AddForeignKey("dbo.tb_Post", "SubCategory_ID", "dbo.tb_SubCategory", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Post", "SubCategory_ID", "dbo.tb_SubCategory");
            DropForeignKey("dbo.tb_New", "SubCategory_ID", "dbo.tb_SubCategory");
            DropForeignKey("dbo.tb_SubCategory", "ParentID", "dbo.tb_Category");
            DropForeignKey("dbo.tb_Product", "ProductSubCategory_ID", "dbo.tb_ProductSubCategory");
            DropForeignKey("dbo.tb_ProductSubCategory", "ParentCategoryID", "dbo.tb_ProductCategory");
            DropIndex("dbo.tb_SubCategory", new[] { "ParentID" });
            DropIndex("dbo.tb_ProductSubCategory", new[] { "ParentCategoryID" });
            DropIndex("dbo.tb_Product", new[] { "ProductSubCategory_ID" });
            DropIndex("dbo.tb_Post", new[] { "SubCategory_ID" });
            DropIndex("dbo.tb_New", new[] { "SubCategory_ID" });
            DropColumn("dbo.tb_Product", "ProductSubCategory_ID");
            DropColumn("dbo.tb_Post", "SubCategory_ID");
            DropColumn("dbo.tb_New", "SubCategory_ID");
            DropTable("dbo.tb_SubCategory");
            DropTable("dbo.tb_ProductSubCategory");
        }
    }
}
