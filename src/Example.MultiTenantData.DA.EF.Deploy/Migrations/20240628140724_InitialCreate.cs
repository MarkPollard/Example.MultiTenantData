using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.MultiTenantData.DA.EF.Deploy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "exmt");

            migrationBuilder.CreateTable(
                name: "ReferenceEntity",
                schema: "exmt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SegregatedEntity",
                schema: "exmt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegregatedEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SegregatedEntity_ReferenceEntity_ReferenceEntityId",
                        column: x => x.ReferenceEntityId,
                        principalSchema: "exmt",
                        principalTable: "ReferenceEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SegregatedEntity_ReferenceEntityId",
                schema: "exmt",
                table: "SegregatedEntity",
                column: "ReferenceEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SegregatedEntity",
                schema: "exmt");

            migrationBuilder.DropTable(
                name: "ReferenceEntity",
                schema: "exmt");
        }
    }
}
