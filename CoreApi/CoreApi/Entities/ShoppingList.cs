using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Entities
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Ingredient { get; set; }
        public int Amount { get; set; }
    }
}
