using System.Diagnostics.CodeAnalysis;
using LearnCraft.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearnCraft.Repository;

[ExcludeFromCodeCoverage]
public class CachorroContext : DbContext
{
    public CachorroContext(DbContextOptions<CachorroContext> options) : base(options)
    {
    }

    public DbSet<Cachorro> Cachorros { get; set; }

}
