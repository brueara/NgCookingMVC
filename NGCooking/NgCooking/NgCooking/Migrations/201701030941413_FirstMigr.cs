namespace NgCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 30),
                        nameToDisplay = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 30),
                        name = c.String(nullable: false, maxLength: 30),
                        isAvailable = c.Boolean(nullable: false),
                        picture = c.String(),
                        CategoryId = c.String(maxLength: 30),
                        calories = c.Int(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.IngredientRecettes",
                c => new
                    {
                        recetteId = c.String(nullable: false, maxLength: 50),
                        ingredientId = c.String(nullable: false, maxLength: 30),
                        quantite = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => new { t.recetteId, t.ingredientId })
                .ForeignKey("dbo.Ingredients", t => t.ingredientId, cascadeDelete: true)
                .ForeignKey("dbo.Recettes", t => t.recetteId, cascadeDelete: true)
                .Index(t => t.recetteId)
                .Index(t => t.ingredientId);
            
            CreateTable(
                "dbo.Recettes",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 50),
                        name = c.String(nullable: false, maxLength: 30),
                        isAvailable = c.Boolean(nullable: false),
                        picture = c.String(),
                        calories = c.Int(nullable: false),
                        preparation = c.String(nullable: false, storeType: "ntext"),
                        average = c.Double(nullable: false),
                        creation = c.DateTime(nullable: false),
                        ChiefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Communautes", t => t.ChiefId, cascadeDelete: true)
                .Index(t => t.ChiefId);
            
            CreateTable(
                "dbo.Communautes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstname = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        level = c.Double(nullable: false),
                        city = c.String(nullable: false, maxLength: 50),
                        picture = c.String(),
                        birth = c.DateTime(nullable: false),
                        bio = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CommunauteRecettes",
                c => new
                    {
                        recetteId = c.String(nullable: false, maxLength: 50),
                        communauteId = c.Int(nullable: false),
                        title = c.String(nullable: false, maxLength: 50),
                        comment = c.String(nullable: false, maxLength: 400),
                        mark = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.recetteId, t.communauteId })
                .ForeignKey("dbo.Communautes", t => t.communauteId, cascadeDelete: true)
                .ForeignKey("dbo.Recettes", t => t.recetteId, cascadeDelete: false)
                .Index(t => t.recetteId)
                .Index(t => t.communauteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IngredientRecettes", "recetteId", "dbo.Recettes");
            DropForeignKey("dbo.Recettes", "ChiefId", "dbo.Communautes");
            DropForeignKey("dbo.CommunauteRecettes", "recetteId", "dbo.Recettes");
            DropForeignKey("dbo.CommunauteRecettes", "communauteId", "dbo.Communautes");
            DropForeignKey("dbo.IngredientRecettes", "ingredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Ingredients", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CommunauteRecettes", new[] { "communauteId" });
            DropIndex("dbo.CommunauteRecettes", new[] { "recetteId" });
            DropIndex("dbo.Recettes", new[] { "ChiefId" });
            DropIndex("dbo.IngredientRecettes", new[] { "ingredientId" });
            DropIndex("dbo.IngredientRecettes", new[] { "recetteId" });
            DropIndex("dbo.Ingredients", new[] { "CategoryId" });
            DropTable("dbo.CommunauteRecettes");
            DropTable("dbo.Communautes");
            DropTable("dbo.Recettes");
            DropTable("dbo.IngredientRecettes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Categories");
        }
    }
}
