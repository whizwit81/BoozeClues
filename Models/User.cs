
using Microsoft.AspNetCore.Identity;

namespace BoozeClues.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public List<Cocktail> Cocktails { get; set; }
}
