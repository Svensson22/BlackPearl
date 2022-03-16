using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlackPearl;

public class BlackPearl : DbContext
{

    public DbSet<PearlList> PearlLists { get; set; }
    public DbSet<Pearl> Pearls { get; set; }
    public string DbPath { get; }

    public BlackPearl()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "BlackPearl.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
