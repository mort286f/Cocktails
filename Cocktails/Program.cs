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
            //manager.UpdateCocktail("Mojitoo", "Mojito");

            Console.WriteLine("Welcome to this awesome program about cocktails");
            int input;

            do
            {
                Console.WriteLine("(1) Get all cocktails");
                Console.WriteLine("(2) Get specific cocktail");
                Console.WriteLine("(3) Create cocktail");
                Console.WriteLine("(4) Update cocktail name");
                Console.WriteLine("(5) Delete a cocktail");
                Console.WriteLine("(9) Exit console");
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        manager.GetAllCocktails();
                        break;
                    case 2:
                        Console.WriteLine("Input search parameter for cocktail:");
                        string cocktailSearch = Console.ReadLine();
                        manager.GetCocktail(cocktailSearch);
                        break;
                    case 3:
                        Console.WriteLine("Not implemented yet ");
                        //manager.CreateCocktail();
                        break;
                    case 4:
                        Console.WriteLine("Which cocktail do you want to update: ");
                        string cocktailName = Console.ReadLine();
                        Console.WriteLine("Input new cocktail name");
                        string newCocktailName = Console.ReadLine();
                        manager.UpdateCocktail(cocktailName, newCocktailName);
                        Console.WriteLine("Cocktail updated");
                        break;
                    case 5:
                        Console.WriteLine("Input cocktail name to delete:");
                        string cocktailNameForDel = Console.ReadLine();
                        manager.DeleteCocktail(cocktailNameForDel);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press a key to return to menu");
                Console.ReadLine();
                Console.Clear();


            } while (input != 9);
            //manager.DeleteCocktail("Lime juice");
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
