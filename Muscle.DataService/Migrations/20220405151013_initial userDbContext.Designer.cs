﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Muscle.DataService.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Muscle.DataService.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20220405151013_initial userDbContext")]
    partial class initialuserDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CoachId")
                        .HasColumnType("integer");

                    b.Property<string>("Descr")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.Role", b =>
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

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.SubscriptionUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("StartData")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("UserId");

                    b.ToTable("SubscriptionUsers");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.Coach", b =>
                {
                    b.HasBaseType("Muscle.Entities.DbSet.DbSetForUserDb.User");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DirectionId")
                        .HasColumnType("integer");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.Document", b =>
                {
                    b.HasOne("Muscle.Entities.DbSet.DbSetForUserDb.Coach", "Coach")
                        .WithMany("Documents")
                        .HasForeignKey("CoachId");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.SubscriptionUser", b =>
                {
                    b.HasOne("Muscle.Entities.DbSet.DbSetForUserDb.Subscription", "Subscription")
                        .WithMany("SubscriptionsUser")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Muscle.Entities.DbSet.DbSetForUserDb.User", "User")
                        .WithMany("SubscriptionUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.User", b =>
                {
                    b.HasOne("Muscle.Entities.DbSet.DbSetForUserDb.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.Coach", b =>
                {
                    b.HasOne("Muscle.Entities.DbSet.DbSetForUserDb.User", null)
                        .WithOne()
                        .HasForeignKey("Muscle.Entities.DbSet.DbSetForUserDb.Coach", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.Subscription", b =>
                {
                    b.Navigation("SubscriptionsUser");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.User", b =>
                {
                    b.Navigation("SubscriptionUsers");
                });

            modelBuilder.Entity("Muscle.Entities.DbSet.DbSetForUserDb.Coach", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
