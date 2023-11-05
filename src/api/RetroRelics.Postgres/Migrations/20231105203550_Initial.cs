using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroRelics.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelicMetadata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    RelicId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelicMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelicMetadata_Relics_RelicId",
                        column: x => x.RelicId,
                        principalTable: "Relics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelicMetadata_RelicId",
                table: "RelicMetadata",
                column: "RelicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelicMetadata");

            migrationBuilder.DropTable(
                name: "Relics");
        }
    }
}
