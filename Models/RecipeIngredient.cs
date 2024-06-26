using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BoozeClues.Models;

public class RecipeIngredient
{
    public int CocktailRecipeId { get; set; }
    public int IngredientId { get; set; }

    public CocktailRecipe CocktailRecipe { get; set; }
    public Ingredient Ingredient { get; set; }
}
