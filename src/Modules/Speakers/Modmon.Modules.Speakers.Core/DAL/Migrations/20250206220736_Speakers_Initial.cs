using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modmon.Modules.Speakers.Core.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Speakers_Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "speakers");

            migrationBuilder.CreateTable(
                name: "Speakers",
                schema: "speakers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Biography = table.Column<string>(type: "text", nullable: false),
                    AvatarUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speakers",
                schema: "speakers");
        }
    }
}
