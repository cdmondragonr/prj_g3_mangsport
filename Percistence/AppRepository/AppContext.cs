using Domain;
using Microsoft.EntityFrameworkCore;

namespace Percistence;

public class AppContext:DbContext
{
    //Atributes DdSet to create entities in to DB

    public DbSet<Arbitro> Arbitros {get; set;}
    public DbSet<Colegio> Colegio {get; set;}
    public DbSet<Deportista> Deportistas {get; set;}
    public DbSet<Entrenador> Entrenadores {get; set;}
    public DbSet<Equipo> Equipos {get; set; }
    public DbSet<Escenario> Escenarios {get; set;}
    public DbSet<Municipio> Municipios {get; set;}
    public DbSet<Patrocinador> Patrocinadores {get; set;}
    public DbSet<Torneo> Torneos {get; set;}
    public DbSet<TorneoEquipo> TorneoEquipos {get; set;}

    //Conexion con la base de datos

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=MangSport");
        }
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TorneoEquipo>()
            .HasKey(TE => new { TE.EquipoId, TE.TorneoId });
    }
}