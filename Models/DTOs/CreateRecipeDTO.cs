using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using BoozeClues.Models.DTOs;
using Microsoft.AspNetCore.Identity;
namespace BoozeClues.Models;

public class CreateRecipeDTO
{
    public int? Id { get; set; }
    
    public int UserProfileId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Instructions { get; set; }
    public int GlassTypeId { get; set; }

    public UserProfileDTO? UserProfile { get; set; }
    

    public GlassTypeDTO? GlassType { get; set; }
    // public string ImageUrl { get; set; }
    public List<int>? Ingredients { get; set; }
}
