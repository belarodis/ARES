using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataAdmissao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QtdComputadores = table.Column<int>(type: "int", nullable: false),
                    ConfigComputadores = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NPatrimonio = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DataAquisicao = table.Column<DateOnly>(type: "date", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSala = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    TemProjetor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservaLaboratorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkFuncionario = table.Column<int>(type: "int", nullable: false),
                    FkLaboratorio = table.Column<int>(type: "int", nullable: false),
                    DataReserva = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaLaboratorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaLaboratorios_Funcionarios_FkFuncionario",
                        column: x => x.FkFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaLaboratorios_Laboratorios_FkLaboratorio",
                        column: x => x.FkLaboratorio,
                        principalTable: "Laboratorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaNotebooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkFuncionario = table.Column<int>(type: "int", nullable: false),
                    FkNotebook = table.Column<int>(type: "int", nullable: false),
                    DataReserva = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaNotebooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaNotebooks_Funcionarios_FkFuncionario",
                        column: x => x.FkFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaNotebooks_Notebooks_FkNotebook",
                        column: x => x.FkNotebook,
                        principalTable: "Notebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaSalas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkFuncionario = table.Column<int>(type: "int", nullable: false),
                    FkSala = table.Column<int>(type: "int", nullable: false),
                    DataReserva = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaSalas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaSalas_Funcionarios_FkFuncionario",
                        column: x => x.FkFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaSalas_Salas_FkSala",
                        column: x => x.FkSala,
                        principalTable: "Salas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Matricula",
                table: "Funcionarios",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laboratorios_Nome",
                table: "Laboratorios",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notebooks_NPatrimonio",
                table: "Notebooks",
                column: "NPatrimonio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservaLaboratorios_FkFuncionario",
                table: "ReservaLaboratorios",
                column: "FkFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaLaboratorios_FkLaboratorio",
                table: "ReservaLaboratorios",
                column: "FkLaboratorio");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaNotebooks_FkFuncionario",
                table: "ReservaNotebooks",
                column: "FkFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaNotebooks_FkNotebook",
                table: "ReservaNotebooks",
                column: "FkNotebook");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaSalas_FkFuncionario",
                table: "ReservaSalas",
                column: "FkFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaSalas_FkSala",
                table: "ReservaSalas",
                column: "FkSala");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaLaboratorios");

            migrationBuilder.DropTable(
                name: "ReservaNotebooks");

            migrationBuilder.DropTable(
                name: "ReservaSalas");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Notebooks");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
