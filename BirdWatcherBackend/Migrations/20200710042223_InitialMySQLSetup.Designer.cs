﻿// <auto-generated />
using System;
using BirdWatcherBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BirdWatcherBackend.Migrations
{
    [DbContext(typeof(BirdWatcherContext))]
    [Migration("20200710042223_InitialMySQLSetup")]
    partial class InitialMySQLSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BirdWatcherBackend.Models.Bird", b =>
                {
                    b.Property<long>("BirdID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ExamplePicture")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("BirdID");

                    b.ToTable("Birds");
                });

            modelBuilder.Entity("BirdWatcherBackend.Models.BirdLog", b =>
                {
                    b.Property<long>("BirdLogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<float>("Location_latitude")
                        .HasColumnType("float");

                    b.Property<string>("Picture")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserGUID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("location_longitude")
                        .HasColumnType("float");

                    b.HasKey("BirdLogID");

                    b.ToTable("BirdLog");
                });

            modelBuilder.Entity("BirdWatcherBackend.Models.BirdLogBird", b =>
                {
                    b.Property<long>("BirdID")
                        .HasColumnType("bigint");

                    b.Property<long>("BirdLogID")
                        .HasColumnType("bigint");

                    b.HasKey("BirdID", "BirdLogID");

                    b.HasIndex("BirdLogID");

                    b.ToTable("BirdLogBird");
                });

            modelBuilder.Entity("BirdWatcherBackend.Models.devTempLight", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<float>("PhotoresistorValue")
                        .HasColumnType("float");

                    b.Property<float>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("devTempLight");
                });

            modelBuilder.Entity("BirdWatcherBackend.Models.BirdLogBird", b =>
                {
                    b.HasOne("BirdWatcherBackend.Models.Bird", "Bird")
                        .WithMany("BirdLogBird")
                        .HasForeignKey("BirdID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdWatcherBackend.Models.BirdLog", "BirdLog")
                        .WithMany("BirdLogBird")
                        .HasForeignKey("BirdLogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
