using System.Collections.Generic;
using System.Linq;
using BoozeClues.Data;
using BoozeClues.Models;
using BoozeClues.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        List<CocktailRecipe> recipes = _dbContext
            .CocktailRecipes.Include(cr => cr.GlassType)
            .Include(cr => cr.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .Include(cr => cr.UserProfile)
            .ToList();

        List<CocktailRecipeDTO> recipeDtos = recipes
            .Select(cr => new CocktailRecipeDTO
            {
                Id = cr.Id,
                Name = cr.Name,
                Description = cr.Description,
                Instructions = cr.Instructions,
                GlassType = cr.GlassType.Name,
                Ingredients = cr
                    .RecipeIngredients.Select(ri => new IngredientDTO
                    {
                        Id = ri.Ingredient.Id,
                        Name = ri.Ingredient.Name,
                        Quantity = ri.Quantity,
                        IsAlcoholic = ri.Ingredient.IsAlcoholic
                    })
                    .ToList(),
                UserProfileId = cr.UserProfileId,
                UserProfile = cr.UserProfile.FullName
            })
            .ToList();

        return Ok(recipeDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetRecipeById(int id)
    {
        var recipe = _dbContext
            .CocktailRecipes.Include(cr => cr.GlassType)
            .Include(cr => cr.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .Include(cr => cr.UserProfile)
            .SingleOrDefault(cr => cr.Id == id);

        if (recipe == null)
        {
            return NotFound();
        }

        var recipeDto = new CocktailRecipeDTO
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Description = recipe.Description,
            Instructions = recipe.Instructions,
            GlassType = recipe.GlassType.Name,
            Ingredients = recipe
                .RecipeIngredients.Select(ri => new IngredientDTO
                {
                    Id = ri.Ingredient.Id,
                    Name = ri.Ingredient.Name,
                    Quantity = ri.Quantity,
                    IsAlcoholic = ri.Ingredient.IsAlcoholic
                })
                .ToList(),
            UserProfileId = recipe.UserProfileId,
            UserProfile = recipe.UserProfile.FullName,
            // ImageUrl = recipe.ImageUrl
        };

        return Ok(recipeDto);
    }

    [HttpPost]
    public IActionResult AddRecipe(CocktailRecipeDTO newRecipeDto)
    {
        if (newRecipeDto == null)
        {
            return BadRequest();
        }

        int glassTypeId =
            _dbContext.GlassTypes.FirstOrDefault(gt => gt.Name == newRecipeDto.GlassType)?.Id ?? 0;

        CocktailRecipe newRecipe = new CocktailRecipe
        {
            Name = newRecipeDto.Name,
            Description = newRecipeDto.Description,
            Instructions = newRecipeDto.Instructions,
            GlassTypeId = glassTypeId,
            UserProfileId = newRecipeDto.UserProfileId
        };

        _dbContext.CocktailRecipes.Add(newRecipe);
        _dbContext.SaveChanges();

        foreach (IngredientDTO ingredientDto in newRecipeDto.Ingredients)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient
            {
                CocktailRecipeId = newRecipe.Id,
                IngredientId = ingredientDto.Id,
                Quantity = ingredientDto.Quantity
            };

            _dbContext.RecipeIngredients.Add(recipeIngredient);
        }

        _dbContext.SaveChanges();

        return Ok();
    }
}
