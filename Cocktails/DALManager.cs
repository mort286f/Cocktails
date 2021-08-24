using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class DALManager
    {
        public string connString = "Data Source=(localdb)\\MSSQLLocalDB; providerName=System.Data.SqlClient; Initial Catalog=Cocktails.CocktailContext; providerName=System.Data.SqlClient; Integrated Security=true";

        public void CreateCocktail(string ingredName, string cocktailName)
        {
            using (var ctx = new CocktailContext())
            {
                List<Ingredient> cktlIngredients;
                cktlIngredients = Ingredient.ingredients.Where(x => x.Name == ingredName).ToList();
                var cocktail = new Cocktail() { Name = cocktailName, Ingredients = cktlIngredients };

                ctx.Cocktails.Add(cocktail);
                ctx.SaveChanges();
            }
        }
        public void SearchCocktail()
        {

        }
        public void GetCocktail()
        {

        }
        public void DeleteCocktail()
        {

        }
        public void UpdateCocktail()
        {

        }
        public void SetIngredients()
        {
            using (var ctx = new CocktailContext())
            {
                foreach (var ingredient in Ingredient.ingredients)
                {
                    ctx.Ingredients.Add(ingredient);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
