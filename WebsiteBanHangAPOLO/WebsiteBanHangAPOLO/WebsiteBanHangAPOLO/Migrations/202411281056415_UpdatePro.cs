namespace WebsiteBanHangAPOLO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.tb_Product", "PriceSell", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "PriceSell", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.tb_Product", "OriginalPrice");
        }
    }
}
