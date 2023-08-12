using Microsoft.EntityFrameworkCore;
using ModStats.API.Models.Histograms;
using ModStats.API.Models.Minecraft;
using ModStats.API.Models.Mods;
using ModStats.API.Models.Mods.Loaders;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ModLoader> ModLoaders { get; set; } = null!;
    
    public DbSet<Platform> Platforms { get; set; } = null!;
    
    public DbSet<McVersion> MinecraftVersions { get; set; } = null!;
    
    public DbSet<Mod> Mods { get; set; } = null!;
    public DbSet<ModMetadata> ModsMetaData { get; set; } = null!;
    public DbSet<ModSupportedPlatform> ModsSupportedPlatforms { get; set; } = null!;
    
    public DbSet<DownloadCountSnapshot> HistDownloadCounts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ModLoader>()
            .HasIndex(it => it.Slug)
            .IsUnique();

        modelBuilder.Entity<ModLoader>().HasData(
            new ModLoader
            {
                Id = new Guid("ea89d266-b6de-493a-b076-8e5e86142375"),
                Slug = "forge",
                Name = "Forge",
            },
            new ModLoader
            {
                Id = new Guid("091297f2-1ecd-45c2-8015-c1a4090d487b"),
                Slug = "fabric",
                Name = "Fabric",
            },
            new ModLoader
            {
                Id = new Guid("f92fbda0-a69b-427c-8352-89eeb1772d7d"),
                Slug = "quilt",
                Name = "Quilt",
            },
            new ModLoader
            {
                Id = new Guid("e437a393-d4b4-4d87-861b-2a47227c12df"),
                Slug = "neoforge",
                Name = "NeoForge",
            }
        );

        modelBuilder.Entity<Platform>()
            .HasIndex(it => it.Slug)
            .IsUnique();

        modelBuilder.Entity<Platform>().HasData(
            new Platform
            {
                Id = new Guid("ca1af69d-0961-491f-9fc0-f633313c8eab"),
                Slug = "curseforge",
                Name = "CurseForge",
            },
            new Platform
            {
                Id = new Guid("b6912369-4d45-422a-a238-b13983e9c435"),
                Slug = "modrinth",
                Name = "Modrinth",
            }
        );
        
        modelBuilder.Entity<Mod>().HasIndex(it => it.Slug).IsUnique();
        modelBuilder.Entity<ModMetadata>().HasOne(it => it.Mod).WithOne(it => it.Meta).HasForeignKey<ModMetadata>(it => it.ModId).IsRequired();
        modelBuilder.Entity<ModSupportedPlatform>().HasOne(it => it.Platform).WithMany().HasForeignKey(it => it.PlatformId).IsRequired();
        modelBuilder.Entity<ModSupportedPlatform>().HasOne(it => it.Mod).WithMany(it => it.PlatformIDs).HasForeignKey(it => it.ModId);
        modelBuilder.Entity<ModSupportedPlatform>().HasKey(it => new {it.PlatformId, it.PlatformKey});

        modelBuilder.Entity<DownloadCountSnapshot>().HasOne(it => it.Mod).WithMany(it => it.HistoricalDownloadData).HasForeignKey(it => it.ModId).IsRequired();
        modelBuilder.Entity<DownloadCountSnapshot>().HasOne(it => it.Platform).WithMany().HasForeignKey(it => it.PlatformId).IsRequired();
    }
}