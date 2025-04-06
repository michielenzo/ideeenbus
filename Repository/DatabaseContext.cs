namespace ideeenbus.Repository;

using Microsoft.EntityFrameworkCore;
using System;
using ideeenbus.Repository.Entity;

public class DatabaseContext : DbContext
{
    public string DbPath { get; }

    public DbSet<IdeeEntity> Ideeen { get; set; }
    public DbSet<CategorieEntity> Categories { get; set; }
    public DbSet<CategoryInIdeeEntity> CategorieInIdeeEntities { get; set; }

    public DatabaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "ideeenbus.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdeeEntity>()
            .HasMany(e => e.CategoryEntities)
            .WithMany(e => e.IdeeEntities);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}