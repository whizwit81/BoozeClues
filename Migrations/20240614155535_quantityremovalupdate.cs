﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoozeClues.Migrations
{
    /// <inheritdoc />
    public partial class quantityremovalupdate : Migration
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
                    GlassTypeId = table.Column<int>(type: "integer", nullable: false)
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
                    { "9ce89d88-75da-4a80-9b0d-3fe58582b8e2", 0, "c0de4f48-9774-4b4b-a966-c49fae333334", "bob@williams.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMGr4AKYtU5wRoegu8/aZUshN7QCRpy1ZdKzbd0a0Vnh4CXLzRl7XLBEmLPP57RzmQ==", null, false, "9f5a4b54-f913-43ec-8a00-768558cbf9ff", false, "BobWilliams" },
                    { "a7d21fac-3b21-454a-a747-075f072d0cf3", 0, "b8771d5d-3bc6-4afd-942f-60b8fb6d0940", "jane@smith.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEImffq9rXTq1/0UtSzFRGH0s8aZYAdYvBAhVRvqlhF179fZ/wRiQHiyzZCOszuSFJA==", null, false, "bfc5523f-8982-4602-91b5-39f4f12746dc", false, "JaneSmith" },
                    { "c806cfae-bda9-47c5-8473-dd52fd056a9b", 0, "d618ef86-e8ee-45eb-98e6-97e29f126dee", "alice@johnson.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEIRtVqHsk1RmP3H8G5keRaXUXtnQR0NRCKtxFho00eIFfmtvYBjiYebu/cFv9MOmXw==", null, false, "d6efcd01-d1cd-43d1-bd98-52323ee5186a", false, "AliceJohnson" },
                    { "d224a03d-bf0c-4a05-b728-e3521e45d74d", 0, "3ba80660-af06-4090-a420-afff7dc65a7c", "eve@davis.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEFb610aysyFXaRl6TTkYuopYp0eP2V5PEqEalfwu/RqDbCdD3nWGbk3DZu7MsiEEAA==", null, false, "ee989eb1-1626-429c-91ef-4bef5a5a7666", false, "EveDavis" },
                    { "d8d76512-74f1-43bb-b1fd-87d3a8aa36df", 0, "9f6ea1a9-b0e2-4d51-9c93-5c65f7815a3e", "john@doe.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEOTtgrD7hCS8pyA/N++tUKPkBV2Xyqq9YokWcB524u3AZwBcGNmh5N89UnYmmYrNnQ==", null, false, "ccc63b16-3195-447a-b9c1-fa4ec41ab2ff", false, "JohnDoe" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "0249953c-d42a-4567-a839-cda3fdd66d78", "admina@strator.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEOdOyAo1E6wQ/r389lwLM1yy+A+APdy1ksL+je2Jp3Px6XErVj1ycRcMcICdRoSnlQ==", null, false, "b97c33fe-ebde-4a50-a25e-01922177087d", false, "Administrator" }
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
                columns: new[] { "Id", "Description", "GlassTypeId", "Instructions", "Name", "UserProfileId" },
                values: new object[,]
                {
                    { 1, "A refreshing tequila-based cocktail with lime juice and Cointreau.", 1, "Shake all ingredients with ice, then strain into a chilled glass.", "Margarita", 1 },
                    { 2, "A classic cocktail made with bourbon, simple syrup, and bitters.", 3, "Stir ingredients with ice, then strain into a glass over ice.", "Old Fashioned", 2 },
                    { 3, "A stylish cocktail featuring vodka, triple sec, lime juice, and cranberry juice.", 2, "Shake all ingredients with ice, then strain into a chilled glass.", "Cosmopolitan", 3 },
                    { 4, "A minty and refreshing cocktail made with rum, lime juice, and soda water.", 1, "Muddle mint leaves with lime juice and sugar, then add rum and top up with soda water.", "Mojito", 4 },
                    { 5, "A tropical cocktail made with rum, coconut cream, and pineapple juice.", 1, "Blend all ingredients with ice until smooth, then serve in a chilled glass.", "Pina Colada", 5 },
                    { 6, "A classic cocktail made with gin and a touch of blue curacao.", 2, "Stir ingredients with ice, then strain into a chilled glass.", "Martini", 6 },
                    { 7, "A fruity cocktail made with rum, maraschino liqueur, peach schnapps, and lemon juice.", 4, "Shake all ingredients with ice, then strain into a glass over ice.", "Mai Tai", 1 },
                    { 8, "A spicy and refreshing cocktail made with vodka, lime juice, and ginger beer.", 1, "Combine ingredients in a glass with ice, then stir gently.", "Moscow Mule", 2 },
                    { 9, "A tangy cocktail made with bourbon, simple syrup, and lemon juice.", 3, "Shake all ingredients with ice, then strain into a glass over ice.", "Whiskey Sour", 3 },
                    { 10, "A sweet and sour cocktail made with rum, simple syrup, and lime juice.", 5, "Shake all ingredients with ice, then strain into a chilled glass.", "Daiquiri", 4 },
                    { 11, "A colorful cocktail made with tequila, orange juice, and grenadine.", 1, "Pour tequila and orange juice into a glass with ice, then drizzle grenadine on top.", "Tequila Sunrise", 5 },
                    { 12, "A strong cocktail made with vodka, gin, rum, triple sec, lime juice, and soda water.", 1, "Shake all ingredients except soda water with ice, then strain into a glass and top up with soda water.", "Long Island Iced Tea", 6 },
                    { 13, "A savory cocktail made with vodka, tomato juice, and lemon juice.", 1, "Combine ingredients in a glass with ice, then stir gently.", "Bloody Mary", 1 },
                    { 14, "A bitter and balanced cocktail made with gin, blue curacao, and bitters.", 2, "Stir ingredients with ice, then strain into a glass over ice.", "Negroni", 2 },
                    { 15, "A vibrant cocktail made with vodka, blue curacao, and orange juice.", 2, "Shake all ingredients with ice, then strain into a chilled glass.", "Blue Lagoon", 3 }
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