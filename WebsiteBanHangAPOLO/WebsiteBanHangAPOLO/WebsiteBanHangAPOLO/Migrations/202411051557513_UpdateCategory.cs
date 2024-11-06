namespace WebsiteBanHangAPOLO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "SeoTitle", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Category", "Descripttion", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Category", "SeoDecripttion", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Category", "SeoKeywords", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tb_Category", "SeoDecripttion", c => c.String());
            AlterColumn("dbo.tb_Category", "Descripttion", c => c.String());
            AlterColumn("dbo.tb_Category", "SeoTitle", c => c.String());
        }
    }
}
