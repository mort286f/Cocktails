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

            Console.WriteLine("Welcome to this awesome program about cocktails");
            int input;

            //UI interface
            do
            {
                Console.WriteLine("(1) Get all cocktails");
                Console.WriteLine("(2) Get specific cocktail");
                Console.WriteLine("(3) Create cocktail");
                Console.WriteLine("(4) Update cocktail name");
                Console.WriteLine("(5) Delete a cocktail");
                Console.WriteLine("(8) Populate DB");
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
                        Cocktail cocktail = manager.GetCocktail(cocktailSearch);
                        Console.WriteLine("Id: " + cocktail.Id);
                        Console.WriteLine("Name: " + cocktail.Name);
                        foreach (var ingredient in cocktail.Ingredients)
                        {
                            Console.WriteLine("Ingredient: " + ingredient.Name);
                        }
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
                    case 8:
                        manager.SetDB();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press a key to return to menu");
                Console.ReadLine();
                Console.Clear();


            } while (input != 9);
        }
    }
}
