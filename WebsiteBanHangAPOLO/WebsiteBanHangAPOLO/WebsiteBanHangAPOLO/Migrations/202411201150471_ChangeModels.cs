namespace WebsiteBanHangAPOLO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Post", "Descripttion", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Post", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Post", "SeoDecription", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Post", "SeoDecription", c => c.String());
            AlterColumn("dbo.tb_Post", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Post", "Descripttion", c => c.String());
        }
    }
}
