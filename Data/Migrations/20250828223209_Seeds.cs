using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
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
                columns: new[] { "Id", "NumeroSala", "TemProjetor" },
                values: new object[,]
                {
                    { 1, "501", true },
                    { 2, "102", false },
                    { 3, "203", true }
                });

            migrationBuilder.InsertData(
                table: "ReservaLaboratorios",
                columns: new[] { "Id", "DataReserva", "FkFuncionario", "FkLaboratorio" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 7, 28), 1, 1 },
                    { 2, new DateOnly(2025, 8, 3), 2, 2 },
                    { 3, new DateOnly(2025, 8, 3), 3, 3 },
                    { 4, new DateOnly(2025, 8, 5), 4, 1 },
                    { 5, new DateOnly(2025, 8, 7), 1, 2 },
                    { 6, new DateOnly(2025, 8, 8), 2, 3 },
                    { 7, new DateOnly(2025, 8, 11), 3, 1 },
                    { 8, new DateOnly(2025, 8, 14), 4, 2 },
                    { 9, new DateOnly(2025, 8, 14), 1, 3 },
                    { 10, new DateOnly(2025, 8, 14), 2, 1 },
                    { 11, new DateOnly(2025, 8, 18), 3, 2 },
                    { 12, new DateOnly(2025, 8, 19), 4, 3 },
                    { 13, new DateOnly(2025, 8, 21), 1, 1 },
                    { 14, new DateOnly(2025, 8, 22), 2, 2 },
                    { 15, new DateOnly(2025, 8, 25), 3, 3 },
                    { 16, new DateOnly(2025, 8, 26), 4, 1 },
                    { 17, new DateOnly(2025, 8, 28), 1, 2 },
                    { 18, new DateOnly(2025, 8, 29), 2, 3 },
                    { 19, new DateOnly(2025, 9, 2), 3, 1 },
                    { 20, new DateOnly(2025, 9, 2), 4, 2 },
                    { 21, new DateOnly(2025, 8, 1), 4, 2 },
                    { 22, new DateOnly(2025, 8, 3), 1, 1 },
                    { 23, new DateOnly(2025, 8, 3), 2, 3 },
                    { 24, new DateOnly(2025, 8, 5), 3, 2 },
                    { 25, new DateOnly(2025, 8, 6), 4, 1 },
                    { 26, new DateOnly(2025, 8, 8), 1, 3 },
                    { 27, new DateOnly(2025, 8, 8), 2, 2 },
                    { 28, new DateOnly(2025, 8, 12), 3, 1 },
                    { 29, new DateOnly(2025, 8, 14), 4, 3 },
                    { 30, new DateOnly(2025, 8, 14), 1, 2 },
                    { 31, new DateOnly(2025, 8, 14), 2, 1 },
                    { 32, new DateOnly(2025, 8, 15), 3, 3 },
                    { 33, new DateOnly(2025, 8, 19), 4, 2 },
                    { 34, new DateOnly(2025, 8, 20), 1, 1 },
                    { 35, new DateOnly(2025, 8, 20), 2, 3 },
                    { 36, new DateOnly(2025, 8, 21), 3, 2 },
                    { 37, new DateOnly(2025, 8, 23), 4, 1 },
                    { 38, new DateOnly(2025, 8, 26), 1, 3 },
                    { 39, new DateOnly(2025, 8, 27), 2, 2 },
                    { 40, new DateOnly(2025, 8, 28), 3, 1 },
                    { 41, new DateOnly(2025, 8, 28), 4, 3 },
                    { 42, new DateOnly(2025, 8, 28), 1, 2 },
                    { 43, new DateOnly(2025, 8, 29), 2, 1 },
                    { 44, new DateOnly(2025, 8, 30), 3, 3 },
                    { 45, new DateOnly(2025, 9, 2), 4, 2 },
                    { 46, new DateOnly(2025, 9, 4), 1, 1 },
                    { 47, new DateOnly(2025, 9, 5), 2, 3 },
                    { 48, new DateOnly(2025, 9, 5), 3, 2 },
                    { 49, new DateOnly(2025, 9, 8), 4, 1 },
                    { 50, new DateOnly(2025, 9, 8), 1, 3 },
                    { 51, new DateOnly(2025, 9, 8), 2, 2 },
                    { 52, new DateOnly(2025, 9, 10), 3, 1 },
                    { 53, new DateOnly(2025, 9, 12), 4, 3 },
                    { 54, new DateOnly(2025, 9, 13), 1, 2 },
                    { 55, new DateOnly(2025, 9, 15), 2, 1 },
                    { 56, new DateOnly(2025, 9, 15), 3, 3 },
                    { 57, new DateOnly(2025, 9, 17), 4, 2 },
                    { 58, new DateOnly(2025, 9, 19), 1, 1 },
                    { 59, new DateOnly(2025, 9, 21), 2, 3 },
                    { 60, new DateOnly(2025, 9, 21), 3, 2 },
                    { 61, new DateOnly(2025, 9, 23), 4, 1 },
                    { 62, new DateOnly(2025, 9, 24), 1, 3 },
                    { 63, new DateOnly(2025, 9, 24), 2, 2 },
                    { 64, new DateOnly(2025, 9, 24), 3, 1 },
                    { 65, new DateOnly(2025, 9, 26), 4, 3 },
                    { 66, new DateOnly(2025, 9, 27), 1, 2 },
                    { 67, new DateOnly(2025, 9, 28), 2, 1 },
                    { 68, new DateOnly(2025, 9, 28), 3, 3 },
                    { 69, new DateOnly(2025, 9, 29), 4, 2 },
                    { 70, new DateOnly(2025, 9, 30), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ReservaNotebooks",
                columns: new[] { "Id", "DataReserva", "FkFuncionario", "FkNotebook" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 7, 29), 2, 1 },
                    { 2, new DateOnly(2025, 8, 2), 3, 2 },
                    { 3, new DateOnly(2025, 8, 4), 4, 3 },
                    { 4, new DateOnly(2025, 8, 4), 1, 1 },
                    { 5, new DateOnly(2025, 8, 9), 2, 2 },
                    { 6, new DateOnly(2025, 8, 10), 3, 3 },
                    { 7, new DateOnly(2025, 8, 13), 4, 1 },
                    { 8, new DateOnly(2025, 8, 15), 1, 2 },
                    { 9, new DateOnly(2025, 8, 16), 2, 3 },
                    { 10, new DateOnly(2025, 8, 16), 3, 1 },
                    { 11, new DateOnly(2025, 8, 20), 4, 2 },
                    { 12, new DateOnly(2025, 8, 26), 1, 3 },
                    { 13, new DateOnly(2025, 8, 26), 2, 1 },
                    { 14, new DateOnly(2025, 8, 26), 3, 2 },
                    { 15, new DateOnly(2025, 8, 27), 4, 3 },
                    { 16, new DateOnly(2025, 8, 30), 1, 1 },
                    { 17, new DateOnly(2025, 8, 30), 2, 2 },
                    { 18, new DateOnly(2025, 9, 1), 3, 3 },
                    { 19, new DateOnly(2025, 9, 2), 4, 1 },
                    { 20, new DateOnly(2025, 9, 2), 1, 2 },
                    { 21, new DateOnly(2025, 8, 1), 2, 3 },
                    { 22, new DateOnly(2025, 8, 2), 3, 1 },
                    { 23, new DateOnly(2025, 8, 4), 4, 2 },
                    { 24, new DateOnly(2025, 8, 5), 1, 3 },
                    { 25, new DateOnly(2025, 8, 6), 2, 1 },
                    { 26, new DateOnly(2025, 8, 8), 3, 2 },
                    { 27, new DateOnly(2025, 8, 9), 4, 3 },
                    { 28, new DateOnly(2025, 8, 9), 1, 1 },
                    { 29, new DateOnly(2025, 8, 11), 2, 2 },
                    { 30, new DateOnly(2025, 8, 13), 3, 3 },
                    { 31, new DateOnly(2025, 8, 14), 4, 1 },
                    { 32, new DateOnly(2025, 8, 15), 1, 2 },
                    { 33, new DateOnly(2025, 8, 16), 2, 3 },
                    { 34, new DateOnly(2025, 8, 18), 3, 1 },
                    { 35, new DateOnly(2025, 8, 19), 4, 2 },
                    { 36, new DateOnly(2025, 8, 20), 1, 3 },
                    { 37, new DateOnly(2025, 8, 21), 2, 1 },
                    { 38, new DateOnly(2025, 8, 23), 3, 2 },
                    { 39, new DateOnly(2025, 8, 24), 4, 3 },
                    { 40, new DateOnly(2025, 8, 24), 1, 1 },
                    { 41, new DateOnly(2025, 8, 25), 2, 2 },
                    { 42, new DateOnly(2025, 8, 27), 3, 3 },
                    { 43, new DateOnly(2025, 8, 28), 4, 1 },
                    { 44, new DateOnly(2025, 8, 29), 1, 2 },
                    { 45, new DateOnly(2025, 8, 30), 2, 3 },
                    { 46, new DateOnly(2025, 9, 1), 3, 1 },
                    { 47, new DateOnly(2025, 9, 2), 4, 2 },
                    { 48, new DateOnly(2025, 9, 3), 1, 3 },
                    { 49, new DateOnly(2025, 9, 4), 2, 1 },
                    { 50, new DateOnly(2025, 9, 5), 3, 2 },
                    { 51, new DateOnly(2025, 9, 7), 4, 3 },
                    { 52, new DateOnly(2025, 9, 9), 1, 1 },
                    { 53, new DateOnly(2025, 9, 10), 2, 2 },
                    { 54, new DateOnly(2025, 9, 12), 3, 3 },
                    { 55, new DateOnly(2025, 9, 13), 4, 1 },
                    { 56, new DateOnly(2025, 9, 15), 1, 2 },
                    { 57, new DateOnly(2025, 9, 16), 2, 3 },
                    { 58, new DateOnly(2025, 9, 18), 3, 1 },
                    { 59, new DateOnly(2025, 9, 18), 4, 2 },
                    { 60, new DateOnly(2025, 9, 20), 1, 3 },
                    { 61, new DateOnly(2025, 9, 22), 2, 1 },
                    { 62, new DateOnly(2025, 9, 23), 3, 2 },
                    { 63, new DateOnly(2025, 9, 25), 4, 3 },
                    { 64, new DateOnly(2025, 9, 26), 1, 1 },
                    { 65, new DateOnly(2025, 9, 27), 2, 2 },
                    { 66, new DateOnly(2025, 9, 27), 3, 3 },
                    { 67, new DateOnly(2025, 9, 28), 4, 1 },
                    { 68, new DateOnly(2025, 9, 29), 1, 2 },
                    { 69, new DateOnly(2025, 9, 30), 2, 3 },
                    { 70, new DateOnly(2025, 9, 30), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "ReservaSalas",
                columns: new[] { "Id", "DataReserva", "FkFuncionario", "FkSala" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 7, 30), 3, 1 },
                    { 2, new DateOnly(2025, 7, 30), 4, 2 },
                    { 3, new DateOnly(2025, 8, 3), 1, 3 },
                    { 4, new DateOnly(2025, 8, 5), 2, 1 },
                    { 5, new DateOnly(2025, 8, 6), 3, 2 },
                    { 6, new DateOnly(2025, 8, 9), 4, 3 },
                    { 7, new DateOnly(2025, 8, 9), 1, 1 },
                    { 8, new DateOnly(2025, 8, 9), 2, 2 },
                    { 9, new DateOnly(2025, 8, 12), 3, 3 },
                    { 10, new DateOnly(2025, 8, 14), 4, 1 },
                    { 11, new DateOnly(2025, 8, 15), 1, 2 },
                    { 12, new DateOnly(2025, 8, 17), 2, 3 },
                    { 13, new DateOnly(2025, 8, 19), 3, 1 },
                    { 14, new DateOnly(2025, 8, 20), 4, 2 },
                    { 15, new DateOnly(2025, 8, 22), 1, 3 },
                    { 16, new DateOnly(2025, 8, 25), 2, 1 },
                    { 17, new DateOnly(2025, 8, 25), 3, 2 },
                    { 18, new DateOnly(2025, 8, 26), 4, 3 },
                    { 19, new DateOnly(2025, 9, 1), 1, 1 },
                    { 20, new DateOnly(2025, 9, 3), 2, 2 },
                    { 21, new DateOnly(2025, 7, 31), 3, 3 },
                    { 22, new DateOnly(2025, 8, 2), 4, 1 },
                    { 23, new DateOnly(2025, 8, 4), 1, 2 },
                    { 24, new DateOnly(2025, 8, 5), 2, 3 },
                    { 25, new DateOnly(2025, 8, 5), 3, 1 },
                    { 26, new DateOnly(2025, 8, 8), 4, 2 },
                    { 27, new DateOnly(2025, 8, 8), 1, 3 },
                    { 28, new DateOnly(2025, 8, 12), 2, 1 },
                    { 29, new DateOnly(2025, 8, 14), 3, 2 },
                    { 30, new DateOnly(2025, 8, 15), 4, 3 },
                    { 31, new DateOnly(2025, 8, 15), 1, 1 },
                    { 32, new DateOnly(2025, 8, 15), 2, 2 },
                    { 33, new DateOnly(2025, 8, 19), 3, 3 },
                    { 34, new DateOnly(2025, 8, 20), 4, 1 },
                    { 35, new DateOnly(2025, 8, 21), 1, 2 },
                    { 36, new DateOnly(2025, 8, 23), 2, 3 },
                    { 37, new DateOnly(2025, 8, 24), 3, 1 },
                    { 38, new DateOnly(2025, 8, 27), 4, 2 },
                    { 39, new DateOnly(2025, 8, 28), 1, 3 },
                    { 40, new DateOnly(2025, 8, 29), 2, 1 },
                    { 41, new DateOnly(2025, 8, 30), 3, 2 },
                    { 42, new DateOnly(2025, 9, 1), 4, 3 },
                    { 43, new DateOnly(2025, 9, 3), 1, 1 },
                    { 44, new DateOnly(2025, 9, 4), 2, 2 },
                    { 45, new DateOnly(2025, 9, 5), 3, 3 },
                    { 46, new DateOnly(2025, 9, 6), 4, 1 },
                    { 47, new DateOnly(2025, 9, 8), 1, 2 },
                    { 48, new DateOnly(2025, 9, 9), 2, 3 },
                    { 49, new DateOnly(2025, 9, 10), 3, 1 },
                    { 50, new DateOnly(2025, 9, 11), 4, 2 },
                    { 51, new DateOnly(2025, 9, 12), 1, 3 },
                    { 52, new DateOnly(2025, 9, 14), 2, 1 },
                    { 53, new DateOnly(2025, 9, 15), 3, 2 },
                    { 54, new DateOnly(2025, 9, 16), 4, 3 },
                    { 55, new DateOnly(2025, 9, 17), 1, 1 },
                    { 56, new DateOnly(2025, 9, 18), 2, 2 },
                    { 57, new DateOnly(2025, 9, 19), 3, 3 },
                    { 58, new DateOnly(2025, 9, 20), 4, 1 },
                    { 59, new DateOnly(2025, 9, 22), 1, 2 },
                    { 60, new DateOnly(2025, 9, 22), 2, 3 },
                    { 61, new DateOnly(2025, 9, 23), 3, 1 },
                    { 62, new DateOnly(2025, 9, 25), 4, 2 },
                    { 63, new DateOnly(2025, 9, 25), 1, 3 },
                    { 64, new DateOnly(2025, 9, 26), 2, 1 },
                    { 65, new DateOnly(2025, 9, 27), 3, 2 },
                    { 66, new DateOnly(2025, 9, 28), 4, 3 },
                    { 67, new DateOnly(2025, 9, 28), 1, 1 },
                    { 68, new DateOnly(2025, 9, 29), 2, 2 },
                    { 69, new DateOnly(2025, 9, 29), 3, 3 },
                    { 70, new DateOnly(2025, 9, 30), 4, 1 }
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
