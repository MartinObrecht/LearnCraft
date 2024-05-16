using System.Diagnostics.CodeAnalysis;
using LearnCraft.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearnCraft.Repository;

[ExcludeFromCodeCoverage]
public class CachorroDbContext : DbContext
{
    public CachorroDbContext(DbContextOptions<CachorroDbContext> options) : base(options)
    {
    }

    public DbSet<Cachorro> Cachorros { get; set; }

}
