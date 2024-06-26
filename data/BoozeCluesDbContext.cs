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

            // // Seeding Roles
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
    new CocktailRecipe { Id = 1, Name = "Margarita", Description = "A refreshing tequila-based cocktail with lime juice and Cointreau.", Instructions = "Shake all ingredients with ice, then strain into a chilled glass.", GlassTypeId = 1, UserProfileId = 1, Image="https://recipes.net/wp-content/uploads/2023/05/classic-margarita-recipe_780ef5cf753cf58502c26278fa094aa1.jpeg"},
    new CocktailRecipe { Id = 2, Name = "Old Fashioned", Description = "A classic cocktail made with bourbon, simple syrup, and bitters.", Instructions = "Stir ingredients with ice, then strain into a glass over ice.", GlassTypeId = 3, UserProfileId = 2, Image="https://www.liquor.com/thmb/IgE3k1GbbNMWVCpmFI3-kKSx3eM=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/bourbon-old-fashioned-4000x4000-primary-ig-f0ce04bec6754db187ab1e8a16fd45c3.jpg"},
    new CocktailRecipe { Id = 3, Name = "Cosmopolitan", Description = "A stylish cocktail featuring vodka, triple sec, lime juice, and cranberry juice.", Instructions = "Shake all ingredients with ice, then strain into a chilled glass.", GlassTypeId = 2, UserProfileId = 3, Image="https://toriavey.com/images/2011/03/The-Kosher-Cosmo-1.jpeg"},
    new CocktailRecipe { Id = 4, Name = "Mojito", Description = "A minty and refreshing cocktail made with rum, lime juice, and soda water.", Instructions = "Muddle mint leaves with lime juice and sugar, then add rum and top up with soda water.", GlassTypeId = 1, UserProfileId = 4, Image="https://mixthatdrink.com/wp-content/uploads/2009/03/mojito-750x1126.jpg"},
    new CocktailRecipe { Id = 5, Name = "Pina Colada", Description = "A tropical cocktail made with rum, coconut cream, and pineapple juice.", Instructions = "Blend all ingredients with ice until smooth, then serve in a chilled glass.", GlassTypeId = 1, UserProfileId = 5, Image="https://cookingwithcurls.com/wp-content/uploads/2015/04/Classic-Pi%C3%B1a-Colada-A-sweet-tropical-cocktail-made-with-rum-pineapple-juice-and-coconut-cream-cookingwithcurls.com_.jpg"},
    new CocktailRecipe { Id = 6, Name = "Martini", Description = "A classic cocktail made with gin and a touch of blue curacao.", Instructions = "Stir ingredients with ice, then strain into a chilled glass.", GlassTypeId = 2, UserProfileId = 6, Image="https://www.liquor.com/thmb/uiVEGvb2jIR-Y_IyKZCIPrxrt-U=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vodka-martini-1500x1500-hero-080af5bb8ff04851a9c0ecf77a88a818.jpg"},
    new CocktailRecipe { Id = 7, Name = "Mai Tai", Description = "A fruity cocktail made with rum, maraschino liqueur, peach schnapps, and lemon juice.", Instructions = "Shake all ingredients with ice, then strain into a glass over ice.", GlassTypeId = 4, UserProfileId = 1, Image="https://www.aberdeenskitchen.com/wp-content/uploads/2016/06/Tropical-Mai-Tai-Cocktail-4-680x1024.jpg"},
    new CocktailRecipe { Id = 8, Name = "Moscow Mule", Description = "A spicy and refreshing cocktail made with vodka, lime juice, and ginger beer.", Instructions = "Combine ingredients in a glass with ice, then stir gently.", GlassTypeId = 1, UserProfileId = 2, Image="https://www.thewinecellargroup.com/wp-content/uploads/2019/09/mule.jpg"},
    new CocktailRecipe { Id = 9, Name = "Whiskey Sour", Description = "A tangy cocktail made with bourbon, simple syrup, and lemon juice.", Instructions = "Shake all ingredients with ice, then strain into a glass over ice.", GlassTypeId = 3, UserProfileId = 3, Image="https://www.whisky-sour.com/images/16x9/whiskey-sour-16x9.jpg"},
    new CocktailRecipe { Id = 10, Name = "Daiquiri", Description = "A sweet and sour cocktail made with rum, simple syrup, and lime juice.", Instructions = "Shake all ingredients with ice, then strain into a chilled glass.", GlassTypeId = 5, UserProfileId = 4, Image="https://d194ip2226q57d.cloudfront.net/images/daiquiri.original.png"},
    new CocktailRecipe { Id = 11, Name = "Tequila Sunrise", Description = "A colorful cocktail made with tequila, orange juice, and grenadine.", Instructions = "Pour tequila and orange juice into a glass with ice, then drizzle grenadine on top.", GlassTypeId = 1, UserProfileId = 5, Image="https://www.liquor.com/thmb/jjV_5roCvfnVgzYU89UROFguRpM=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/tequila-sunrise-1500x1500-hero-eeae10efeb134a3e9d5a3852b1b6e7dc.jpg"},
    new CocktailRecipe { Id = 12, Name = "Long Island Iced Tea", Description = "A strong cocktail made with vodka, gin, rum, triple sec, lime juice, and soda water.", Instructions = "Shake all ingredients except soda water with ice, then strain into a glass and top up with soda water.", GlassTypeId = 1, UserProfileId = 6, Image="https://robbreport.com/wp-content/uploads/2022/08/GettyImages_Long_Island_Iced_Tea.jpg?w=1000"},
    new CocktailRecipe { Id = 13, Name = "Bloody Mary", Description = "A savory cocktail made with vodka, tomato juice, and lemon juice.", Instructions = "Combine ingredients in a glass with ice, then stir gently.", GlassTypeId = 1, UserProfileId = 1, Image="https://vinepair.com/wp-content/uploads/2021/04/extraspicybloodymary_card.jpg"},
    new CocktailRecipe { Id = 14, Name = "Negroni", Description = "A bitter and balanced cocktail made with gin, blue curacao, and bitters.", Instructions = "Stir ingredients with ice, then strain into a glass over ice.", GlassTypeId = 2, UserProfileId = 2, Image="https://www.liquor.com/thmb/zafM9xOaJsoNMu0SMRcFw_Fxv3w=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/kingston-negroni-720x720-primary1-ef87562fea8240de92dd09c36457a8c2.jpg"},
    new CocktailRecipe { Id = 15, Name = "Blue Lagoon", Description = "A vibrant cocktail made with vodka, blue curacao, and orange juice.", Instructions = "Shake all ingredients with ice, then strain into a chilled glass.", GlassTypeId = 2, UserProfileId = 3, Image="https://ik.imagekit.io/vjt1kualr/drinks/blue_lagoon/main-image.jpg"}
);






                        modelBuilder.Entity<RecipeIngredient>().HasData(
                // Margarita
                new RecipeIngredient { CocktailRecipeId = 1, IngredientId = 1},
                new RecipeIngredient { CocktailRecipeId = 1, IngredientId = 2},
                new RecipeIngredient { CocktailRecipeId = 1, IngredientId = 3},

                // Old Fashioned
                new RecipeIngredient { CocktailRecipeId = 2, IngredientId = 4},
                new RecipeIngredient { CocktailRecipeId = 2, IngredientId = 5},
                new RecipeIngredient { CocktailRecipeId = 2, IngredientId = 15},

                // Cosmopolitan
                new RecipeIngredient { CocktailRecipeId = 3, IngredientId = 6},
                new RecipeIngredient { CocktailRecipeId = 3, IngredientId = 9},
                new RecipeIngredient { CocktailRecipeId = 3, IngredientId = 2},
                new RecipeIngredient { CocktailRecipeId = 3, IngredientId = 11},

                // Mojito
                new RecipeIngredient { CocktailRecipeId = 4, IngredientId = 8},
                new RecipeIngredient { CocktailRecipeId = 4, IngredientId = 5},
                new RecipeIngredient { CocktailRecipeId = 4, IngredientId = 2},
                new RecipeIngredient { CocktailRecipeId = 4, IngredientId = 14},
                new RecipeIngredient { CocktailRecipeId = 4, IngredientId = 16},

                // Pina Colada
                new RecipeIngredient { CocktailRecipeId = 5, IngredientId = 8},
                new RecipeIngredient { CocktailRecipeId = 5, IngredientId = 25},
                new RecipeIngredient { CocktailRecipeId = 5, IngredientId = 12},

                // Martini
                new RecipeIngredient { CocktailRecipeId = 6, IngredientId = 7},
                new RecipeIngredient { CocktailRecipeId = 6, IngredientId = 22},

                // Mai Tai
                new RecipeIngredient { CocktailRecipeId = 7, IngredientId = 8},
                new RecipeIngredient { CocktailRecipeId = 7, IngredientId = 19},
                new RecipeIngredient { CocktailRecipeId = 7, IngredientId = 20},
                new RecipeIngredient { CocktailRecipeId = 7, IngredientId = 18},

                // Moscow Mule
                new RecipeIngredient { CocktailRecipeId = 8, IngredientId = 6},
                new RecipeIngredient { CocktailRecipeId = 8, IngredientId = 2},
                new RecipeIngredient { CocktailRecipeId = 8, IngredientId = 13},

                // Whiskey Sour
                new RecipeIngredient { CocktailRecipeId = 9, IngredientId = 4,},
                new RecipeIngredient { CocktailRecipeId = 9, IngredientId = 5},
                new RecipeIngredient { CocktailRecipeId = 9, IngredientId = 18},

                // Daiquiri
                new RecipeIngredient { CocktailRecipeId = 10, IngredientId = 8,},
                new RecipeIngredient { CocktailRecipeId = 10, IngredientId = 5},
                new RecipeIngredient { CocktailRecipeId = 10, IngredientId = 2},

                // Tequila Sunrise
                new RecipeIngredient { CocktailRecipeId = 11, IngredientId = 1,},
                new RecipeIngredient { CocktailRecipeId = 11, IngredientId = 10},
                new RecipeIngredient { CocktailRecipeId = 11, IngredientId = 21},

                // Long Island Iced Tea
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 6},
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 7},
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 8},
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 9},
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 2},
                new RecipeIngredient { CocktailRecipeId = 12, IngredientId = 16},

                // Bloody Mary
                new RecipeIngredient { CocktailRecipeId = 13, IngredientId = 6,},
                new RecipeIngredient { CocktailRecipeId = 13, IngredientId = 10},
                new RecipeIngredient { CocktailRecipeId = 13, IngredientId = 18},

                // Negroni
                new RecipeIngredient { CocktailRecipeId = 14, IngredientId = 7},
                new RecipeIngredient { CocktailRecipeId = 14, IngredientId = 22},
                new RecipeIngredient { CocktailRecipeId = 14, IngredientId = 15},

                // Blue Lagoon
                new RecipeIngredient { CocktailRecipeId = 15, IngredientId = 6},
                new RecipeIngredient { CocktailRecipeId = 15, IngredientId = 22},
                new RecipeIngredient { CocktailRecipeId = 15, IngredientId = 10}
            );

        }
    }
}
