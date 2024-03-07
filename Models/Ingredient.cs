using System.ComponentModel.DataAnnotations;

namespace MvcCocktail.Models;

public class Ingredient
{
    public int Id { get; set; } 
    public required string Name { get; set; }
    public required string Quantity { get; set; }
}