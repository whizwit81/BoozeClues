using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoozeClues.Migrations
{
    /// <inheritdoc />
    public partial class ImageUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "CocktailRecipes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78902105-c71e-4b2f-b94c-91f0baf80064", "AQAAAAIAAYagAAAAEPdYT8+YzAeqvZUkQ2jD0nRPjM9Cy6QM1YJWVM7G+F8RWxHUOtUn6jdLsNWIPdoeJw==", "3f3c67c1-8911-426c-956b-ea7cee2af1a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7d21fac-3b21-454a-a747-075f072d0cf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e079a45d-e621-46df-bea6-3745accd912c", "AQAAAAIAAYagAAAAEKdZ6UfQjjMoDvtricTjk0dJE2cMPcLPJaXthQWrLFwDsTe9cvOcfuCvSnHLZR0cTg==", "626df5a8-0f34-4763-9f55-10522113ac61" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6af0e8db-240c-470f-9127-a9352133fa88", "AQAAAAIAAYagAAAAEIolDPEneYkP9wuOSk7ZWb4tJdo2bXzqTa+UcHcqf24UsTI5hX8QppbF0sKAJG+e5Q==", "19b25447-35de-44ab-af19-50742795f7e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b705e47-e96c-4056-89d6-2572554605ce", "AQAAAAIAAYagAAAAEMokMXBwgeSXucWJrsNAk0b0zBPHJwK2i/7JTEJ1R1n/GLxAiCRVUBtKFyx3d13cpA==", "dbc2e1f1-b048-4a4a-8ef3-bcddd757033a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a80ed860-c7c4-4e09-b22f-eec1adf4a992", "AQAAAAIAAYagAAAAEOJ3rpbbAuUAEBYl3sWBJZYcNysboHADTB27k0+lGtAv4HDwgjnKw1lg2qxijy1PhQ==", "fb93ef58-3cf8-4852-9791-66517a796b0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffdbf7a7-97e3-4b41-8ebb-20f3a249edbb", "AQAAAAIAAYagAAAAEDBTkUMMuu4ugYcxKu7CoIiu+ZJIyHrWSUPQLlLvFr8jIoWf+5qAvK019cO5M8pejw==", "e6a5388c-bd84-4878-ae7d-858b4a117a6c" });

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.allrecipes.com/thmb/Bw1ugPXhDyxWjhZBoplUSe2TJ_A=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/32501-margaritas-on-the-rocks-DDMFS-beauty-4x3-BG-3070-ba9ff637b745426ab1b6c4289260fdad.jpg");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.knobcreek.com/sites/default/files/2018-06/thumb__0010_8909_KC_Classic_Old_Fashioned-4474.webp");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://dailyappetite.com/wp-content/uploads/2017/05/The-perfect-Cosmo-Cocktail.jpg");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://www.bhg.com/thmb/Bew5wgRNxDE0blM6BuQUr9UND0c=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/diy-mojito-RU186788-1-b3184133555544bbae783b67881d1400.jpg");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.onceuponachef.com/images/2023/07/pina-coladas-760x1013.jpg");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/dirty-martini-3e964eb.jpg?quality=90&webp=true&resize=300,272");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://punchdrink.com/wp-content/uploads/2023/04/Article-Bitter-Mai-Tai-Campari-Tiki-Cocktail-Recipe-800x450.jpg");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://www.foodandwine.com/thmb/a45tAqLW3OQQc86fBjdHioFSKa4=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/moscow-mule-FT-RECIPE0521-6bb69ade441546c1b1210b4e55dbcb23.jpg");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "path_to_image/WhiskeySour.png");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "path_to_image/Daiquiri.png");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://images.immediate.co.uk/production/volatile/sites/30/2018/04/tequila-sunrise-18167a1.jpg?quality=90&webp=true&resize=300,272");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://tequilapop.dk/wp-content/uploads/elementor/thumbs/long_island_iced_tea-q5alwkgi5hjzhgxhlnq1wixy0xntl4qdu2ng5r4kcw.jpg");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/bloody-mary-a2983ba.jpg?quality=90&webp=true&resize=300,272");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://www.liquor.com/thmb/ir1aDhuMlSbSMc8N9qpWEgX4_NU=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/mezcal-negroni-1500x1500-primary-6f6c472050a949c8a55aa07e1b5a2d1b.jpg");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://kitchengeekery.com/wp-content/webpc-passthru.php?src=https://kitchengeekery.com/wp-content/uploads/2021/01/blue-lagoon-cocktail-300x240.jpg&nocache=1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "CocktailRecipes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b67e1277-2d21-4ec0-adcb-22461d0fe5e4", "AQAAAAIAAYagAAAAEP86o5WLAUw8TgkuXcbVEVJYHjtBJCJNudDsM4owWc7GYrBwHtuWjtjID/EpIlBYDA==", "75d83b2d-29d2-4581-b89e-6f4c97c2c6cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7d21fac-3b21-454a-a747-075f072d0cf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3f5f1aa-de1d-4735-a52b-5b6e4a0883c5", "AQAAAAIAAYagAAAAEFdjOOyUSqCKAx29eJ0aaE2vs4VlWPyAjxiPDq8KQ8Cb4e7eE8elHUyr1s9sO3TMhA==", "afafc10a-8354-4b9c-85b2-7acb449ddbb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f58f485-4c53-4725-8b7a-01cd5179418e", "AQAAAAIAAYagAAAAEPG4YZ+XzIJaVQ89g6rkO7RBvFJUnPbQ7OgaPoDlgDt2uQoKdFFNj21iYtz0M/yi9w==", "e75428fb-f7cc-4b86-aa91-cbb7f4d46ef0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01b43e67-ea9d-4438-946d-bf756787af85", "AQAAAAIAAYagAAAAEMnCHE3faQyMrf76DblgaudrrGaOvPeeLFr7GNJAjRTH6RJd0xpXF9geQUJbndDmHg==", "cc094c02-2acd-4a96-b039-2fe2cf65bb11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b1806cb-ebd2-4f3e-a48b-acb312ec1140", "AQAAAAIAAYagAAAAEEdiRPrzrUkbwPJAKIbqOOctAwzuJUb+jiqlDru92/cPakhhjfkeDx5UjhjfPXVh5w==", "81064076-ba9f-404d-92ab-a72f36d0ec33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a71df32-87b8-46a4-be6a-292225bab070", "AQAAAAIAAYagAAAAENYa5gpBAag587EWHukfaoxU8X4DzPWCKWwKDfN9kV71nkzsPgHqNW05b3ChDFw87w==", "62898137-4241-4fa7-b6a4-04f46547be40" });
        }
    }
}
