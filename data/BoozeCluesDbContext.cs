using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using BoozeClues.Models;

namespace BoozeClues.Data
{
    public class BoozeCluesDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<CocktailRecipe> CocktailRecipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<GlassType> GlassTypes { get; set; }

        public BoozeCluesDbContext(DbContextOptions<BoozeCluesDbContext> options, IConfiguration config) : base(options)
        {
            _configuration = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite primary key for RecipeIngredient
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.CocktailRecipeId, ri.IngredientId });

            // Define primary keys for Identity entities
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(r => new { r.UserId, r.RoleId });

            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            // Seeding Roles
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Admin",
                NormalizedName = "admin"
            });

            // Seeding Users
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
            {
                new IdentityUser
                {
                    Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    UserName = "Administrator",
                    Email = "admina@strator.com",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                    UserName = "JohnDoe",
                    Email = "john@doe.com",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                    UserName = "JaneSmith",
                    Email = "jane@smith.com",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                    UserName = "AliceJohnson",
                    Email = "alice@johnson.com",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                    UserName = "BobWilliams",
                    Email = "bob@williams.com",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                    UserName = "EveDavis",
                    Email = "eve@davis.com",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
                },
            });

            // Seeding User Profiles
            modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
            {
                new UserProfile
                {
                    Id = 1,
                    IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    FirstName = "Admina",
                    LastName = "Strator",
                    UserName = "admina.strator",
                    Email = "admina@strator.com"
                },
                new UserProfile
                {
                    Id = 2,
                    IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "john.doe",
                    Email = "john@doe.com"
                },
                new UserProfile
                {
                    Id = 3,
                    IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                    FirstName = "Jane",
                    LastName = "Smith",
                    UserName = "jane.smith",
                    Email = "jane@smith.com"
                },
                new UserProfile
                {
                    Id = 4,
                    IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                    FirstName = "Alice",
                    LastName = "Johnson",
                    UserName = "alice.johnson",
                    Email = "alice@johnson.com"
                },
                new UserProfile
                {
                    Id = 5,
                    IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                    FirstName = "Bob",
                    LastName = "Williams",
                    UserName = "bob.williams",
                    Email = "bob@williams.com"
                },
                new UserProfile
                {
                    Id = 6,
                    IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                    FirstName = "Eve",
                    LastName = "Davis",
                    UserName = "eve.davis",
                    Email = "eve@davis.com"
                }
            });

            // Seeding Glass Types
            modelBuilder.Entity<GlassType>().HasData(
            
                new GlassType { Id = 1, Name = "Martini Glass" },
                new GlassType { Id = 2, Name = "Highball Glass" },
                new GlassType { Id = 3, Name = "Old Fashioned Glass" },
                new GlassType { Id = 4, Name = "Collins Glass" },
                new GlassType { Id = 5, Name = "Coupe Glass" },
                new GlassType { Id = 6, Name = "Wine Glass" },
                new GlassType { Id = 7, Name = "Champagne Flute" }
            );

                        // Seeding Ingredients
                modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tequila", IsAlcoholic = true },
                new Ingredient { Id = 2, Name = "Lime Juice", IsAlcoholic = false },
                new Ingredient { Id = 3, Name = "Cointreau", IsAlcoholic = true },
                new Ingredient { Id = 4, Name = "Bourbon", IsAlcoholic = true },
                new Ingredient { Id = 5, Name = "Simple Syrup", IsAlcoholic = false },
                new Ingredient { Id = 6, Name = "Vodka", IsAlcoholic = true },
                new Ingredient { Id = 7, Name = "Gin", IsAlcoholic = true },
                new Ingredient { Id = 8, Name = "Rum", IsAlcoholic = true },
                new Ingredient { Id = 9, Name = "Triple Sec", IsAlcoholic = true },
                new Ingredient { Id = 10, Name = "Orange Juice", IsAlcoholic = false },
                new Ingredient { Id = 11, Name = "Cranberry Juice", IsAlcoholic = false },
                new Ingredient { Id = 12, Name = "Pineapple Juice", IsAlcoholic = false },
                new Ingredient { Id = 13, Name = "Ginger Beer", IsAlcoholic = false },
                new Ingredient { Id = 14, Name = "Mint Leaves", IsAlcoholic = false },
                new Ingredient { Id = 15, Name = "Bitters", IsAlcoholic = true },
                new Ingredient { Id = 16, Name = "Soda Water", IsAlcoholic = false },
                new Ingredient { Id = 17, Name = "Tonic Water", IsAlcoholic = false },
                new Ingredient { Id = 18, Name = "Lemon Juice", IsAlcoholic = false },
                new Ingredient { Id = 19, Name = "Maraschino Liqueur", IsAlcoholic = true },
                new Ingredient { Id = 20, Name = "Peach Schnapps", IsAlcoholic = true },
                new Ingredient { Id = 21, Name = "Grenadine", IsAlcoholic = false },
                new Ingredient { Id = 22, Name = "Blue Curacao", IsAlcoholic = true },
                new Ingredient { Id = 23, Name = "Amaretto", IsAlcoholic = true },
                new Ingredient { Id = 24, Name = "Kahlua", IsAlcoholic = true },
                new Ingredient { Id = 25, Name = "Coconut Cream", IsAlcoholic = false }
            );


                modelBuilder.Entity<CocktailRecipe>().HasData(
                new CocktailRecipe { Id = 1, Name = "Margarita", Description = "A refreshing tequila-based cocktail with lime juice and Cointreau.", Instructions = "Shake all ingredients with ice, then strain into a chilled glass.", GlassTypeId = 1, UserProfileId = 1 },
                new CocktailRecipe { Id = 2, Name = "Old Fashioned", Description = "A classic cocktail made with bourbon, simple syrup, and bitters.", Instructions = "Stir ingredients with ice, then strain into a glass over ice.", GlassTypeId = 3, UserProfileId = 2 },
                new CocktailRecipe { Id = 3, Name = "Cosmopolitan", Description = "A stylish cocktail featuring vodka, triple sec, lime juice, and cranberry juice.", Instructions = "Shake all ingredients with ice, then strain into a chilled glass.", GlassTypeId = 2, UserProfileId = 3 },
                new CocktailRecipe { Id = 4, Name = "Mojito", Description = "A minty and refreshing cocktail made with rum, lime juice, and soda water.", Instructions = "Muddle mint leaves with lime juice and sugar, then add rum and top up with soda water.", GlassTypeId = 1, UserProfileId = 4 },
                new CocktailRecipe { Id = 5, Name = "Pina Colada", Description = "A tropical cocktail made with rum, coconut cream, and pineapple juice.", Instructions = "Blend all ingredients with ice until smooth, then serve in a chilled glass.", GlassTypeId = 1, UserProfileId = 5 },
                new CocktailRecipe { Id = 6, Name = "Martini", Description = "A classic cocktail made with gin and a touch of blue curacao.", Instructions = "Stir ingredients with ice, then strain into a chilled glass.", GlassTypeId = 2, UserProfileId = 6 },
                new CocktailRecipe { Id = 7, Name = "Mai Tai", Description = "A fruity cocktail made with rum, maraschino liqueur, peach schnapps, and lemon juice.", Instructions = "Shake all ingredients with ice, then strain into a glass over ice.", GlassTypeId = 4, UserProfileId = 1 },
                new CocktailRecipe { Id = 8, Name = "Moscow Mule", Description = "A spicy and refreshing cocktail made with vodka, lime juice, and ginger beer.", Instructions = "Combine ingredients in a glass with ice, then stir gently.", GlassTypeId = 1, UserProfileId = 2 },
                new CocktailRecipe { Id = 9, Name = "Whiskey Sour", Description = "A tangy cocktail made with bourbon, simple syrup, and lemon juice.", Instructions = "Shake all ingredients with ice, then strain into a glass over ice.", GlassTypeId = 3, UserProfileId = 3 },
                new CocktailRecipe { Id = 10, Name = "Daiquiri", Description = "A sweet and sour cocktail made with rum, simple syrup, and lime juice.", Instructions = "Shake all ingredients with ice, then strain into a chilled glass.", GlassTypeId = 5, UserProfileId = 4 },
                new CocktailRecipe { Id = 11, Name = "Tequila Sunrise", Description = "A colorful cocktail made with tequila, orange juice, and grenadine.", Instructions = "Pour tequila and orange juice into a glass with ice, then drizzle grenadine on top.", GlassTypeId = 1, UserProfileId = 5 },
                new CocktailRecipe { Id = 12, Name = "Long Island Iced Tea", Description = "A strong cocktail made with vodka, gin, rum, triple sec, lime juice, and soda water.", Instructions = "Shake all ingredients except soda water with ice, then strain into a glass and top up with soda water.", GlassTypeId = 1, UserProfileId = 6 },
                new CocktailRecipe { Id = 13, Name = "Bloody Mary", Description = "A savory cocktail made with vodka, tomato juice, and lemon juice.", Instructions = "Combine ingredients in a glass with ice, then stir gently.", GlassTypeId = 1, UserProfileId = 1 },
                new CocktailRecipe { Id = 14, Name = "Negroni", Description = "A bitter and balanced cocktail made with gin, blue curacao, and bitters.", Instructions = "Stir ingredients with ice, then strain into a glass over ice.", GlassTypeId = 2, UserProfileId = 2 },
                new CocktailRecipe { Id = 15, Name = "Blue Lagoon", Description = "A vibrant cocktail made with vodka, blue curacao, and orange juice.", Instructions = "Shake all ingredients with ice, then strain into a chilled glass.", GlassTypeId = 2, UserProfileId = 3 }
            );





                        modelBuilder.Entity<RecipeIngredient>().HasData(
                // Margarita
                new RecipeIngredient { CocktailRecipeId = 1, IngredientId = 1, Quantity = "2 oz" },
                new RecipeIngredient { CocktailRecipeId = 1, IngredientId = 2, Quantity = "1 oz" },
                new RecipeIngredient { CocktailRecipeId = 1, IngredientId = 3, Quantity = "1 oz" },

                // Old Fashioned
                new RecipeIngredient { CocktailRecipeId = 2, IngredientId = 4, Quantity = "2 oz" },
                new RecipeIngredient { CocktailRecipeId = 2, IngredientId = 5, Quantity = "0.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 2, IngredientId = 15, Quantity = "2 dashes" },

                // Cosmopolitan
                new RecipeIngredient { CocktailRecipeId = 3, IngredientId = 6, Quantity = "1.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 3, IngredientId = 9, Quantity = "1 oz" },
                new RecipeIngredient { CocktailRecipeId = 3, IngredientId = 2, Quantity = "0.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 3, IngredientId = 11, Quantity = "0.5 oz" },

                // Mojito
                new RecipeIngredient { CocktailRecipeId = 4, IngredientId = 8, Quantity = "1.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 4, IngredientId = 5, Quantity = "1 oz" },
                new RecipeIngredient { CocktailRecipeId = 4, IngredientId = 2, Quantity = "1 oz" },
                new RecipeIngredient { CocktailRecipeId = 4, IngredientId = 14, Quantity = "10 leaves" },
                new RecipeIngredient { CocktailRecipeId = 4, IngredientId = 16, Quantity = "Top up" },

                // Pina Colada
                new RecipeIngredient { CocktailRecipeId = 5, IngredientId = 8, Quantity = "2 oz" },
                new RecipeIngredient { CocktailRecipeId = 5, IngredientId = 25, Quantity = "1 oz" },
                new RecipeIngredient { CocktailRecipeId = 5, IngredientId = 12, Quantity = "1 oz" },

                // Martini
                new RecipeIngredient { CocktailRecipeId = 6, IngredientId = 7, Quantity = "2 oz" },
                new RecipeIngredient { CocktailRecipeId = 6, IngredientId = 22, Quantity = "0.5 oz" },

                // Mai Tai
                new RecipeIngredient { CocktailRecipeId = 7, IngredientId = 8, Quantity = "1 oz" },
                new RecipeIngredient { CocktailRecipeId = 7, IngredientId = 19, Quantity = "0.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 7, IngredientId = 20, Quantity = "0.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 7, IngredientId = 18, Quantity = "0.5 oz" },

                // Moscow Mule
                new RecipeIngredient { CocktailRecipeId = 8, IngredientId = 6, Quantity = "2 oz" },
                new RecipeIngredient { CocktailRecipeId = 8, IngredientId = 2, Quantity = "0.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 8, IngredientId = 13, Quantity = "Top up" },

                // Whiskey Sour
                new RecipeIngredient { CocktailRecipeId = 9, IngredientId = 4, Quantity = "2 oz" },
                new RecipeIngredient { CocktailRecipeId = 9, IngredientId = 5, Quantity = "0.75 oz" },
                new RecipeIngredient { CocktailRecipeId = 9, IngredientId = 18, Quantity = "0.75 oz" },

                // Daiquiri
                new RecipeIngredient { CocktailRecipeId = 10, IngredientId = 8, Quantity = "2 oz" },
                new RecipeIngredient { CocktailRecipeId = 10, IngredientId = 5, Quantity = "0.75 oz" },
                new RecipeIngredient { CocktailRecipeId = 10, IngredientId = 2, Quantity = "0.75 oz" },

                // Tequila Sunrise
                new RecipeIngredient { CocktailRecipeId = 11, IngredientId = 1, Quantity = "2 oz" },
                new RecipeIngredient { CocktailRecipeId = 11, IngredientId = 10, Quantity = "4 oz" },
                new RecipeIngredient { CocktailRecipeId = 11, IngredientId = 21, Quantity = "0.5 oz" },

                // Long Island Iced Tea
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 6, Quantity = "0.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 7, Quantity = "0.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 8, Quantity = "0.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 9, Quantity = "0.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 2, Quantity = "0.75 oz" },
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 16, Quantity = "Top up" },

                // Bloody Mary
                new RecipeIngredient { CocktailRecipeId = 13, IngredientId = 6, Quantity = "2 oz" },
                new RecipeIngredient { CocktailRecipeId = 13, IngredientId = 10, Quantity = "4 oz" },
                new RecipeIngredient { CocktailRecipeId = 13, IngredientId = 18, Quantity = "0.5 oz" },

                // Negroni
                new RecipeIngredient { CocktailRecipeId = 14, IngredientId = 7, Quantity = "1 oz" },
                new RecipeIngredient { CocktailRecipeId = 14, IngredientId = 22, Quantity = "1 oz" },
                new RecipeIngredient { CocktailRecipeId = 14, IngredientId = 15, Quantity = "1 oz" },

                // Blue Lagoon
                new RecipeIngredient { CocktailRecipeId = 15, IngredientId = 6, Quantity = "1.5 oz" },
                new RecipeIngredient { CocktailRecipeId = 15, IngredientId = 22, Quantity = "1 oz" },
                new RecipeIngredient { CocktailRecipeId = 15, IngredientId = 10, Quantity = "Top up" }
            );

        }
    }
}
