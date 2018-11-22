using CoreApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Data
{
    public class InitDb
    {
        public static void Initialize(ShoppingListContext context)
        {
            context.Database.EnsureCreated();

            if (context.ShoppingList.Any())
            {
                return;
            }

            context.ShoppingList.AddRange(
                new ShoppingList {  Ingredient = "brood", Amount = 1 },
                new ShoppingList {  Ingredient = "pattate", Amount = 2 }
            );
            context.SaveChanges();
        }
    }
}
