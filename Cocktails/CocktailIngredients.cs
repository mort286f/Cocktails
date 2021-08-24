using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    public class CocktailIngredients
    {
        [Key]
        public int CocktailId { get; set; }
        public string Name { get; set; }
    }
}
