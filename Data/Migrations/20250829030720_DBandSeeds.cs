using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DBandSeeds : Migration
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
                    TemProjetor = table.Column<bool>(type: "bit", nullable: false),
                    qtdLugares = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Cargo", "DataAdmissao", "Matricula", "Nome" },
                values: new object[,]
                {
                    { 1, "Analista", new DateOnly(2020, 5, 1), "12345", "Marcela" },
                    { 2, "Desenvolvedor", new DateOnly(2019, 8, 15), "67890", "Isabela" },
                    { 3, "Estagiário", new DateOnly(2023, 1, 10), "54321", "João" },
                    { 4, "Estagiário", new DateOnly(2024, 1, 15), "76538", "Schultz" }
                });

            migrationBuilder.InsertData(
                table: "Laboratorios",
                columns: new[] { "Id", "ConfigComputadores", "Nome", "QtdComputadores" },
                values: new object[,]
                {
                    { 1, "Intel i5, 8GB RAM", "Lab A", 10 },
                    { 2, "Intel i7, 16GB RAM", "Lab B", 12 },
                    { 3, "AMD Ryzen 5, 16GB RAM", "Lab C", 8 }
                });

            migrationBuilder.InsertData(
                table: "Notebooks",
                columns: new[] { "Id", "DataAquisicao", "Descricao", "NPatrimonio" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 8, 10), "Dell XPS 13", "NB001" },
                    { 2, new DateOnly(2025, 8, 5), "MacBook Pro", "NB002" },
                    { 3, new DateOnly(2025, 8, 15), "Lenovo ThinkPad", "NB003" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Id", "NumeroSala", "TemProjetor", "qtdLugares" },
                values: new object[,]
                {
                    { 1, "501", true, 40 },
                    { 2, "102", false, 30 },
                    { 3, "203", true, 20 }
                });

            migrationBuilder.InsertData(
                table: "ReservaLaboratorios",
                columns: new[] { "Id", "DataReserva", "FkFuncionario", "FkLaboratorio" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 8, 26), 1, 1 },
                    { 2, new DateOnly(2025, 8, 26), 2, 2 },
                    { 3, new DateOnly(2025, 8, 28), 3, 3 },
                    { 4, new DateOnly(2025, 8, 29), 4, 1 },
                    { 5, new DateOnly(2025, 8, 30), 1, 2 },
                    { 6, new DateOnly(2025, 8, 31), 2, 3 },
                    { 7, new DateOnly(2025, 9, 1), 3, 1 },
                    { 8, new DateOnly(2025, 9, 2), 4, 2 },
                    { 9, new DateOnly(2025, 9, 3), 1, 3 },
                    { 10, new DateOnly(2025, 9, 4), 2, 1 },
                    { 11, new DateOnly(2025, 9, 5), 3, 2 },
                    { 12, new DateOnly(2025, 9, 6), 4, 3 },
                    { 13, new DateOnly(2025, 9, 7), 1, 1 },
                    { 14, new DateOnly(2025, 9, 8), 2, 2 },
                    { 15, new DateOnly(2025, 9, 9), 3, 3 },
                    { 16, new DateOnly(2025, 9, 10), 4, 1 },
                    { 17, new DateOnly(2025, 9, 11), 1, 2 },
                    { 18, new DateOnly(2025, 9, 12), 2, 3 },
                    { 19, new DateOnly(2025, 9, 13), 3, 1 },
                    { 20, new DateOnly(2025, 9, 14), 4, 2 },
                    { 21, new DateOnly(2025, 9, 15), 1, 3 },
                    { 22, new DateOnly(2025, 9, 16), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ReservaNotebooks",
                columns: new[] { "Id", "DataReserva", "FkFuncionario", "FkNotebook" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 8, 25), 3, 1 },
                    { 2, new DateOnly(2025, 8, 26), 1, 2 },
                    { 3, new DateOnly(2025, 8, 27), 2, 3 },
                    { 4, new DateOnly(2025, 8, 28), 4, 1 },
                    { 5, new DateOnly(2025, 8, 29), 1, 2 },
                    { 6, new DateOnly(2025, 8, 30), 2, 3 },
                    { 7, new DateOnly(2025, 8, 31), 3, 1 },
                    { 8, new DateOnly(2025, 9, 1), 4, 2 },
                    { 9, new DateOnly(2025, 9, 2), 1, 3 },
                    { 10, new DateOnly(2025, 9, 3), 2, 1 },
                    { 11, new DateOnly(2025, 9, 4), 3, 2 },
                    { 12, new DateOnly(2025, 9, 5), 4, 3 },
                    { 13, new DateOnly(2025, 9, 6), 1, 1 },
                    { 14, new DateOnly(2025, 9, 7), 2, 2 },
                    { 15, new DateOnly(2025, 9, 8), 3, 3 },
                    { 16, new DateOnly(2025, 9, 9), 4, 1 },
                    { 17, new DateOnly(2025, 9, 10), 1, 2 },
                    { 18, new DateOnly(2025, 9, 11), 2, 3 },
                    { 19, new DateOnly(2025, 9, 12), 3, 1 },
                    { 20, new DateOnly(2025, 9, 13), 4, 2 },
                    { 21, new DateOnly(2025, 9, 14), 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "ReservaSalas",
                columns: new[] { "Id", "DataReserva", "FkFuncionario", "FkSala" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 8, 27), 1, 1 },
                    { 2, new DateOnly(2025, 8, 28), 2, 2 },
                    { 3, new DateOnly(2025, 8, 29), 3, 3 },
                    { 4, new DateOnly(2025, 8, 30), 4, 1 },
                    { 5, new DateOnly(2025, 8, 31), 1, 2 },
                    { 6, new DateOnly(2025, 9, 1), 2, 3 },
                    { 7, new DateOnly(2025, 9, 2), 3, 1 },
                    { 8, new DateOnly(2025, 9, 3), 4, 2 },
                    { 9, new DateOnly(2025, 9, 4), 1, 3 },
                    { 10, new DateOnly(2025, 9, 5), 2, 1 },
                    { 11, new DateOnly(2025, 9, 6), 3, 2 },
                    { 12, new DateOnly(2025, 9, 7), 4, 3 },
                    { 13, new DateOnly(2025, 9, 8), 1, 1 },
                    { 14, new DateOnly(2025, 9, 9), 2, 2 },
                    { 15, new DateOnly(2025, 9, 10), 3, 3 },
                    { 16, new DateOnly(2025, 9, 11), 4, 1 },
                    { 17, new DateOnly(2025, 9, 12), 1, 2 },
                    { 18, new DateOnly(2025, 9, 13), 2, 3 },
                    { 19, new DateOnly(2025, 9, 14), 3, 1 },
                    { 20, new DateOnly(2025, 9, 15), 4, 2 },
                    { 21, new DateOnly(2025, 9, 16), 1, 3 }
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
