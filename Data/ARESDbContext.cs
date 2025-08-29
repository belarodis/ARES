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
            new Sala { Id = 1, NumeroSala = "501", qtdLugares = 40, TemProjetor = true },
            new Sala { Id = 2, NumeroSala = "102", qtdLugares = 30, TemProjetor = false },
            new Sala { Id = 3, NumeroSala = "203", qtdLugares = 20, TemProjetor = true }
        );

        // --- Reservas de Laboratório ---
        modelBuilder.Entity<ReservaLaboratorio>().HasData(
            new ReservaLaboratorio { Id = 1, FkFuncionario = 1, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 26) },
            new ReservaLaboratorio { Id = 2, FkFuncionario = 2, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 26) },
            new ReservaLaboratorio { Id = 3, FkFuncionario = 3, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 28) },
            new ReservaLaboratorio { Id = 4, FkFuncionario = 4, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 29) },
            new ReservaLaboratorio { Id = 5, FkFuncionario = 1, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 30) },
            new ReservaLaboratorio { Id = 6, FkFuncionario = 2, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 8, 31) },
            new ReservaLaboratorio { Id = 7, FkFuncionario = 3, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 1) },
            new ReservaLaboratorio { Id = 8, FkFuncionario = 4, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 2) },
            new ReservaLaboratorio { Id = 9, FkFuncionario = 1, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 3) },
            new ReservaLaboratorio { Id = 10, FkFuncionario = 2, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 4) },
            new ReservaLaboratorio { Id = 11, FkFuncionario = 3, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 5) },
            new ReservaLaboratorio { Id = 12, FkFuncionario = 4, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 6) },
            new ReservaLaboratorio { Id = 13, FkFuncionario = 1, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 7) },
            new ReservaLaboratorio { Id = 14, FkFuncionario = 2, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 8) },
            new ReservaLaboratorio { Id = 15, FkFuncionario = 3, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 9) },
            new ReservaLaboratorio { Id = 16, FkFuncionario = 4, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 10) },
            new ReservaLaboratorio { Id = 17, FkFuncionario = 1, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 11) },
            new ReservaLaboratorio { Id = 18, FkFuncionario = 2, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 12) },
            new ReservaLaboratorio { Id = 19, FkFuncionario = 3, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 13) },
            new ReservaLaboratorio { Id = 20, FkFuncionario = 4, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 9, 14) },
            new ReservaLaboratorio { Id = 21, FkFuncionario = 1, FkLaboratorio = 3, DataReserva = new DateOnly(2025, 9, 15) },
            new ReservaLaboratorio { Id = 22, FkFuncionario = 2, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 9, 16) }
        );

        // --- Reservas de Notebook ---
        modelBuilder.Entity<ReservaNotebook>().HasData(
            new ReservaNotebook { Id = 1, FkFuncionario = 3, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 25) },
            new ReservaNotebook { Id = 2, FkFuncionario = 1, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 26) },
            new ReservaNotebook { Id = 3, FkFuncionario = 2, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 27) },
            new ReservaNotebook { Id = 4, FkFuncionario = 4, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 28) },
            new ReservaNotebook { Id = 5, FkFuncionario = 1, FkNotebook = 2, DataReserva = new DateOnly(2025, 8, 29) },
            new ReservaNotebook { Id = 6, FkFuncionario = 2, FkNotebook = 3, DataReserva = new DateOnly(2025, 8, 30) },
            new ReservaNotebook { Id = 7, FkFuncionario = 3, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 31) },
            new ReservaNotebook { Id = 8, FkFuncionario = 4, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 1) },
            new ReservaNotebook { Id = 9, FkFuncionario = 1, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 2) },
            new ReservaNotebook { Id = 10, FkFuncionario = 2, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 3) },
            new ReservaNotebook { Id = 11, FkFuncionario = 3, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 4) },
            new ReservaNotebook { Id = 12, FkFuncionario = 4, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 5) },
            new ReservaNotebook { Id = 13, FkFuncionario = 1, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 6) },
            new ReservaNotebook { Id = 14, FkFuncionario = 2, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 7) },
            new ReservaNotebook { Id = 15, FkFuncionario = 3, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 8) },
            new ReservaNotebook { Id = 16, FkFuncionario = 4, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 9) },
            new ReservaNotebook { Id = 17, FkFuncionario = 1, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 10) },
            new ReservaNotebook { Id = 18, FkFuncionario = 2, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 11) },
            new ReservaNotebook { Id = 19, FkFuncionario = 3, FkNotebook = 1, DataReserva = new DateOnly(2025, 9, 12) },
            new ReservaNotebook { Id = 20, FkFuncionario = 4, FkNotebook = 2, DataReserva = new DateOnly(2025, 9, 13) },
            new ReservaNotebook { Id = 21, FkFuncionario = 1, FkNotebook = 3, DataReserva = new DateOnly(2025, 9, 14) }
        );

        // --- Reservas de Sala ---
        modelBuilder.Entity<ReservaSala>().HasData(
            new ReservaSala { Id = 1, FkFuncionario = 1, FkSala = 1, DataReserva = new DateOnly(2025, 8, 27) },
            new ReservaSala { Id = 2, FkFuncionario = 2, FkSala = 2, DataReserva = new DateOnly(2025, 8, 28) },
            new ReservaSala { Id = 3, FkFuncionario = 3, FkSala = 3, DataReserva = new DateOnly(2025, 8, 29) },
            new ReservaSala { Id = 4, FkFuncionario = 4, FkSala = 1, DataReserva = new DateOnly(2025, 8, 30) },
            new ReservaSala { Id = 5, FkFuncionario = 1, FkSala = 2, DataReserva = new DateOnly(2025, 8, 31) },
            new ReservaSala { Id = 6, FkFuncionario = 2, FkSala = 3, DataReserva = new DateOnly(2025, 9, 1) },
            new ReservaSala { Id = 7, FkFuncionario = 3, FkSala = 1, DataReserva = new DateOnly(2025, 9, 2) },
            new ReservaSala { Id = 8, FkFuncionario = 4, FkSala = 2, DataReserva = new DateOnly(2025, 9, 3) },
            new ReservaSala { Id = 9, FkFuncionario = 1, FkSala = 3, DataReserva = new DateOnly(2025, 9, 4) },
            new ReservaSala { Id = 10, FkFuncionario = 2, FkSala = 1, DataReserva = new DateOnly(2025, 9, 5) },
            new ReservaSala { Id = 11, FkFuncionario = 3, FkSala = 2, DataReserva = new DateOnly(2025, 9, 6) },
            new ReservaSala { Id = 12, FkFuncionario = 4, FkSala = 3, DataReserva = new DateOnly(2025, 9, 7) },
            new ReservaSala { Id = 13, FkFuncionario = 1, FkSala = 1, DataReserva = new DateOnly(2025, 9, 8) },
            new ReservaSala { Id = 14, FkFuncionario = 2, FkSala = 2, DataReserva = new DateOnly(2025, 9, 9) },
            new ReservaSala { Id = 15, FkFuncionario = 3, FkSala = 3, DataReserva = new DateOnly(2025, 9, 10) },
            new ReservaSala { Id = 16, FkFuncionario = 4, FkSala = 1, DataReserva = new DateOnly(2025, 9, 11) },
            new ReservaSala { Id = 17, FkFuncionario = 1, FkSala = 2, DataReserva = new DateOnly(2025, 9, 12) },
            new ReservaSala { Id = 18, FkFuncionario = 2, FkSala = 3, DataReserva = new DateOnly(2025, 9, 13) },
            new ReservaSala { Id = 19, FkFuncionario = 3, FkSala = 1, DataReserva = new DateOnly(2025, 9, 14) },
            new ReservaSala { Id = 20, FkFuncionario = 4, FkSala = 2, DataReserva = new DateOnly(2025, 9, 15) },
            new ReservaSala { Id = 21, FkFuncionario = 1, FkSala = 3, DataReserva = new DateOnly(2025, 9, 16) }
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

