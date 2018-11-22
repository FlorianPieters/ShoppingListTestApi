using CoreApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Data
{
    public class ShoppingListContext: DbContext
    {
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options) { }
        public DbSet<ShoppingList> ShoppingList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShoppingList>().ToTable("ShopptingList");

            base.OnModelCreating(builder);
        }
    }
}
