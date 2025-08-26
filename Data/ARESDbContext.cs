using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ARESDbContext : DbContext
{
    public ARESDbContext(DbContextOptions<ARESDbContext> options) : base(options) { }

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
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ARESDB;Trusted_Connection=True;");
        }
    }
}

