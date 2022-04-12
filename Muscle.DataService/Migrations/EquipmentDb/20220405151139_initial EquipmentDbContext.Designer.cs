﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Muscle.DataService.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Muscle.DataService.Migrations.EquipmentDb
{
    [DbContext(typeof(EquipmentDbContext))]
    [Migration("20220405151139_initial EquipmentDbContext")]
    partial class initialEquipmentDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DirectionHall", b =>
                {
                    b.Property<int>("DirectionsId")
                        .HasColumnType("integer");

                    b.Property<int>("HallsId")
                        .HasColumnType("integer");

                    b.HasKey("DirectionsId", "HallsId");

                    b.HasIndex("HallsId");

                    b.ToTable("DirectionHall");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Name")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.Direction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.EquipmentHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("integer");

                    b.Property<int?>("HallId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("HallId");

                    b.ToTable("EquipmentHalls");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("DirectionHall", b =>
                {
                    b.HasOne("Muscle.Entities.DbSet.DbSetForEquipmentDb.Direction", null)
                        .WithMany()
                        .HasForeignKey("DirectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Muscle.Entities.DbSet.DbSetForEquipmentDb.Hall", null)
                        .WithMany()
                        .HasForeignKey("HallsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.Direction", b =>
                {
                    b.HasOne("Muscle.Entities.DbSet.DbSetForEquipmentDb.Building", "Building")
                        .WithMany("Directions")
                        .HasForeignKey("BuildingId");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.EquipmentHall", b =>
                {
                    b.HasOne("Muscle.Entities.DbSet.DbSetForEquipmentDb.Equipment", "Equipment")
                        .WithMany("EquipmentHalls")
                        .HasForeignKey("EquipmentId");

                    b.HasOne("Muscle.Entities.DbSet.DbSetForEquipmentDb.Hall", "Hall")
                        .WithMany("EquipmentHalls")
                        .HasForeignKey("HallId");

                    b.Navigation("Equipment");

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.Hall", b =>
                {
                    b.HasOne("Muscle.Entities.DbSet.DbSetForEquipmentDb.Building", "Building")
                        .WithMany("Halls")
                        .HasForeignKey("BuildingId");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.Building", b =>
                {
                    b.Navigation("Directions");

                    b.Navigation("Halls");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.Equipment", b =>
                {
                    b.Navigation("EquipmentHalls");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForEquipmentDb.Hall", b =>
                {
                    b.Navigation("EquipmentHalls");
                });
#pragma warning restore 612, 618
        }
    }
}
