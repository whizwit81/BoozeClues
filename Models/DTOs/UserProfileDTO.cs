using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace BoozeClues.Models.DTOs
{
    public class UserProfileDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImageLocation { get; set; }
        public string IdentityUserId { get; set; }

        public IdentityUser IdentityUser {get; set;}
        public bool IsActive { get; set; }

        public List<string> Roles {get; set;}
    }
}
