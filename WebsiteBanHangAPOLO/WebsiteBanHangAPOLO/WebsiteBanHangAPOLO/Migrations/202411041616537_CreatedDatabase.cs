﻿namespace WebsiteBanHangAPOLO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Adv",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SeoTitle = c.String(),
                        Descripttion = c.String(),
                        Image = c.String(),
                        Type = c.Int(nullable: false),
                        Link = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        SeoTitle = c.String(),
                        Descripttion = c.String(),
                        SeoDecripttion = c.String(),
                        SeoKeywords = c.String(),
                        Position = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tb_New",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        CategoryId = c.String(),
                        Descripttion = c.String(),
                        Detail = c.String(),
                        SeoTitle = c.String(),
                        SeoDecription = c.String(),
                        SeoKeywords = c.String(),
                        Image = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Category", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.tb_Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CategoryId = c.String(),
                        Descripttion = c.String(),
                        Detail = c.String(),
                        SeoTitle = c.String(),
                        SeoDecription = c.String(),
                        SeoKeywords = c.String(),
                        Image = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Category", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.tb_Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Message = c.String(maxLength: 4000),
                        IsRead = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_OrderDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.tb_Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        CustomerName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_ProductCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Descripttion = c.String(),
                        Icon = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tb_Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        ProductCategoryId = c.Int(nullable: false),
                        Description = c.String(maxLength: 4000),
                        Detail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(maxLength: 250),
                        PriceSell = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        IsHome = c.Boolean(nullable: false),
                        IsSale = c.Boolean(nullable: false),
                        IsFeature = c.Boolean(nullable: false),
                        IsHot = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(maxLength: 500),
                        SeoKeywords = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_ProductCategory", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.tb_ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Image = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tb_Subcribe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Systemsetting",
                c => new
                    {
                        SettingKey = c.String(nullable: false, maxLength: 50),
                        SettingValue = c.String(maxLength: 4000),
                        SettingDecriptsion = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.SettingKey);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Fullname = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.tb_ProductCategory");
            DropForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order");
            DropForeignKey("dbo.tb_Post", "Category_ID", "dbo.tb_Category");
            DropForeignKey("dbo.tb_New", "Category_ID", "dbo.tb_Category");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.tb_ProductImage", new[] { "ProductId" });
            DropIndex("dbo.tb_Product", new[] { "ProductCategoryId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.tb_Post", new[] { "Category_ID" });
            DropIndex("dbo.tb_New", new[] { "Category_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.tb_Systemsetting");
            DropTable("dbo.tb_Subcribe");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.tb_ProductImage");
            DropTable("dbo.tb_Product");
            DropTable("dbo.tb_ProductCategory");
            DropTable("dbo.tb_Order");
            DropTable("dbo.tb_OrderDetail");
            DropTable("dbo.tb_Contact");
            DropTable("dbo.tb_Post");
            DropTable("dbo.tb_New");
            DropTable("dbo.tb_Category");
            DropTable("dbo.tb_Adv");
        }
    }
}
