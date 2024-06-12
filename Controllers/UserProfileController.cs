using Microsoft.AspNetCore.Mvc;
using BoozeClues.Models;
using BoozeClues.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BoozeClues.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BoozeClues.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private BoozeCluesDbContext _dbContext;

    public UserProfileController(BoozeCluesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.UserProfiles.ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }));
    }

    [HttpPost("promote/{id}")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }


    //[Authorize]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        UserProfile user = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

        if (user == null)
        {
            return NotFound();
        }
        user.FirstName = user.FirstName;
        user.LastName = user.LastName;
        user.UserName = user.IdentityUser.UserName;
        user.Email = user.IdentityUser.Email;
    

        return Ok(user);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateUserProfile(int id, UserProfileDTO updatedProfile)
    {
        var userProfile = _dbContext.UserProfiles
            .Include(up => up.IdentityUser)
            .FirstOrDefault(up => up.Id == id);

        if (userProfile == null)
        {
            return NotFound("User profile not found.");
        }

        userProfile.IdentityUser.UserName = updatedProfile.UserName;
        userProfile.IdentityUser.Email = updatedProfile.Email;

        var existingRoles = _dbContext.UserRoles
            .Where(ur => ur.UserId == userProfile.IdentityUserId)
            .ToList();

        _dbContext.UserRoles.RemoveRange(existingRoles);

        foreach (var role in updatedProfile.Roles)
        {
            var roleEntity = _dbContext.Roles.SingleOrDefault(r => r.Name == role);
                    if (roleEntity != null)
            {
                _dbContext.UserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = userProfile.IdentityUserId,
                    RoleId = roleEntity.Id
                });
            }
        }

        try
        {
            _dbContext.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_dbContext.UserProfiles.Any(up => up.Id == id))
            {
                return NotFound("User profile not found.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

}

