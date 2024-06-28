using Example.Common.DA.EF.MigrationsExtensions;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.MultiTenantData.DA.EF.Deploy.Migrations
{
    /// <inheritdoc />
    public partial class AddMultiTenancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                schema: "exmt",
                table: "SegregatedEntity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTenantFilterPredicateSecurityPolicy(
                name: "TenantSegregatedEntityFilter",
                schema: "exmt",
                table: "SegregatedEntity",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "exmt",
                table: "SegregatedEntity");

            migrationBuilder.DropTenantFilterPredicateSecurityPolicy(
                name: "TenantSegregatedEntityFilter",
                schema: "exmt");
        }
    }
}
