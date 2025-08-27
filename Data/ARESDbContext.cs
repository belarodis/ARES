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

        modelBuilder.Entity<ReservaLaboratorio>().HasData(
            new ReservaLaboratorio { Id = 1, FkFuncionario = 1, FkLaboratorio = 1, DataReserva = new DateOnly(2025, 8, 26) },
            new ReservaLaboratorio { Id = 2, FkFuncionario = 2, FkLaboratorio = 2, DataReserva = new DateOnly(2025, 8, 26) }
        );

        modelBuilder.Entity<ReservaNotebook>().HasData(
            new ReservaNotebook { Id = 1, FkFuncionario = 3, FkNotebook = 1, DataReserva = new DateOnly(2025, 8, 25) }
        );

        modelBuilder.Entity<ReservaSala>().HasData(
            new ReservaSala { Id = 1, FkFuncionario = 1, FkSala = 1, DataReserva = new DateOnly(2025, 8, 27) }
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

