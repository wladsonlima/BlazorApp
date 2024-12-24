using BlazorApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Infra.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações adicionais, como mapeamentos de entidades
        base.OnModelCreating(modelBuilder);
    }
}