using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoozeClues.Migrations
{
    /// <inheritdoc />
    public partial class addedimagecreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlassTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsAlcoholic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Instructions = table.Column<string>(type: "text", nullable: false),
                    GlassTypeId = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CocktailRecipes_GlassTypes_GlassTypeId",
                        column: x => x.GlassTypeId,
                        principalTable: "GlassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailRecipes_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailRecipeIngredient",
                columns: table => new
                {
                    CocktailRecipesId = table.Column<int>(type: "integer", nullable: false),
                    IngredientsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailRecipeIngredient", x => new { x.CocktailRecipesId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_CocktailRecipeIngredient_CocktailRecipes_CocktailRecipesId",
                        column: x => x.CocktailRecipesId,
                        principalTable: "CocktailRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailRecipeIngredient_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    CocktailRecipeId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.CocktailRecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_CocktailRecipes_CocktailRecipeId",
                        column: x => x.CocktailRecipeId,
                        principalTable: "CocktailRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9ce89d88-75da-4a80-9b0d-3fe58582b8e2", 0, "7332c7be-7197-4f07-97f0-b3c2473b2b21", "bob@williams.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMpozTLuFcaYAeiPzzhhCK3uVm/riSADxM0moMysuZY38Gshh2YJflN1cvAm2Vs66w==", null, false, "0129f906-d8f5-4729-b865-b2a7d8c19b4e", false, "BobWilliams" },
                    { "a7d21fac-3b21-454a-a747-075f072d0cf3", 0, "d1db2e58-2f10-4bb3-b326-b39bbe411bdd", "jane@smith.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEHsuejOJl3ZdY/UMQOQRIsc8QbGiGvcVrAZ7543eRcDUb/gLkEmiqPgrnMC3RSnT4A==", null, false, "ddbaa7cf-de52-4a44-8897-1d2acbc690a1", false, "JaneSmith" },
                    { "c806cfae-bda9-47c5-8473-dd52fd056a9b", 0, "4372cf40-8a56-491b-a7a5-3e4527e51670", "alice@johnson.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEGg/lpc+fk/ovVNdZhEaSjXce9oJkCcX5r3Raj3PRRqpvljunMEZT8PflTydjP0y6A==", null, false, "f5f42ade-6ef0-47d6-a070-aa495caf212a", false, "AliceJohnson" },
                    { "d224a03d-bf0c-4a05-b728-e3521e45d74d", 0, "51738b56-dc8c-4399-923d-1ea54d9f598d", "eve@davis.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEBqt43ekniyh5h6ZeATfyu2oSz2AxHe9kbX9j/ZsuSH581GBHXfEKr5wZQomgK0n1A==", null, false, "73ff80e4-9264-44fb-9d76-95cf27121ce4", false, "EveDavis" },
                    { "d8d76512-74f1-43bb-b1fd-87d3a8aa36df", 0, "78ed81d5-5c61-4e63-b6cd-37aa6d4519ea", "john@doe.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEAFS7N7yyNFCWLHGqA1nR/TrtSNAOV3KVWjKLkpcEs3Y1E3J7+oncTaLnbAJbYWfPQ==", null, false, "6a2d15b8-2f62-492a-bbdb-880af8052e51", false, "JohnDoe" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "605d20c7-d5b3-4c92-8598-0aca94f5005a", "admina@strator.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEJqHxJFYShUwETvxArbLhG2R9kkhvzHbuekfXB2O9iMCfgeHlH3Ynt/KvEvPuBzEfQ==", null, false, "83667d75-df59-48d7-9dd7-69078dd4d3ba", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "GlassTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Martini Glass" },
                    { 2, "Highball Glass" },
                    { 3, "Old Fashioned Glass" },
                    { 4, "Collins Glass" },
                    { 5, "Coupe Glass" },
                    { 6, "Wine Glass" },
                    { 7, "Champagne Flute" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IsAlcoholic", "Name" },
                values: new object[,]
                {
                    { 1, true, "Tequila" },
                    { 2, false, "Lime Juice" },
                    { 3, true, "Cointreau" },
                    { 4, true, "Bourbon" },
                    { 5, false, "Simple Syrup" },
                    { 6, true, "Vodka" },
                    { 7, true, "Gin" },
                    { 8, true, "Rum" },
                    { 9, true, "Triple Sec" },
                    { 10, false, "Orange Juice" },
                    { 11, false, "Cranberry Juice" },
                    { 12, false, "Pineapple Juice" },
                    { 13, false, "Ginger Beer" },
                    { 14, false, "Mint Leaves" },
                    { 15, true, "Bitters" },
                    { 16, false, "Soda Water" },
                    { 17, false, "Tonic Water" },
                    { 18, false, "Lemon Juice" },
                    { 19, true, "Maraschino Liqueur" },
                    { 20, true, "Peach Schnapps" },
                    { 21, false, "Grenadine" },
                    { 22, true, "Blue Curacao" },
                    { 23, true, "Amaretto" },
                    { 24, true, "Kahlua" },
                    { 25, false, "Coconut Cream" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "d8d76512-74f1-43bb-b1fd-87d3a8aa36df" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "FirstName", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator" },
                    { 2, "John", "d8d76512-74f1-43bb-b1fd-87d3a8aa36df", "Doe" },
                    { 3, "Jane", "a7d21fac-3b21-454a-a747-075f072d0cf3", "Smith" },
                    { 4, "Alice", "c806cfae-bda9-47c5-8473-dd52fd056a9b", "Johnson" },
                    { 5, "Bob", "9ce89d88-75da-4a80-9b0d-3fe58582b8e2", "Williams" },
                    { 6, "Eve", "d224a03d-bf0c-4a05-b728-e3521e45d74d", "Davis" }
                });

            migrationBuilder.InsertData(
                table: "CocktailRecipes",
                columns: new[] { "Id", "Description", "GlassTypeId", "Image", "Instructions", "Name", "UserProfileId" },
                values: new object[,]
                {
                    { 1, "A refreshing tequila-based cocktail with lime juice and Cointreau.", 1, "https://recipes.net/wp-content/uploads/2023/05/classic-margarita-recipe_780ef5cf753cf58502c26278fa094aa1.jpeg", "Shake all ingredients with ice, then strain into a chilled glass.", "Margarita", 1 },
                    { 2, "A classic cocktail made with bourbon, simple syrup, and bitters.", 3, "https://www.liquor.com/thmb/IgE3k1GbbNMWVCpmFI3-kKSx3eM=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/bourbon-old-fashioned-4000x4000-primary-ig-f0ce04bec6754db187ab1e8a16fd45c3.jpg", "Stir ingredients with ice, then strain into a glass over ice.", "Old Fashioned", 2 },
                    { 3, "A stylish cocktail featuring vodka, triple sec, lime juice, and cranberry juice.", 2, "https://toriavey.com/images/2011/03/The-Kosher-Cosmo-1.jpeg", "Shake all ingredients with ice, then strain into a chilled glass.", "Cosmopolitan", 3 },
                    { 4, "A minty and refreshing cocktail made with rum, lime juice, and soda water.", 1, "https://mixthatdrink.com/wp-content/uploads/2009/03/mojito-750x1126.jpg", "Muddle mint leaves with lime juice and sugar, then add rum and top up with soda water.", "Mojito", 4 },
                    { 5, "A tropical cocktail made with rum, coconut cream, and pineapple juice.", 1, "https://cookingwithcurls.com/wp-content/uploads/2015/04/Classic-Pi%C3%B1a-Colada-A-sweet-tropical-cocktail-made-with-rum-pineapple-juice-and-coconut-cream-cookingwithcurls.com_.jpg", "Blend all ingredients with ice until smooth, then serve in a chilled glass.", "Pina Colada", 5 },
                    { 6, "A classic cocktail made with gin and a touch of blue curacao.", 2, "https://www.liquor.com/thmb/uiVEGvb2jIR-Y_IyKZCIPrxrt-U=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vodka-martini-1500x1500-hero-080af5bb8ff04851a9c0ecf77a88a818.jpg", "Stir ingredients with ice, then strain into a chilled glass.", "Martini", 6 },
                    { 7, "A fruity cocktail made with rum, maraschino liqueur, peach schnapps, and lemon juice.", 4, "https://www.aberdeenskitchen.com/wp-content/uploads/2016/06/Tropical-Mai-Tai-Cocktail-4-680x1024.jpg", "Shake all ingredients with ice, then strain into a glass over ice.", "Mai Tai", 1 },
                    { 8, "A spicy and refreshing cocktail made with vodka, lime juice, and ginger beer.", 1, "https://www.thewinecellargroup.com/wp-content/uploads/2019/09/mule.jpg", "Combine ingredients in a glass with ice, then stir gently.", "Moscow Mule", 2 },
                    { 9, "A tangy cocktail made with bourbon, simple syrup, and lemon juice.", 3, "https://www.whisky-sour.com/images/16x9/whiskey-sour-16x9.jpg", "Shake all ingredients with ice, then strain into a glass over ice.", "Whiskey Sour", 3 },
                    { 10, "A sweet and sour cocktail made with rum, simple syrup, and lime juice.", 5, "https://d194ip2226q57d.cloudfront.net/images/daiquiri.original.png", "Shake all ingredients with ice, then strain into a chilled glass.", "Daiquiri", 4 },
                    { 11, "A colorful cocktail made with tequila, orange juice, and grenadine.", 1, "https://www.liquor.com/thmb/jjV_5roCvfnVgzYU89UROFguRpM=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/tequila-sunrise-1500x1500-hero-eeae10efeb134a3e9d5a3852b1b6e7dc.jpg", "Pour tequila and orange juice into a glass with ice, then drizzle grenadine on top.", "Tequila Sunrise", 5 },
                    { 12, "A strong cocktail made with vodka, gin, rum, triple sec, lime juice, and soda water.", 1, "https://robbreport.com/wp-content/uploads/2022/08/GettyImages_Long_Island_Iced_Tea.jpg?w=1000", "Shake all ingredients except soda water with ice, then strain into a glass and top up with soda water.", "Long Island Iced Tea", 6 },
                    { 13, "A savory cocktail made with vodka, tomato juice, and lemon juice.", 1, "https://vinepair.com/wp-content/uploads/2021/04/extraspicybloodymary_card.jpg", "Combine ingredients in a glass with ice, then stir gently.", "Bloody Mary", 1 },
                    { 14, "A bitter and balanced cocktail made with gin, blue curacao, and bitters.", 2, "https://www.liquor.com/thmb/zafM9xOaJsoNMu0SMRcFw_Fxv3w=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/kingston-negroni-720x720-primary1-ef87562fea8240de92dd09c36457a8c2.jpg", "Stir ingredients with ice, then strain into a glass over ice.", "Negroni", 2 },
                    { 15, "A vibrant cocktail made with vodka, blue curacao, and orange juice.", 2, "https://ik.imagekit.io/vjt1kualr/drinks/blue_lagoon/main-image.jpg", "Shake all ingredients with ice, then strain into a chilled glass.", "Blue Lagoon", 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "CocktailRecipeId", "IngredientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 15 },
                    { 3, 2 },
                    { 3, 6 },
                    { 3, 9 },
                    { 3, 11 },
                    { 4, 2 },
                    { 4, 5 },
                    { 4, 8 },
                    { 4, 14 },
                    { 4, 16 },
                    { 5, 8 },
                    { 5, 12 },
                    { 5, 25 },
                    { 6, 7 },
                    { 6, 22 },
                    { 7, 8 },
                    { 7, 18 },
                    { 7, 19 },
                    { 7, 20 },
                    { 8, 2 },
                    { 8, 6 },
                    { 8, 13 },
                    { 9, 4 },
                    { 9, 5 },
                    { 9, 18 },
                    { 10, 2 },
                    { 10, 5 },
                    { 10, 8 },
                    { 11, 1 },
                    { 11, 10 },
                    { 11, 21 },
                    { 12, 2 },
                    { 12, 6 },
                    { 12, 7 },
                    { 12, 8 },
                    { 12, 9 },
                    { 12, 16 },
                    { 13, 6 },
                    { 13, 10 },
                    { 13, 18 },
                    { 14, 7 },
                    { 14, 15 },
                    { 14, 22 },
                    { 15, 6 },
                    { 15, 10 },
                    { 15, 22 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CocktailRecipeIngredient_IngredientsId",
                table: "CocktailRecipeIngredient",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailRecipes_GlassTypeId",
                table: "CocktailRecipes",
                column: "GlassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailRecipes_UserProfileId",
                table: "CocktailRecipes",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CocktailRecipeIngredient");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CocktailRecipes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "GlassTypes");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
