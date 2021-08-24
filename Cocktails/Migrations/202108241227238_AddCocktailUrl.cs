namespace Cocktails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCocktailUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cocktails", "Url", c => c.String());
            AddColumn("dbo.Cocktails", "Ingredient_Id", c => c.Int());
            AddColumn("dbo.Ingredients", "Cocktail_Id", c => c.Int());
            CreateIndex("dbo.Cocktails", "Ingredient_Id");
            CreateIndex("dbo.Ingredients", "Cocktail_Id");
            AddForeignKey("dbo.Cocktails", "Ingredient_Id", "dbo.Ingredients", "Id");
            AddForeignKey("dbo.Ingredients", "Cocktail_Id", "dbo.Cocktails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Cocktail_Id", "dbo.Cocktails");
            DropForeignKey("dbo.Cocktails", "Ingredient_Id", "dbo.Ingredients");
            DropIndex("dbo.Ingredients", new[] { "Cocktail_Id" });
            DropIndex("dbo.Cocktails", new[] { "Ingredient_Id" });
            DropColumn("dbo.Ingredients", "Cocktail_Id");
            DropColumn("dbo.Cocktails", "Ingredient_Id");
            DropColumn("dbo.Cocktails", "Url");
        }
    }
}
