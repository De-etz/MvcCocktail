using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCocktail.Models;

namespace MvcCocktail.Data
{
    public class MvcCocktailContext : DbContext
    {
        public MvcCocktailContext (DbContextOptions<MvcCocktailContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCocktail.Models.Cocktail> Cocktails { get; set; } = default!;
    }
}
