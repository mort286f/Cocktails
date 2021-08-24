using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    interface ICocktail
    {
        int Id { get; set; } 
        string Name { get; set; }
        List<Ingredient> Ingredients { get; set; }
    }
}
