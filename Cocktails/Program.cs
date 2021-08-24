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


        List<Ingredient> ingredients = new List<Ingredient>()
        {
#region ingredients
            new Ingredient("Tequila"),
            new Ingredient("Dark rum"),
            new Ingredient("Kahlua"),
            new Ingredient("Cachaca"),
            new Ingredient("Vodka"),
            new Ingredient("Bourbon"),
            new Ingredient("Italian Sweet Vermouth"),
            new Ingredient("French Dry Vermouth"),
            new Ingredient("White rum"),
            new Ingredient("Cointreau"),
            new Ingredient("Cherry Brandy"),
            new Ingredient("Sloe Gin"),
            new Ingredient("Gin"),
            new Ingredient("Prosecco"),
            new Ingredient("Triple sec"),
            new Ingredient("Lime juice"),
            new Ingredient("Orange Curacao"),
            new Ingredient("Almond Syrup"),
            new Ingredient("Fresh cream"),
            new Ingredient("Kahlua"),
            new Ingredient("Cachaca"),
            new Ingredient("Orange juice"),
            new Ingredient("Tomato juice"),
            new Ingredient("Water"),
            new Ingredient("Pink grapefruit juice"),
            new Ingredient("Cranberry juice"),
            new Ingredient("Soda"),
            new Ingredient("Lemon juice"),
            new Ingredient("Pineapple juice"),
            new Ingredient("Coconut cream"),
            new Ingredient("Grapefruit juice"),
            new Ingredient("Cola"),
            new Ingredient("Peach puree")
#endregion
        };
        static void Main(string[] args)
        {
            
            DALManager manager = new DALManager();
            manager.CreateCocktail("Lime juice", "Magarita");
        }
    }
}
