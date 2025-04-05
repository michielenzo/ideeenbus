namespace ideeenbus.Service;

using Microsoft.EntityFrameworkCore;
using System;
using ideeenbus.Service.Entity;

public class DatabaseContext : DbContext
{
    public DbSet<IdeeEntity> Ideeen { get; set; }
    public DbSet<CategorieEntity> Categories { get; set; }
    public DbSet<CategoryInIdeeEntity> CategorieInIdeeEntities { get; set; }

    public string DbPath { get; }

    public DatabaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "ideeenbus.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdeeEntity>()
            .HasMany(e => e.CategoryEntities)
            .WithMany(e => e.IdeeEntities);
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}