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
        public DateTime CreateDateTime { get; set; }
        public string FormattedDateTime
        {
            get { return CreateDateTime.Date.ToString("MM - dd - yyyy"); }
        }

        [Required]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [NotMapped]
        public List<string> Roles { get; set; }
        public string FullName
            {
                get
                {
                    return $"{FirstName} {LastName}";
                }
            }
    }
}
