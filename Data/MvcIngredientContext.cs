using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCocktail.Models;

namespace MvcCocktail.Data
{
    public class MvcIngredientContext : DbContext
    {
        public MvcIngredientContext (DbContextOptions<MvcIngredientContext> options)
            : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; } = default!;
    }
}
