using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BoozeClues.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        // [Required]
        [NotMapped]
        public string UserName { get; set; }

        // [Required]
        [NotMapped]
        public string Email { get; set; }

        [Required]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public List<CocktailRecipe> CocktailRecipes { get; set; }

        public string FullName
            {
                get
                {
                    return $"{FirstName} {LastName}";
                }
            }
    }
}
