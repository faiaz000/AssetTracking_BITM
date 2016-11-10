namespace AssetTracking.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebranchmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetLocations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Branch_id = c.Int(),
                        Organization_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Branches", t => t.Branch_id)
                .ForeignKey("dbo.Organizations", t => t.Organization_id)
                .Index(t => t.Branch_id)
                .Index(t => t.Organization_id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Organization_id = c.Int(nullable: false),
                        BranchName = c.String(),
                        ShortName = c.String(),
                        Organization_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Organizations", t => t.Organization_id1)
                .Index(t => t.Organization_id1);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                        Code = c.String(nullable: false, maxLength: 3),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        GeneralCategoryId = c.Int(nullable: false),
                        CategoryCode = c.String(nullable: false, maxLength: 3),
                        Category_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GeneralCategories", t => t.GeneralCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_id)
                .Index(t => t.GeneralCategoryId)
                .Index(t => t.Category_id);
            
            CreateTable(
                "dbo.GeneralCategories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(),
                        SubCategoryCode = c.String(),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        GeneralCategory_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.GeneralCategories", t => t.GeneralCategory_id)
                .Index(t => t.CategoryId)
                .Index(t => t.GeneralCategory_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.SubCategories", "GeneralCategory_id", "dbo.GeneralCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "GeneralCategoryId", "dbo.GeneralCategories");
            DropForeignKey("dbo.AssetLocations", "Organization_id", "dbo.Organizations");
            DropForeignKey("dbo.AssetLocations", "Branch_id", "dbo.Branches");
            DropForeignKey("dbo.Branches", "Organization_id1", "dbo.Organizations");
            DropIndex("dbo.SubCategories", new[] { "GeneralCategory_id" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "Category_id" });
            DropIndex("dbo.Categories", new[] { "GeneralCategoryId" });
            DropIndex("dbo.Branches", new[] { "Organization_id1" });
            DropIndex("dbo.AssetLocations", new[] { "Organization_id" });
            DropIndex("dbo.AssetLocations", new[] { "Branch_id" });
            DropTable("dbo.SubCategories");
            DropTable("dbo.GeneralCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Organizations");
            DropTable("dbo.Branches");
            DropTable("dbo.AssetLocations");
        }
    }
}
