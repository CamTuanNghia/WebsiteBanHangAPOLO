﻿namespace WebsiteBanHangAPOLO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "Alias", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.tb_New", "Alias", c => c.String());
            AddColumn("dbo.tb_Post", "Alias", c => c.String());
            AlterColumn("dbo.tb_Category", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "Title", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.tb_Post", "Alias");
            DropColumn("dbo.tb_New", "Alias");
            DropColumn("dbo.tb_Category", "Alias");
        }
    }
}