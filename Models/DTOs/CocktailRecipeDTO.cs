using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace BoozeClues.Models;

public class CocktailRecipeDTO
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Instructions { get; set; }
    public int GlassTypeId { get; set; }

    public string UserProfile { get; set; }
    public string GlassType { get; set; }
    // public string ImageUrl { get; set; }
    public List<RecipeIngredient> RecipeIngredients { get; set; }
    public List<IngredientDTO> Ingredients { get; set; }
}
