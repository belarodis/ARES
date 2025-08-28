using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ARESDbContext : DbContext
{
    public ARESDbContext(DbContextOptions<ARESDbContext> options) : base(options)
    { }

    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<Notebook> Notebooks { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<ReservaLaboratorio> ReservaLaboratorios { get; set; }
    public DbSet<ReservaNotebook> ReservaNotebooks { get; set; }
    public DbSet<ReservaSala> ReservaSalas { get; set; }


    // Configurações adicionais
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configurações de entidades, relacionamentos, etc.

        modelBuilder.Entity<Funcionario>()
            .HasIndex(f => f.Matricula)
            .IsUnique();

        modelBuilder.Entity<Notebook>()
            .HasIndex(f => f.NPatrimonio)
            .IsUnique();

        modelBuilder.Entity<Laboratorio>()
            .HasIndex(f => f.Nome)
            .IsUnique();

        modelBuilder.Entity<Funcionario>().HasData(
            new Funcionario { Id = 1, Nome = "Marcela", Matricula = "12345", Cargo = "Analista", DataAdmissao = new DateOnly(2020, 5, 1) },
            new Funcionario { Id = 2, Nome = "Isabela", Matricula = "67890", Cargo = "Desenvolvedor", DataAdmissao = new DateOnly(2019, 8, 15) },
            new Funcionario { Id = 3, Nome = "João", Matricula = "54321", Cargo = "Estagiário", DataAdmissao = new DateOnly(2023, 1, 10) },
            new Funcionario { Id = 4, Nome = "Schultz", Matricula = "76538", Cargo = "Estagiário", DataAdmissao = new DateOnly(2024, 1, 15) }
        );

        // Seeds - Laboratorios
        modelBuilder.Entity<Laboratorio>().HasData(
            new Laboratorio { Id = 1, Nome = "Lab A", QtdComputadores = 10, ConfigComputadores = "Intel i5, 8GB RAM" },
            new Laboratorio { Id = 2, Nome = "Lab B", QtdComputadores = 12, ConfigComputadores = "Intel i7, 16GB RAM" },
            new Laboratorio { Id = 3, Nome = "Lab C", QtdComputadores = 8, ConfigComputadores = "AMD Ryzen 5, 16GB RAM" }
        );

        // Seeds - Notebooks
        modelBuilder.Entity<Notebook>().HasData(
            new Notebook { Id = 1, NPatrimonio = "NB001", DataAquisicao = new DateOnly(2025, 8, 10), Descricao = "Dell XPS 13" },
            new Notebook { Id = 2, NPatrimonio = "NB002", DataAquisicao = new DateOnly(2025, 8, 5), Descricao = "MacBook Pro" },
            new Notebook { Id = 3, NPatrimonio = "NB003", DataAquisicao = new DateOnly(2025, 8, 15), Descricao = "Lenovo ThinkPad" }
        );

        // Seeds - Salas
        modelBuilder.Entity<Sala>().HasData(
            new Sala { Id = 1, NumeroSala = "501", TemProjetor = true },
            new Sala { Id = 2, NumeroSala = "102", TemProjetor = false },
            new Sala { Id = 3, NumeroSala = "203", TemProjetor = true }
        );

        // --- Reservas de Laboratório ---
        modelBuilder.Entity<ReservaLaboratorio>().HasData(
            new ReservaLaboratorio { Id = 1, FkFuncionario = 1, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 7, 28) },
            new ReservaLaboratorio { Id = 2, FkFuncionario = 2, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 3) },
            new ReservaLaboratorio { Id = 3, FkFuncionario = 3, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 3) },
            new ReservaLaboratorio { Id = 4, FkFuncionario = 4, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 5) },
            new ReservaLaboratorio { Id = 5, FkFuncionario = 1, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 7) },
            new ReservaLaboratorio { Id = 6, FkFuncionario = 2, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 8) },
            new ReservaLaboratorio { Id = 7, FkFuncionario = 3, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 11) },
            new ReservaLaboratorio { Id = 8, FkFuncionario = 4, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 14) },
            new ReservaLaboratorio { Id = 9, FkFuncionario = 1, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 14) },
            new ReservaLaboratorio { Id = 10, FkFuncionario = 2, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 14) },
            new ReservaLaboratorio { Id = 11, FkFuncionario = 3, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 18) },
            new ReservaLaboratorio { Id = 12, FkFuncionario = 4, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 19) },
            new ReservaLaboratorio { Id = 13, FkFuncionario = 1, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 21) },
            new ReservaLaboratorio { Id = 14, FkFuncionario = 2, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 22) },
            new ReservaLaboratorio { Id = 15, FkFuncionario = 3, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 25) },
            new ReservaLaboratorio { Id = 16, FkFuncionario = 4, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 26) },
            new ReservaLaboratorio { Id = 17, FkFuncionario = 1, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 28) },
            new ReservaLaboratorio { Id = 18, FkFuncionario = 2, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 29) },
            new ReservaLaboratorio { Id = 19, FkFuncionario = 3, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 2) },
            new ReservaLaboratorio { Id = 20, FkFuncionario = 4, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 2) },
            new ReservaLaboratorio { Id = 21, FkFuncionario = 4, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 1) },
            new ReservaLaboratorio { Id = 22, FkFuncionario = 1, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 3) },
            new ReservaLaboratorio { Id = 23, FkFuncionario = 2, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 3) },
            new ReservaLaboratorio { Id = 24, FkFuncionario = 3, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 5) },
            new ReservaLaboratorio { Id = 25, FkFuncionario = 4, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 6) },
            new ReservaLaboratorio { Id = 26, FkFuncionario = 1, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 8) },
            new ReservaLaboratorio { Id = 27, FkFuncionario = 2, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 8) },
            new ReservaLaboratorio { Id = 28, FkFuncionario = 3, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 12) },
            new ReservaLaboratorio { Id = 29, FkFuncionario = 4, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 14) },
            new ReservaLaboratorio { Id = 30, FkFuncionario = 1, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 14) },
            new ReservaLaboratorio { Id = 31, FkFuncionario = 2, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 14) },
            new ReservaLaboratorio { Id = 32, FkFuncionario = 3, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 15) },
            new ReservaLaboratorio { Id = 33, FkFuncionario = 4, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 19) },
            new ReservaLaboratorio { Id = 34, FkFuncionario = 1, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 20) },
            new ReservaLaboratorio { Id = 35, FkFuncionario = 2, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 20) },
            new ReservaLaboratorio { Id = 36, FkFuncionario = 3, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 21) },
            new ReservaLaboratorio { Id = 37, FkFuncionario = 4, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 23) },
            new ReservaLaboratorio { Id = 38, FkFuncionario = 1, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 26) },
            new ReservaLaboratorio { Id = 39, FkFuncionario = 2, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 27) },
            new ReservaLaboratorio { Id = 40, FkFuncionario = 3, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 28) },
            new ReservaLaboratorio { Id = 41, FkFuncionario = 4, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 28) },
            new ReservaLaboratorio { Id = 42, FkFuncionario = 1, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 28) },
            new ReservaLaboratorio { Id = 43, FkFuncionario = 2, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 29) },
            new ReservaLaboratorio { Id = 44, FkFuncionario = 3, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 30) },
            new ReservaLaboratorio { Id = 45, FkFuncionario = 4, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 2) },
            new ReservaLaboratorio { Id = 46, FkFuncionario = 1, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 4) },
            new ReservaLaboratorio { Id = 47, FkFuncionario = 2, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 5) },
            new ReservaLaboratorio { Id = 48, FkFuncionario = 3, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 5) },
            new ReservaLaboratorio { Id = 49, FkFuncionario = 4, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 8) },
            new ReservaLaboratorio { Id = 50, FkFuncionario = 1, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 8) },
            new ReservaLaboratorio { Id = 51, FkFuncionario = 2, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 8) },
            new ReservaLaboratorio { Id = 52, FkFuncionario = 3, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 10) },
            new ReservaLaboratorio { Id = 53, FkFuncionario = 4, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 12) },
            new ReservaLaboratorio { Id = 54, FkFuncionario = 1, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 13) },
            new ReservaLaboratorio { Id = 55, FkFuncionario = 2, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 15) },
            new ReservaLaboratorio { Id = 56, FkFuncionario = 3, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 15) },
            new ReservaLaboratorio { Id = 57, FkFuncionario = 4, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 17) },
            new ReservaLaboratorio { Id = 58, FkFuncionario = 1, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 19) },
            new ReservaLaboratorio { Id = 59, FkFuncionario = 2, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 21) },
            new ReservaLaboratorio { Id = 60, FkFuncionario = 3, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 21) },
            new ReservaLaboratorio { Id = 61, FkFuncionario = 4, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 23) },
            new ReservaLaboratorio { Id = 62, FkFuncionario = 1, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 24) },
            new ReservaLaboratorio { Id = 63, FkFuncionario = 2, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 24) },
            new ReservaLaboratorio { Id = 64, FkFuncionario = 3, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 24) },
            new ReservaLaboratorio { Id = 65, FkFuncionario = 4, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 26) },
            new ReservaLaboratorio { Id = 66, FkFuncionario = 1, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 27) },
            new ReservaLaboratorio { Id = 67, FkFuncionario = 2, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 28) },
            new ReservaLaboratorio { Id = 68, FkFuncionario = 3, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 28) },
            new ReservaLaboratorio { Id = 69, FkFuncionario = 4, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 29) },
            new ReservaLaboratorio { Id = 70, FkFuncionario = 1, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 30) }
        );

        // --- Reservas de Notebook ---
        modelBuilder.Entity<ReservaNotebook>().HasData(
            new ReservaNotebook { Id = 1, FkFuncionario = 2, FkNotebook = 1, DataReserva = new DateOnly(2025, 7, 29) },
            new ReservaNotebook { Id = 2, FkFuncionario = 3, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 2) },
            new ReservaNotebook { Id = 3, FkFuncionario = 4, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 4) },
            new ReservaNotebook { Id = 4, FkFuncionario = 1, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 4) },
            new ReservaNotebook { Id = 5, FkFuncionario = 2, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 9) },
            new ReservaNotebook { Id = 6, FkFuncionario = 3, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 10) },
            new ReservaNotebook { Id = 7, FkFuncionario = 4, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 13) },
            new ReservaNotebook { Id = 8, FkFuncionario = 1, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 15) },
            new ReservaNotebook { Id = 9, FkFuncionario = 2, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 16) },
            new ReservaNotebook { Id = 10, FkFuncionario = 3, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 16) },
            new ReservaNotebook { Id = 11, FkFuncionario = 4, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 20) },
            new ReservaNotebook { Id = 12, FkFuncionario = 1, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 26) },
            new ReservaNotebook { Id = 13, FkFuncionario = 2, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 26) },
            new ReservaNotebook { Id = 14, FkFuncionario = 3, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 26) },
            new ReservaNotebook { Id = 15, FkFuncionario = 4, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 27) },
            new ReservaNotebook { Id = 16, FkFuncionario = 1, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 30) },
            new ReservaNotebook { Id = 17, FkFuncionario = 2, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 30) },
            new ReservaNotebook { Id = 18, FkFuncionario = 3, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 1) },
            new ReservaNotebook { Id = 19, FkFuncionario = 4, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 2) },
            new ReservaNotebook { Id = 20, FkFuncionario = 1, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 2) },
            new ReservaNotebook { Id = 21, FkFuncionario = 2, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 1) },
            new ReservaNotebook { Id = 22, FkFuncionario = 3, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 2) },
            new ReservaNotebook { Id = 23, FkFuncionario = 4, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 4) },
            new ReservaNotebook { Id = 24, FkFuncionario = 1, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 5) },
            new ReservaNotebook { Id = 25, FkFuncionario = 2, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 6) },
            new ReservaNotebook { Id = 26, FkFuncionario = 3, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 8) },
            new ReservaNotebook { Id = 27, FkFuncionario = 4, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 9) },
            new ReservaNotebook { Id = 28, FkFuncionario = 1, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 9) },
            new ReservaNotebook { Id = 29, FkFuncionario = 2, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 11) },
            new ReservaNotebook { Id = 30, FkFuncionario = 3, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 13) },
            new ReservaNotebook { Id = 31, FkFuncionario = 4, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 14) },
            new ReservaNotebook { Id = 32, FkFuncionario = 1, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 15) },
            new ReservaNotebook { Id = 33, FkFuncionario = 2, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 16) },
            new ReservaNotebook { Id = 34, FkFuncionario = 3, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 18) },
            new ReservaNotebook { Id = 35, FkFuncionario = 4, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 19) },
            new ReservaNotebook { Id = 36, FkFuncionario = 1, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 20) },
            new ReservaNotebook { Id = 37, FkFuncionario = 2, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 21) },
            new ReservaNotebook { Id = 38, FkFuncionario = 3, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 23) },
            new ReservaNotebook { Id = 39, FkFuncionario = 4, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 24) },
            new ReservaNotebook { Id = 40, FkFuncionario = 1, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 24) },
            new ReservaNotebook { Id = 41, FkFuncionario = 2, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 25) },
            new ReservaNotebook { Id = 42, FkFuncionario = 3, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 27) },
            new ReservaNotebook { Id = 43, FkFuncionario = 4, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 28) },
            new ReservaNotebook { Id = 44, FkFuncionario = 1, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 29) },
            new ReservaNotebook { Id = 45, FkFuncionario = 2, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 30) },
            new ReservaNotebook { Id = 46, FkFuncionario = 3, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 1) },
            new ReservaNotebook { Id = 47, FkFuncionario = 4, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 2) },
            new ReservaNotebook { Id = 48, FkFuncionario = 1, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 3) },
            new ReservaNotebook { Id = 49, FkFuncionario = 2, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 4) },
            new ReservaNotebook { Id = 50, FkFuncionario = 3, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 5) },
            new ReservaNotebook { Id = 51, FkFuncionario = 4, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 7) },
            new ReservaNotebook { Id = 52, FkFuncionario = 1, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 9) },
            new ReservaNotebook { Id = 53, FkFuncionario = 2, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 10) },
            new ReservaNotebook { Id = 54, FkFuncionario = 3, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 12) },
            new ReservaNotebook { Id = 55, FkFuncionario = 4, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 13) },
            new ReservaNotebook { Id = 56, FkFuncionario = 1, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 15) },
            new ReservaNotebook { Id = 57, FkFuncionario = 2, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 16) },
            new ReservaNotebook { Id = 58, FkFuncionario = 3, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 18) },
            new ReservaNotebook { Id = 59, FkFuncionario = 4, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 18) },
            new ReservaNotebook { Id = 60, FkFuncionario = 1, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 20) },
            new ReservaNotebook { Id = 61, FkFuncionario = 2, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 22) },
            new ReservaNotebook { Id = 62, FkFuncionario = 3, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 23) },
            new ReservaNotebook { Id = 63, FkFuncionario = 4, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 25) },
            new ReservaNotebook { Id = 64, FkFuncionario = 1, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 26) },
            new ReservaNotebook { Id = 65, FkFuncionario = 2, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 27) },
            new ReservaNotebook { Id = 66, FkFuncionario = 3, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 27) },
            new ReservaNotebook { Id = 67, FkFuncionario = 4, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 28) },
            new ReservaNotebook { Id = 68, FkFuncionario = 1, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 29) },
            new ReservaNotebook { Id = 69, FkFuncionario = 2, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 30) },
            new ReservaNotebook { Id = 70, FkFuncionario = 3, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 30) }
        );

        // --- Reservas de Sala ---
        modelBuilder.Entity<ReservaSala>().HasData(
            new ReservaSala { Id = 1, FkFuncionario = 3, FkSala = 1, DataReserva = new DateOnly(2025, 7, 30) },
            new ReservaSala { Id = 2, FkFuncionario = 4, FkSala = 2, DataReserva = new DateOnly(2025, 7, 30) },
            new ReservaSala { Id = 3, FkFuncionario = 1, FkSala = 3, DataReserva = new DateOnly(2025, 8, 3) },
            new ReservaSala { Id = 4, FkFuncionario = 2, FkSala = 1, DataReserva = new DateOnly(2025, 8, 5) },
            new ReservaSala { Id = 5, FkFuncionario = 3, FkSala = 2, DataReserva = new DateOnly(2025, 8, 6) },
            new ReservaSala { Id = 6, FkFuncionario = 4, FkSala = 3, DataReserva = new DateOnly(2025, 8, 9) },
            new ReservaSala { Id = 7, FkFuncionario = 1, FkSala = 1, DataReserva = new DateOnly(2025, 8, 9) },
            new ReservaSala { Id = 8, FkFuncionario = 2, FkSala = 2, DataReserva = new DateOnly(2025, 8, 9) },
            new ReservaSala { Id = 9, FkFuncionario = 3, FkSala = 3, DataReserva = new DateOnly(2025, 8, 12) },
            new ReservaSala { Id = 10, FkFuncionario = 4, FkSala = 1, DataReserva = new DateOnly(2025, 8, 14) },
            new ReservaSala { Id = 11, FkFuncionario = 1, FkSala = 2, DataReserva = new DateOnly(2025, 8, 15) },
            new ReservaSala { Id = 12, FkFuncionario = 2, FkSala = 3, DataReserva = new DateOnly(2025, 8, 17) },
            new ReservaSala { Id = 13, FkFuncionario = 3, FkSala = 1, DataReserva = new DateOnly(2025, 8, 19) },
            new ReservaSala { Id = 14, FkFuncionario = 4, FkSala = 2, DataReserva = new DateOnly(2025, 8, 20) },
            new ReservaSala { Id = 15, FkFuncionario = 1, FkSala = 3, DataReserva = new DateOnly(2025, 8, 22) },
            new ReservaSala { Id = 16, FkFuncionario = 2, FkSala = 1, DataReserva = new DateOnly(2025, 8, 25) },
            new ReservaSala { Id = 17, FkFuncionario = 3, FkSala = 2, DataReserva = new DateOnly(2025, 8, 25) },
            new ReservaSala { Id = 18, FkFuncionario = 4, FkSala = 3, DataReserva = new DateOnly(2025, 8, 26) },
            new ReservaSala { Id = 19, FkFuncionario = 1, FkSala = 1, DataReserva = new DateOnly(2025, 9, 1) },
            new ReservaSala { Id = 20, FkFuncionario = 2, FkSala = 2, DataReserva = new DateOnly(2025, 9, 3) },
            new ReservaSala { Id = 21, FkFuncionario = 3, FkSala = 3, DataReserva = new DateOnly(2025, 7, 31) },
            new ReservaSala { Id = 22, FkFuncionario = 4, FkSala = 1, DataReserva = new DateOnly(2025, 8, 2) },
            new ReservaSala { Id = 23, FkFuncionario = 1, FkSala = 2, DataReserva = new DateOnly(2025, 8, 4) },
            new ReservaSala { Id = 24, FkFuncionario = 2, FkSala = 3, DataReserva = new DateOnly(2025, 8, 5) },
            new ReservaSala { Id = 25, FkFuncionario = 3, FkSala = 1, DataReserva = new DateOnly(2025, 8, 5) },
            new ReservaSala { Id = 26, FkFuncionario = 4, FkSala = 2, DataReserva = new DateOnly(2025, 8, 8) },
            new ReservaSala { Id = 27, FkFuncionario = 1, FkSala = 3, DataReserva = new DateOnly(2025, 8, 8) },
            new ReservaSala { Id = 28, FkFuncionario = 2, FkSala = 1, DataReserva = new DateOnly(2025, 8, 12) },
            new ReservaSala { Id = 29, FkFuncionario = 3, FkSala = 2, DataReserva = new DateOnly(2025, 8, 14) },
            new ReservaSala { Id = 30, FkFuncionario = 4, FkSala = 3, DataReserva = new DateOnly(2025, 8, 15) },
            new ReservaSala { Id = 31, FkFuncionario = 1, FkSala = 1, DataReserva = new DateOnly(2025, 8, 15) },
            new ReservaSala { Id = 32, FkFuncionario = 2, FkSala = 2, DataReserva = new DateOnly(2025, 8, 15) },
            new ReservaSala { Id = 33, FkFuncionario = 3, FkSala = 3, DataReserva = new DateOnly(2025, 8, 19) },
            new ReservaSala { Id = 34, FkFuncionario = 4, FkSala = 1, DataReserva = new DateOnly(2025, 8, 20) },
            new ReservaSala { Id = 35, FkFuncionario = 1, FkSala = 2, DataReserva = new DateOnly(2025, 8, 21) },
            new ReservaSala { Id = 36, FkFuncionario = 2, FkSala = 3, DataReserva = new DateOnly(2025, 8, 23) },
            new ReservaSala { Id = 37, FkFuncionario = 3, FkSala = 1, DataReserva = new DateOnly(2025, 8, 24) },
            new ReservaSala { Id = 38, FkFuncionario = 4, FkSala = 2, DataReserva = new DateOnly(2025, 8, 27) },
            new ReservaSala { Id = 39, FkFuncionario = 1, FkSala = 3, DataReserva = new DateOnly(2025, 8, 28) },
            new ReservaSala { Id = 40, FkFuncionario = 2, FkSala = 1, DataReserva = new DateOnly(2025, 8, 29) },
            new ReservaSala { Id = 41, FkFuncionario = 3, FkSala = 2, DataReserva = new DateOnly(2025, 8, 30) },
            new ReservaSala { Id = 42, FkFuncionario = 4, FkSala = 3, DataReserva = new DateOnly(2025, 9, 1) },
            new ReservaSala { Id = 43, FkFuncionario = 1, FkSala = 1, DataReserva = new DateOnly(2025, 9, 3) },
            new ReservaSala { Id = 44, FkFuncionario = 2, FkSala = 2, DataReserva = new DateOnly(2025, 9, 4) },
            new ReservaSala { Id = 45, FkFuncionario = 3, FkSala = 3, DataReserva = new DateOnly(2025, 9, 5) },
            new ReservaSala { Id = 46, FkFuncionario = 4, FkSala = 1, DataReserva = new DateOnly(2025, 9, 6) },
            new ReservaSala { Id = 47, FkFuncionario = 1, FkSala = 2, DataReserva = new DateOnly(2025, 9, 8) },
            new ReservaSala { Id = 48, FkFuncionario = 2, FkSala = 3, DataReserva = new DateOnly(2025, 9, 9) },
            new ReservaSala { Id = 49, FkFuncionario = 3, FkSala = 1, DataReserva = new DateOnly(2025, 9, 10) },
            new ReservaSala { Id = 50, FkFuncionario = 4, FkSala = 2, DataReserva = new DateOnly(2025, 9, 11) },
            new ReservaSala { Id = 51, FkFuncionario = 1, FkSala = 3, DataReserva = new DateOnly(2025, 9, 12) },
            new ReservaSala { Id = 52, FkFuncionario = 2, FkSala = 1, DataReserva = new DateOnly(2025, 9, 14) },
            new ReservaSala { Id = 53, FkFuncionario = 3, FkSala = 2, DataReserva = new DateOnly(2025, 9, 15) },
            new ReservaSala { Id = 54, FkFuncionario = 4, FkSala = 3, DataReserva = new DateOnly(2025, 9, 16) },
            new ReservaSala { Id = 55, FkFuncionario = 1, FkSala = 1, DataReserva = new DateOnly(2025, 9, 17) },
            new ReservaSala { Id = 56, FkFuncionario = 2, FkSala = 2, DataReserva = new DateOnly(2025, 9, 18) },
            new ReservaSala { Id = 57, FkFuncionario = 3, FkSala = 3, DataReserva = new DateOnly(2025, 9, 19) },
            new ReservaSala { Id = 58, FkFuncionario = 4, FkSala = 1, DataReserva = new DateOnly(2025, 9, 20) },
            new ReservaSala { Id = 59, FkFuncionario = 1, FkSala = 2, DataReserva = new DateOnly(2025, 9, 22) },
            new ReservaSala { Id = 60, FkFuncionario = 2, FkSala = 3, DataReserva = new DateOnly(2025, 9, 22) },
            new ReservaSala { Id = 61, FkFuncionario = 3, FkSala = 1, DataReserva = new DateOnly(2025, 9, 23) },
            new ReservaSala { Id = 62, FkFuncionario = 4, FkSala = 2, DataReserva = new DateOnly(2025, 9, 25) },
            new ReservaSala { Id = 63, FkFuncionario = 1, FkSala = 3, DataReserva = new DateOnly(2025, 9, 25) },
            new ReservaSala { Id = 64, FkFuncionario = 2, FkSala = 1, DataReserva = new DateOnly(2025, 9, 26) },
            new ReservaSala { Id = 65, FkFuncionario = 3, FkSala = 2, DataReserva = new DateOnly(2025, 9, 27) },
            new ReservaSala { Id = 66, FkFuncionario = 4, FkSala = 3, DataReserva = new DateOnly(2025, 9, 28) },
            new ReservaSala { Id = 67, FkFuncionario = 1, FkSala = 1, DataReserva = new DateOnly(2025, 9, 28) },
            new ReservaSala { Id = 68, FkFuncionario = 2, FkSala = 2, DataReserva = new DateOnly(2025, 9, 29) },
            new ReservaSala { Id = 69, FkFuncionario = 3, FkSala = 3, DataReserva = new DateOnly(2025, 9, 29) },
            new ReservaSala { Id = 70, FkFuncionario = 4, FkSala = 1, DataReserva = new DateOnly(2025, 9, 30) }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ARESDB;Trusted_Connection=True;");
        }
    }
}

