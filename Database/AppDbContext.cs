using Microsoft.EntityFrameworkCore;
using ModStats.API.Models.Minecraft;
using ModStats.API.Models.Mods;
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
    public DbSet<DisplayInfo> ModDisplayInfo { get; set; } = null!;

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
        modelBuilder.Entity<Mod>().HasOne(it => it.Display).WithOne(it => it.Mod).HasForeignKey<DisplayInfo>(it => it.ModId);
    }
}