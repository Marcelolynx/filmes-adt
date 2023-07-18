using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class ManagerContext : DbContext
{
    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
    {
    }
    
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Data Source=localhost;Database=filmes_db;User Id=sa;Password=Mco02Jgp!;TrustServerCertificate=True;Encrypt=false");
}