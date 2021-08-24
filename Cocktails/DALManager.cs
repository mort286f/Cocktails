using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class DALManager
    {
        List<Ingredient> ingredients = new List<Ingredient>()
        {
#region ingredients
            new Ingredient(){ Name = "Tequila"},
            new Ingredient(){ Name = "Dark Rum"},
            new Ingredient(){ Name = "Kahlua"},
            new Ingredient(){ Name = "Cachaca"},
            new Ingredient(){ Name = "Vodka"},
            new Ingredient(){ Name = "Bourbon"},
            new Ingredient(){ Name = "Italian Sweet Vermouth"},
            new Ingredient(){ Name = "French Dry Vermouth"},
            new Ingredient(){ Name = "White Rum"},
            new Ingredient(){ Name = "Cointreau"},
            new Ingredient(){ Name = "Cherry Brandy"},
            new Ingredient(){ Name = "Sloe Gin"},
            new Ingredient(){ Name = "Gin"},
            new Ingredient(){ Name = "Prosecco"},
            new Ingredient(){ Name = "Triple Sec"},
            new Ingredient(){ Name = "Lime Juice"},
            new Ingredient(){ Name = "Orange Curacao"},
            new Ingredient(){ Name = "Almond Syrup"},
            new Ingredient(){ Name = "Fresh Cream"},
            new Ingredient(){ Name = "Kahlua"},
            new Ingredient(){ Name = "Cachaca"},
            new Ingredient(){ Name = "Orange Juice"},
            new Ingredient(){ Name = "Tomato Juice"},
            new Ingredient(){ Name = "Water"},
            new Ingredient(){ Name = "Pink Grapefruit Juice"},
            new Ingredient(){ Name = "Cranberry Juice"},
            new Ingredient(){ Name = "Soda"},
            new Ingredient(){ Name = "Lemon Juice"},
            new Ingredient(){ Name = "Pineapple Juice"},
            new Ingredient(){ Name = "Coconut Cream"},
            new Ingredient(){ Name = "Grapefruit Juice"},
            new Ingredient(){ Name = "Cola"},
            new Ingredient(){ Name = "Peach Puree"}
#endregion
        };

        List<Cocktail> cocktails = new List<Cocktail>()
        {
            new Cocktail()
            {
                Name = "Mai tai",
                Ingredients = new List<CocktailIngredients>()
                {
                    new CocktailIngredients() { Name = "Dark rum"},
                    new CocktailIngredients() { Name = "Orange"},
                    new CocktailIngredients(){ Name = "Lime juice"},
                    new CocktailIngredients(){ Name = "Almond Syrup"}
                }
            }
        };

        public void CreateCocktail(string cocktailName, List<CocktailIngredients> ingredients)
        {
            using (var ctx = new CocktailContext())
            {
                var cocktail = new Cocktail()
                {
                    Name = cocktailName,
                    Ingredients = ingredients,
                };

                ctx.Cocktails.Add(cocktail);
                ctx.SaveChanges();
            }
        }
        public void SetDB()
        {
            using (var ctx = new CocktailContext())
            {
                foreach (var ingredient in ingredients)
                {
                    ctx.Ingredients.Add(ingredient);
                }

                CreateCocktail("Mai tai", new List<CocktailIngredients>()
                {
                    new CocktailIngredients() { Name = "Dark rum"},
                    new CocktailIngredients() { Name = "Orange"},
                    new CocktailIngredients() { Name = "Lime juice"},
                    new CocktailIngredients() { Name = "Almond Syrup"}
                });
                CreateCocktail("Bloody mary", new List<CocktailIngredients>()
                {
                    new CocktailIngredients() { Name = "Tomato juice"},
                    new CocktailIngredients() { Name = "Vodka"}
                });
                CreateCocktail("Martini", new List<CocktailIngredients>()
                {
                    new CocktailIngredients() { Name = "French Dry Vermouth"},
                    new CocktailIngredients() { Name = "Gin"}
                });
                CreateCocktail("Cuba libre", new List<CocktailIngredients>()
                {
                    new CocktailIngredients() { Name = "Cola"},
                    new CocktailIngredients() { Name = "Lime juice"},
                    new CocktailIngredients() { Name = "White rum"}
                });
                CreateCocktail("Mojito", new List<CocktailIngredients>()
                {
                    new CocktailIngredients() { Name = "Lime juice"},
                    new CocktailIngredients() { Name = "White rum"}
                });

                ctx.SaveChanges();
            }
        }
        public List<Cocktail> GetCocktail(string input)
        {
            using (var ctx = new CocktailContext())
            {
                var cocktail = ctx.Cocktails.Where(x => x.Name.Equals(input)).Include(x => x.Ingredients).ToList();

                return cocktail;
            }
        }
        public void DeleteCocktail(string cocktailName)
        {
            using (var ctx = new CocktailContext())
            {
                List<Cocktail> cocktail = ctx.Cocktails.Where(x => x.Name.Equals(cocktailName)).Include(c => c.Ingredients).ToList();
                ctx.Cocktails.Remove(cocktail.FirstOrDefault());
                ctx.SaveChanges();
            }
        }
    }
}
