using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options )
{
    public DbSet<Product> Products { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        //Repositoy içindeki tüm IEntityTypeConfiguration implement eden classları uygular

        base.OnModelCreating(modelBuilder);
    }
}
