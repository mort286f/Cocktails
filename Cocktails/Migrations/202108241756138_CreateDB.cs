namespace Cocktails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cocktails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CocktailIngredients",
                c => new
                    {
                        CocktailId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cocktail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CocktailId)
                .ForeignKey("dbo.Cocktails", t => t.Cocktail_Id)
                .Index(t => t.Cocktail_Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CocktailIngredients", "Cocktail_Id", "dbo.Cocktails");
            DropIndex("dbo.CocktailIngredients", new[] { "Cocktail_Id" });
            DropTable("dbo.Ingredients");
            DropTable("dbo.CocktailIngredients");
            DropTable("dbo.Cocktails");
        }
    }
}
