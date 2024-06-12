using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoozeClues.Migrations
{
    /// <inheritdoc />
    public partial class ImageRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "CocktailRecipes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3276d9f8-105a-4205-975d-d18cddc55c35", "AQAAAAIAAYagAAAAELANY2lw6qpvF6/oCzCeQKuBp8QG0d7Yjm0EUDpdUMY0h2JQzkS4mYq8Kxd59J/tOg==", "a425955d-4d2c-45c6-b7bc-e8088581a104" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7d21fac-3b21-454a-a747-075f072d0cf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e07d51e-83f1-4b6e-be3b-48b9632cf8d6", "AQAAAAIAAYagAAAAEPeVwC+VsRZE47xgZ56YNOUZ59mNVI4BTZob5L46DesEA9dPB6oyb13UTah757S3Pg==", "df3f8ab4-805e-4a71-b6b3-0b28409fb6fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "168e53e7-f616-402e-ad55-fcc025167534", "AQAAAAIAAYagAAAAEGi63GW7ECgfibiAKh9reTqqRVis04/3TbTnCMa2bZh8gsUhlFGgrJN2gZZjKFz7vg==", "fff68067-b354-4807-85fa-d1d3e1e0cc95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f332ecee-e9c1-4bec-913f-0f6fcfbcf649", "AQAAAAIAAYagAAAAECJRkR2rb2x8JuRZg+5wKfIfTGe3bGJ2S+oHQB8oWwJxc4RUWltJBxul0+MCgL5VKg==", "82ae0de3-556d-4ca7-9217-0b9a22952cf4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b2489a4-b47b-48da-8fde-fc265d750e0a", "AQAAAAIAAYagAAAAEL6cqaDD+ZUEx2CmMyVGTZpOqc/0G6YvQgYeOW2LINWKv/ILsXhuzLDwhU9UQ2q5ag==", "503bac38-5755-4fdb-8776-683c81c4ee88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9223dd4-9b34-4aa9-b418-034e44e5dfd9", "AQAAAAIAAYagAAAAEHr1CtolMAkaxBDWhYK5hr+e0uRhWulZmbfDmAPxmzgqPlVNcMFX4b8pRgLdRxyYmg==", "2bb34d0d-ee84-495f-bb0b-dab2370fb2ea" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "9d10b5ad-f494-4776-bb2b-47794fbd1cc7", "AQAAAAIAAYagAAAAEDVpYbSBwCdNI3UxkXXj9X8oMCdoc+JX+WVSUzKFfzBopgtRA5FGxuQ1wbGchi0gnQ==", "eafc63b9-a010-42d9-a941-be6aa860d3b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7d21fac-3b21-454a-a747-075f072d0cf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68e1ef78-a0c4-4adb-b496-7e7171071ad8", "AQAAAAIAAYagAAAAEFMsp4yJ5oHAK2azcoeRZGgxeqVPksEQpBSEuKwXq/CZcnNl4DcKSgjShHkdAHMWcw==", "6cd76e71-cf1f-4cf7-8ef0-6f9aca05dde4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8cdfbaa-4448-4291-8c88-c40ee5906210", "AQAAAAIAAYagAAAAEDKxLGZFbi2oZaY0s+8p/oIBLK+SaRgvn0ixSkh8r/vX5XFw+xGzNoOwYnH5S75nfQ==", "ed93bede-c7e0-4503-903f-8f8d08005fee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7b0fe17-efb5-43ff-b132-aaa5aafb9358", "AQAAAAIAAYagAAAAEA4hExO57HPCNzwF+ClB5SxDyEkxMd86EK4AOtweU/6GjRubEFccQtoFUgoVTUVyTA==", "fa190050-180f-4103-a8e5-430fe843c8aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b9f5710-42a5-4671-a68e-4d40dce615eb", "AQAAAAIAAYagAAAAEEAnc6BXAinUeIq+XmPhfp/WK1TMuw3WBnNOdCwJtVAGNrDoDvLxM2vV2A91NSasUw==", "240e905c-4649-43d1-8fc7-f9dc94e4d142" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e9fcca1-23a6-4aa7-b14f-b2fcbbc7a7a8", "AQAAAAIAAYagAAAAEL2dCF15b8W1jR4zZHe6XuFyKOkyJgXvdvOIpkS7A+NA9LNaFNcs/SNqANth6ou4BQ==", "2ae48e9b-d3a2-44b8-a5a8-920245fec35f" });

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
                value: "https://vinepair.com/wp-content/uploads/2020/07/whiskeysour_card.jpg");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://assets.epicurious.com/photos/605c8c8a8af215759419a491/1:1/w_1920,c_limit/Daiquiri_RECIPE_2_032321_11384.jpg");

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
    }
}
