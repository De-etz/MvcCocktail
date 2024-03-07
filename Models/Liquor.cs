using System.ComponentModel.DataAnnotations;

namespace MvcCocktail.Models;

public enum LiquorType {
    Vodka,
    Rum,
    Gin,
    Tequila,
    Whiskey,
    Brandy
}
public class Liquor : Alcohol
{
    public LiquorType LiquorType { get; set; }
}