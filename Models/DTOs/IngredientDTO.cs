using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BoozeClues.Models;

public class IngredientDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsAlcoholic { get; set; }
    public string Quantity { get; set; }
}
