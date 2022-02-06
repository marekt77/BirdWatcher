﻿// <auto-generated />
using System;
using BirdWatcherWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BirdWatcherWeb.Migrations
{
    [DbContext(typeof(BirdWatcherContext))]
    [Migration("20220206053310_SunTrackUpdate")]
    partial class SunTrackUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("BirdWatcherWeb.Models.Bird", b =>
                {
                    b.Property<long>("BirdID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("ExamplePicture")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("BirdID");

                    b.ToTable("Birds");
                });

            modelBuilder.Entity("BirdWatcherWeb.Models.BirdLog", b =>
                {
                    b.Property<long>("BirdLogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<float>("Location_latitude")
                        .HasColumnType("float");

                    b.Property<string>("Picture")
                        .HasColumnType("longtext");

                    b.Property<float>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserGUID")
                        .HasColumnType("longtext");

                    b.Property<float>("location_longitude")
                        .HasColumnType("float");

                    b.HasKey("BirdLogID");

                    b.ToTable("BirdLog");
                });

            modelBuilder.Entity("BirdWatcherWeb.Models.BirdLogBird", b =>
                {
                    b.Property<long>("BirdID")
                        .HasColumnType("bigint");

                    b.Property<long>("BirdLogID")
                        .HasColumnType("bigint");

                    b.HasKey("BirdID", "BirdLogID");

                    b.HasIndex("BirdLogID");

                    b.ToTable("BirdLogBird");
                });

            modelBuilder.Entity("BirdWatcherWeb.Models.SunTrack", b =>
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

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SunTrack");
                });

            modelBuilder.Entity("BirdWatcherWeb.Models.BirdLogBird", b =>
                {
                    b.HasOne("BirdWatcherWeb.Models.Bird", "Bird")
                        .WithMany("BirdLogBird")
                        .HasForeignKey("BirdID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdWatcherWeb.Models.BirdLog", "BirdLog")
                        .WithMany("BirdLogBird")
                        .HasForeignKey("BirdLogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bird");

                    b.Navigation("BirdLog");
                });

            modelBuilder.Entity("BirdWatcherWeb.Models.Bird", b =>
                {
                    b.Navigation("BirdLogBird");
                });

            modelBuilder.Entity("BirdWatcherWeb.Models.BirdLog", b =>
                {
                    b.Navigation("BirdLogBird");
                });
#pragma warning restore 612, 618
        }
    }
}
