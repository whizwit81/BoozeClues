using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BoozeClues.Models;

public class RecipeIngredientDTO
{
    public int CocktailRecipeId { get; set; }
    public int IngredientId { get; set; }

    public CocktailRecipeDTO? CocktailRecipe { get; set; }
    public IngredientDTO? Ingredient { get; set; }
}
