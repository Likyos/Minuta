using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Minuta.App.persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    vehiculoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.vehiculoID);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numApartamento = table.Column<int>(type: "int", nullable: true),
                    estadoApartamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estadoResidente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehiculoID = table.Column<int>(type: "int", nullable: true),
                    placaVigilante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motivoVisita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visitor_vehiculoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Personas_Vehiculos_vehiculoID",
                        column: x => x.vehiculoID,
                        principalTable: "Vehiculos",
                        principalColumn: "vehiculoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Vehiculos_Visitor_vehiculoID",
                        column: x => x.Visitor_vehiculoID,
                        principalTable: "Vehiculos",
                        principalColumn: "vehiculoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Correspondencias",
                columns: table => new
                {
                    correspondenciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoCorrespondencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remitente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estadoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidenteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correspondencias", x => x.correspondenciaID);
                    table.ForeignKey(
                        name: "FK_Correspondencias_Personas_ResidenteID",
                        column: x => x.ResidenteID,
                        principalTable: "Personas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MinutaAnotaciones",
                columns: table => new
                {
                    minutaAnotacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaAnotacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    asunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vigilanteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinutaAnotaciones", x => x.minutaAnotacionID);
                    table.ForeignKey(
                        name: "FK_MinutaAnotaciones_Personas_vigilanteID",
                        column: x => x.vigilanteID,
                        principalTable: "Personas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Correspondencias_ResidenteID",
                table: "Correspondencias",
                column: "ResidenteID");

            migrationBuilder.CreateIndex(
                name: "IX_MinutaAnotaciones_vigilanteID",
                table: "MinutaAnotaciones",
                column: "vigilanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_vehiculoID",
                table: "Personas",
                column: "vehiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Visitor_vehiculoID",
                table: "Personas",
                column: "Visitor_vehiculoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Correspondencias");

            migrationBuilder.DropTable(
                name: "MinutaAnotaciones");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
