using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BoozeClues.Models;

public class CocktailIngredient
{
    public int CocktailId { get; set; }
    public int IngredientId { get; set; }
    public string Quantity { get; set; }

    public Cocktail Cocktail { get; set; }
    public Ingredient Ingredient { get; set; }
}
