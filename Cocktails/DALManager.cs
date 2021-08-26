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
        private static List<Ingredient> ingredients = new List<Ingredient>() //List of ingredients to put in the database
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

        public void CreateCocktail(string cocktailName, List<CocktailIngredients> ingredients)
        {
            
            using (var ctx = new CocktailContext())
            {
                //Create a new cocktail object that gets put into the database via the context class
                var cocktail = new Cocktail()
                {
                    Name = cocktailName,
                    Ingredients = ingredients,
                };

                //Adds the cocktail and saves changes made(this is really important)
                ctx.Cocktails.Add(cocktail);
                ctx.SaveChanges();
            }
        }

        public Cocktail GetAllCocktails()
        {
            using (var ctx = new CocktailContext())
            {
                //Gets all cocktails that consists in the databse including their list of ingredients.
                var cocktails = ctx.Cocktails.Where(x => x.Name != null).Include(i => i.Ingredients).ToList();
                foreach (var cocktail in ctx.Cocktails)
                {
                    Console.WriteLine("\nId: " + cocktail.Id);
                    Console.WriteLine("Name: " + cocktail.Name);
                    //Foreach to get all elements in the list of ingredients
                    foreach (var ingredient in cocktail.Ingredients)
                    {
                        Console.WriteLine("Ingredient: " + ingredient.Name);
                    }
                }
                return cocktails.FirstOrDefault();
            }
        }

        //Populates the DB with data, Only necessary to run once
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
        public Cocktail GetCocktail(string input)
        {
            using (var ctx = new CocktailContext())
            {
                //Finds the cocktail that has the same name as the one the user requested including its ingredients
                Cocktail cocktail = ctx.Cocktails.Where(x => x.Name.Equals(input)).Include(x => x.Ingredients).FirstOrDefault();
                return cocktail;
            }
        }
        public void DeleteCocktail(string cocktailName)
        {
            using (var ctx = new CocktailContext())
            {
                //Finds the cocktail to delete based on what the user inputted
                List<Cocktail> cocktail = ctx.Cocktails.Where(x => x.Name.Equals(cocktailName)).Include(c => c.Ingredients).ToList();
                ctx.Cocktails.Remove(cocktail.FirstOrDefault()); //Removes the first occurences
                ctx.SaveChanges();
            }
        }

        public void UpdateCocktail(string cocktailName, string newCocktailName)
        {
            using (var ctx = new CocktailContext())
            {
                //First, finds first occurence of the searched cocktail, since the cocktail name should be unique.
                Cocktail cocktail = ctx.Cocktails.Where(x =>x.Name.Equals(cocktailName)).FirstOrDefault();
                cocktail.Name = newCocktailName;
                ctx.SaveChanges();
            }
        }
    }
}
