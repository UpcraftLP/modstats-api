﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModStats.API.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ModStats.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230809124058_ModLoaders")]
    partial class ModLoaders
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ModStats.API.Models.Minecraft.McVersion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<int>("ComplianceLevel")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "complianceLevel");

                    b.Property<Guid?>("ModId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ReleaseTime")
                        .HasColumnType("timestamp with time zone")
                        .HasAnnotation("Relational:JsonPropertyName", "releaseTime");

                    b.Property<string>("Sha1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "sha1");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone")
                        .HasAnnotation("Relational:JsonPropertyName", "time");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "type");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "url");

                    b.HasKey("Id");

                    b.HasIndex("ModId");

                    b.ToTable("mc_versions");
                });

            modelBuilder.Entity("ModStats.API.Models.Mods.DisplayInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ModId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ModId")
                        .IsUnique();

                    b.ToTable("mod_display_info");
                });

            modelBuilder.Entity("ModStats.API.Models.Mods.Mod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("mods");
                });

            modelBuilder.Entity("ModStats.API.Models.Mods.ModLoader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("mod_loaders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ea89d266-b6de-493a-b076-8e5e86142375"),
                            CreatedAt = new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(7493),
                            Name = "Forge",
                            Slug = "forge"
                        },
                        new
                        {
                            Id = new Guid("091297f2-1ecd-45c2-8015-c1a4090d487b"),
                            CreatedAt = new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(7516),
                            Name = "Fabric",
                            Slug = "fabric"
                        },
                        new
                        {
                            Id = new Guid("f92fbda0-a69b-427c-8352-89eeb1772d7d"),
                            CreatedAt = new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(7534),
                            Name = "Quilt",
                            Slug = "quilt"
                        },
                        new
                        {
                            Id = new Guid("e437a393-d4b4-4d87-861b-2a47227c12df"),
                            CreatedAt = new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(7537),
                            Name = "NeoForge",
                            Slug = "neoforge"
                        });
                });

            modelBuilder.Entity("ModStats.API.Models.Platforms.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ModId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ModId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("platforms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ca1af69d-0961-491f-9fc0-f633313c8eab"),
                            CreatedAt = new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(8062),
                            Name = "CurseForge",
                            Slug = "curseforge"
                        },
                        new
                        {
                            Id = new Guid("b6912369-4d45-422a-a238-b13983e9c435"),
                            CreatedAt = new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(8069),
                            Name = "Modrinth",
                            Slug = "modrinth"
                        });
                });

            modelBuilder.Entity("ModStats.API.Models.Minecraft.McVersion", b =>
                {
                    b.HasOne("ModStats.API.Models.Mods.Mod", null)
                        .WithMany("SupportedVersions")
                        .HasForeignKey("ModId");
                });

            modelBuilder.Entity("ModStats.API.Models.Mods.DisplayInfo", b =>
                {
                    b.HasOne("ModStats.API.Models.Mods.Mod", "Mod")
                        .WithOne("Display")
                        .HasForeignKey("ModStats.API.Models.Mods.DisplayInfo", "ModId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mod");
                });

            modelBuilder.Entity("ModStats.API.Models.Platforms.Platform", b =>
                {
                    b.HasOne("ModStats.API.Models.Mods.Mod", null)
                        .WithMany("SupportedPlatforms")
                        .HasForeignKey("ModId");
                });

            modelBuilder.Entity("ModStats.API.Models.Mods.Mod", b =>
                {
                    b.Navigation("Display")
                        .IsRequired();

                    b.Navigation("SupportedPlatforms");

                    b.Navigation("SupportedVersions");
                });
#pragma warning restore 612, 618
        }
    }
}
