using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intellexi.TrailRacing.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "trail_racing");

            migrationBuilder.CreateTable(
                name: "race",
                schema: "trail_racing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    distance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_race", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "trail_racing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "application",
                schema: "trail_racing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    club = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    race_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application", x => x.id);
                    table.ForeignKey(
                        name: "fk_application_race_race_id",
                        column: x => x.race_id,
                        principalSchema: "trail_racing",
                        principalTable: "race",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_application_race_id",
                schema: "trail_racing",
                table: "application",
                column: "race_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application",
                schema: "trail_racing");

            migrationBuilder.DropTable(
                name: "user",
                schema: "trail_racing");

            migrationBuilder.DropTable(
                name: "race",
                schema: "trail_racing");
        }
    }
}
