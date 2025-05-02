using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appmascota.Data.Migrations
{
    /// <inheritdoc />
    public partial class CrearModeloDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_adoptante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Edad = table.Column<int>(type: "INTEGER", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_adoptante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Edad = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_mascota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_mascota_adoptante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MascotaId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdoptanteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_mascota_adoptante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_mascota_adoptante_t_adoptante_AdoptanteId",
                        column: x => x.AdoptanteId,
                        principalTable: "t_adoptante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_mascota_adoptante_t_mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "t_mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_mascota_adoptante_AdoptanteId",
                table: "t_mascota_adoptante",
                column: "AdoptanteId");

            migrationBuilder.CreateIndex(
                name: "IX_t_mascota_adoptante_MascotaId",
                table: "t_mascota_adoptante",
                column: "MascotaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_mascota_adoptante");

            migrationBuilder.DropTable(
                name: "t_adoptante");

            migrationBuilder.DropTable(
                name: "t_mascota");
        }
    }
}
