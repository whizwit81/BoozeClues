using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoozeClues.Models;
using BoozeClues.Models.DTOs;
using BoozeClues.Data;
using System.Linq;

namespace BoozeClues.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GlassTypeController : ControllerBase
{
    private readonly BoozeCluesDbContext _dbContext;

    public GlassTypeController(BoozeCluesDbContext context)
        {
            _dbContext = context;
        }

[HttpGet]
public IActionResult GetGlassTypes()
{
    List<GlassTypeDTO> glassTypes = _dbContext.GlassTypes
        .Select(gt => new GlassTypeDTO
            {
                Id = gt.Id,
                Name = gt.Name
            }).ToList();

            return Ok(glassTypes);
        }
    }

