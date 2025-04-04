namespace ideeenbus.Service;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ideeenbus.Service.Dao;

public class IdeeEntityContext : DbContext
{
    public DbSet<IdeeEntity> Ideeen { get; set; }

    public string DbPath { get; }

    public IdeeEntityContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "ideeenbus.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}