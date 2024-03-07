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

        // Tables
        public DbSet<Cocktail> Cocktails { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .HasDiscriminator<string>("IngredientDiscriminator")
                .HasValue<Ingredient>("Ingredient")
                .HasValue<Alcohol>("Alcohol")
                .HasValue<Liquor>("Liquor");

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Ingredient> Ingredients { get; set; } = default!;
        public DbSet<Alcohol> Alcohol { get; set; } = default!;
        public DbSet<Liquor> Liquor { get; set; } = default!;
    }
}
