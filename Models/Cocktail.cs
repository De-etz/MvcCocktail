using System.ComponentModel.DataAnnotations;

namespace MvcCocktail.Models;

public class Cocktail
{
    public int Id { get; set; }
    public required string Name { get; set; }
    [Range(1, 5)]
    public int? Rating { get; set; }
    [Range(1, 3)]
    public int? Strength { get; set; }
    public bool Shaken { get; set; }
    public string? Ingredients { get; set; }
    public List<Ingredient> IngredientList { get; set; } = [];
}