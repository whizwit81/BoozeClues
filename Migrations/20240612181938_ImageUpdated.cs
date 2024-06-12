using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoozeClues.Migrations
{
    /// <inheritdoc />
    public partial class ImageUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 9,
                column: "ImageUrl",
                value: "https://vinepair.com/wp-content/uploads/2020/07/whiskeysour_card.jpg");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://assets.epicurious.com/photos/605c8c8a8af215759419a491/1:1/w_1920,c_limit/Daiquiri_RECIPE_2_032321_11384.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 9,
                column: "ImageUrl",
                value: "path_to_image/WhiskeySour.png");

            migrationBuilder.UpdateData(
                table: "CocktailRecipes",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "path_to_image/Daiquiri.png");
        }
    }
}
