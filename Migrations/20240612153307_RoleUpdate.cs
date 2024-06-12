using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoozeClues.Migrations
{
    /// <inheritdoc />
    public partial class RoleUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "d8d76512-74f1-43bb-b1fd-87d3a8aa36df" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "d8d76512-74f1-43bb-b1fd-87d3a8aa36df" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3aaeb97-d2ba-4a53-a521-4eea61e59b35");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06104720-d5cd-401c-be42-f504580ecc97", "AQAAAAIAAYagAAAAEESEQvEdOVopFAon67snERfmUiPdsZvar40ZRqX5pgN3WZb0b9xqHbe8n8kv/ezIsQ==", "2f600d79-80db-4cc4-a646-7a0d41e5bd4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7d21fac-3b21-454a-a747-075f072d0cf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dadf193e-147e-4cd0-b4b7-b06332531283", "AQAAAAIAAYagAAAAEChU5a0xr7Y2eKoF9OXBmYIUkwb+z3rl1sEn472D//5nabYX6mIxbXjzDt2hlac5Sg==", "b8450441-d119-432f-abe0-9e2a81694fa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ac0cbd7-06f1-42a2-8423-5e2f3451d288", "AQAAAAIAAYagAAAAECJgC1OmqrLonb4vn/p0P2MGUJqYxdV8KzMVcWmUmfYEEvOm1R0WCSXqVBIDHIbYzA==", "e7aec2a3-7220-4426-adaa-c11940e3ed08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2cb908f-cc69-4006-b1df-286e5a06575f", "AQAAAAIAAYagAAAAECXjbvCrlG+79VZp/opxwDN3dYolcgwJ6eLhdXwtBVLftfwbemrJhViOsN5fP8hV6w==", "0c104569-e8c7-4ad4-9646-437a173ba4b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70bf67f7-839d-4ce3-8f33-6e31139af0fb", "AQAAAAIAAYagAAAAENBruaEJ8u9IROcuG5lv4lU9XOTY9HYjU3g1YfpGmKzPKsu6B4L27SOSV0Y1M5MvEQ==", "83eabbf7-8f39-4292-a70e-c04777649ab6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6941fcb7-b190-4b2e-a885-f8cdde77c904", "AQAAAAIAAYagAAAAENuuzXz5Jx486ZNTgzCYMwr43u9b8r2GUy1nL1DC50NzxtHGiXaKwL6NNPXh4kx2dA==", "34bf48b6-58ee-48d8-a969-92a050f57adb" });
        }
    }
}
