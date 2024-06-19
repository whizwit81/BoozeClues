using System.Collections.Generic;
using System.Linq;
using BoozeClues.Data;
using BoozeClues.Models;
using BoozeClues.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
                GlassTypeId = cr.GlassTypeId,
                Image = cr.Image,
                Ingredients = cr
                    .RecipeIngredients.Select(ri => new IngredientDTO
                    {
                        Id = ri.Ingredient.Id,
                        Name = ri.Ingredient.Name,
                        IsAlcoholic = ri.Ingredient.IsAlcoholic
                    })
                    .ToList(),
                UserProfileId = cr.UserProfileId,
                UserProfile = new UserProfileDTO
                {
                    Id = cr.UserProfile.Id,
                    FirstName = cr.UserProfile.FirstName,
                    LastName = cr.UserProfile.LastName
                }
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

        var recipeDTO = new CocktailRecipeDTO
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Description = recipe.Description,
            Instructions = recipe.Instructions,
            GlassTypeId = recipe.GlassTypeId,
            Image = recipe.Image,
            GlassType = new GlassTypeDTO
            {
                Id = recipe.GlassType.Id,
                Name = recipe.GlassType.Name
            },
            Ingredients = recipe.RecipeIngredients.Select(ri => new IngredientDTO
                {
                    Id = ri.Ingredient.Id,
                    Name = ri.Ingredient.Name,
                    IsAlcoholic = ri.Ingredient.IsAlcoholic
                })
                .ToList(),
            UserProfileId = recipe.UserProfileId,
            UserProfile = new UserProfileDTO
                {
                    Id = recipe.UserProfile.Id,
                    FirstName = recipe.UserProfile.FirstName,
                    LastName = recipe.UserProfile.LastName
                }
            // ImageUrl = recipe.ImageUrl
        };

        return Ok(recipeDTO);
    }

    [HttpGet("alcoholic")]
        public IActionResult GetAlcoholicIngredients()
        {
            List<Ingredient> alcoholicIngredients = _dbContext.Ingredients
                .Where(i => i.IsAlcoholic)
                .ToList();

            return Ok(alcoholicIngredients);
        }

     [HttpGet("non-alcoholic")]
        public IActionResult GetNonAlcoholicIngredients()
        {
            List<Ingredient> nonAlcoholicIngredients = _dbContext.Ingredients
                .Where(i => !i.IsAlcoholic)
                .ToList();

            return Ok(nonAlcoholicIngredients);
        }

    [HttpPost]
    public async Task<IActionResult> AddRecipe([FromForm] IFormFile image, [FromForm] CreateRecipeDTO newRecipeDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        
        CocktailRecipe newRecipe = new CocktailRecipe
        {
            Name = newRecipeDTO.Name,
            Description = newRecipeDTO.Description,
            Instructions = newRecipeDTO.Instructions,
            GlassTypeId = newRecipeDTO.GlassTypeId,
            UserProfileId = newRecipeDTO.UserProfileId
            
        };

        if (image != null && image.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "client", "public", "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                newRecipe.Image = $"/uploads/{image.FileName}";
            }

        _dbContext.CocktailRecipes.Add(newRecipe);
        _dbContext.SaveChanges();

        foreach (int Ingredient in newRecipeDTO.Ingredients)
        {
            if(newRecipeDTO.Ingredients == null || !newRecipeDTO.Ingredients.Any())
            {
                return BadRequest("At lease one ingredient is required");
            }

            
            RecipeIngredient recipeIngredient = new RecipeIngredient
            {
                CocktailRecipeId = newRecipe.Id,
                IngredientId = Ingredient
            };

            

            _dbContext.RecipeIngredients.Add(recipeIngredient);
            
        }

        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditRecipe(int id, [FromForm] IFormFile image, [FromForm] CreateRecipeDTO updatedRecipeDTO)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingRecipe = _dbContext.CocktailRecipes.Include(cr =>cr.RecipeIngredients).FirstOrDefault(cr => cr.Id == id);
        if (existingRecipe == null)
        {
            return NotFound("Recipe not found");
        }

        existingRecipe.Name = updatedRecipeDTO.Name;
        existingRecipe.Description = updatedRecipeDTO.Description;
        existingRecipe.Instructions = updatedRecipeDTO.Instructions;
        existingRecipe.GlassTypeId = updatedRecipeDTO.GlassTypeId;
        existingRecipe.UserProfileId = updatedRecipeDTO.UserProfileId;

        if (image != null && image.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "client", "public", "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                existingRecipe.Image = $"/uploads/{image.FileName}";
            }

        _dbContext.Entry(existingRecipe).State = EntityState.Modified;

        var existingIngredients = existingRecipe.RecipeIngredients.ToList();

        foreach (var ingredient in existingIngredients)
        {
            _dbContext.RecipeIngredients.Remove(ingredient);
        }

        foreach ( int IngredientId in updatedRecipeDTO.Ingredients)
        {
            if (updatedRecipeDTO.Ingredients == null || !updatedRecipeDTO.Ingredients.Any())
            {
                return BadRequest("At least one ingredient is required");
            }

            RecipeIngredient recipeIngredient = new RecipeIngredient
            {
                CocktailRecipeId = existingRecipe.Id,
                IngredientId = IngredientId,
            };

            _dbContext.RecipeIngredients.Add(recipeIngredient);
        }

           await _dbContext.SaveChangesAsync();

            return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete (int id)
    {
        CocktailRecipe deletedRecipe = _dbContext.CocktailRecipes.SingleOrDefault(cr => cr.Id == id);

        if(deletedRecipe == null)
        {
            return NotFound("Recipe not found");
        }

        _dbContext.CocktailRecipes.Remove(deletedRecipe);
        _dbContext.SaveChanges();
        return NoContent();
    }
}
