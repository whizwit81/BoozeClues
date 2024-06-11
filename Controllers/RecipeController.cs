using Microsoft.AspNetCore.Mvc;
using BoozeClues.Models;
using BoozeClues.Data;
using Microsoft.EntityFrameworkCore;
using BoozeClues.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BoozeClues.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CocktailRecipeController : ControllerBase
{
    private readonly BoozeCluesDbContext _dbContext;

    public CocktailRecipeController(BoozeCluesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult GetAllCocktailRecipes()
    {
        List<CocktailRecipe> recipes = _dbContext.CocktailRecipes
            .Include(cr => cr.GlassType)
            .Include(cr => cr.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Include(cr => cr.UserProfile)
            .ToList();

        List<CocktailRecipeDTO> recipeDtos = recipes.Select(cr => new CocktailRecipeDTO
        {
            Id = cr.Id,
            Name = cr.Name,
            Description = cr.Description,
            Instructions = cr.Instructions,
            GlassType = cr.GlassType.Name,
            Ingredients = cr.RecipeIngredients.Select(ri => new IngredientDTO
            {
                Id = ri.Ingredient.Id,
                Name = ri.Ingredient.Name,
                Quantity = ri.Quantity,
                IsAlcoholic = ri.Ingredient.IsAlcoholic
            }).ToList(),
            UserProfileId = cr.UserProfileId,
            UserProfile = cr.UserProfile.FullName
        }).ToList();

        return Ok(recipeDtos);
    }
}