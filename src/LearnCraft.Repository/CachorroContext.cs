using LearnCraft.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearnCraft.Repository;

public class CachorroContext : DbContext
{
    public CachorroContext(DbContextOptions<CachorroContext> options) : base(options)
    {
    }

    public DbSet<Cachorro> Cachorros { get; set; }

}
