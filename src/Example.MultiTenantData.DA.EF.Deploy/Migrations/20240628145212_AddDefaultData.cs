using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Example.MultiTenantData.DA.EF.Deploy.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "exmt",
                table: "ReferenceEntity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1429f2ed-05ee-465c-a37a-e77537d98b21"), "Reference Item 2" },
                    { new Guid("e065b699-0e9c-493a-80dd-c8efec0eb2ca"), "Reference Item 1" }
                });

            migrationBuilder.InsertData(
                schema: "exmt",
                table: "SegregatedEntity",
                columns: new[] { "Id", "Date", "Name", "ReferenceEntityId", "TenantId" },
                values: new object[,]
                {
                    { new Guid("361976b4-2542-49c6-988f-49de24b64ac9"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Segregated Entity 4", new Guid("1429f2ed-05ee-465c-a37a-e77537d98b21"), "tenantc" },
                    { new Guid("408ecb1e-fed7-4b37-977a-97f1709bb3f5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Segregated Entity 1", new Guid("e065b699-0e9c-493a-80dd-c8efec0eb2ca"), "tenanta" },
                    { new Guid("816d9651-cb1f-44d3-adb7-d8372451bbb7"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Segregated Entity 2", new Guid("1429f2ed-05ee-465c-a37a-e77537d98b21"), "tenanta" },
                    { new Guid("9d6bffc6-7afa-43f7-8d40-1fd8679fe046"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Segregated Entity 3", new Guid("e065b699-0e9c-493a-80dd-c8efec0eb2ca"), "tenantb" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "exmt",
                table: "SegregatedEntity",
                keyColumn: "Id",
                keyValue: new Guid("361976b4-2542-49c6-988f-49de24b64ac9"));

            migrationBuilder.DeleteData(
                schema: "exmt",
                table: "SegregatedEntity",
                keyColumn: "Id",
                keyValue: new Guid("408ecb1e-fed7-4b37-977a-97f1709bb3f5"));

            migrationBuilder.DeleteData(
                schema: "exmt",
                table: "SegregatedEntity",
                keyColumn: "Id",
                keyValue: new Guid("816d9651-cb1f-44d3-adb7-d8372451bbb7"));

            migrationBuilder.DeleteData(
                schema: "exmt",
                table: "SegregatedEntity",
                keyColumn: "Id",
                keyValue: new Guid("9d6bffc6-7afa-43f7-8d40-1fd8679fe046"));
        }
    }
}
