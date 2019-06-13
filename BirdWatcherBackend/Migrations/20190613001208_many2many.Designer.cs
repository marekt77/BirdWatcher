﻿// <auto-generated />
using System;
using BirdWatcherBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BirdWatcherBackend.Migrations
{
    [DbContext(typeof(BirdWatcherContext))]
    [Migration("20190613001208_many2many")]
    partial class many2many
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BirdWatcherBackend.Models.Bird", b =>
                {
                    b.Property<long>("BirdID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExamplePicture");

                    b.Property<string>("Name");

                    b.HasKey("BirdID");

                    b.ToTable("Birds");
                });

            modelBuilder.Entity("BirdWatcherBackend.Models.BirdLog", b =>
                {
                    b.Property<long>("BirdLogID")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Location_latitude");

                    b.Property<string>("Picture");

                    b.Property<float>("Temperature");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("UserGUID");

                    b.Property<float>("location_longitude");

                    b.HasKey("BirdLogID");

                    b.ToTable("BirdLog");
                });

            modelBuilder.Entity("BirdWatcherBackend.Models.BirdLogBird", b =>
                {
                    b.Property<long>("BirdID");

                    b.Property<long>("BirdLogID");

                    b.HasKey("BirdID", "BirdLogID");

                    b.HasIndex("BirdLogID");

                    b.ToTable("BirdLogBird");
                });

            modelBuilder.Entity("BirdWatcherBackend.Models.devTempLight", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("PhotoresistorValue");

                    b.Property<float>("Temperature");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("devTempLight");
                });

            modelBuilder.Entity("BirdWatcherBackend.Models.BirdLogBird", b =>
                {
                    b.HasOne("BirdWatcherBackend.Models.Bird", "Bird")
                        .WithMany("BirdLogBird")
                        .HasForeignKey("BirdID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BirdWatcherBackend.Models.BirdLog", "BirdLog")
                        .WithMany("BirdLogBird")
                        .HasForeignKey("BirdLogID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
