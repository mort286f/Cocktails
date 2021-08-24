using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DALManager manager = new DALManager();
            manager.DeleteCocktail("Lime juice");
            //manager.CreateCocktail("Lime juice", new List<CocktailIngredients> 
            //{ 
            //    new CocktailIngredients() { Name = "Soda"}, 
            //    new CocktailIngredients() { Name = "Tomato Juice"}, 
            //    new CocktailIngredients() { Name = "Triple Sec"}
            //});
            //manager.SetDB();
            //List<Cocktail> cocktail = manager.GetCocktail("Magarita");
            //foreach (var item in cocktail)
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.Name);
            //    foreach (var ingredients in item.Ingredients)
            //    {
            //        Console.WriteLine(ingredients.Name);
            //    }
            //}
            //Console.Read();
        }
    }
}
