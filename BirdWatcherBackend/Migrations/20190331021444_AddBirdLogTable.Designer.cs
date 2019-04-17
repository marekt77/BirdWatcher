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
    [Migration("20190331021444_AddBirdLogTable")]
    partial class AddBirdLogTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("BirdWatcher.Models.Bird", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BirdType");

                    b.Property<string>("ImageFile");

                    b.HasKey("Id");

                    b.ToTable("Birds");
                });

            modelBuilder.Entity("BirdWatcher.Models.BirdLog", b =>
                {
                    b.Property<long>("BirdLogId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("BirdId");

                    b.Property<int>("PhotoresistorValue");

                    b.Property<int>("Tempurature");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("BirdLogId");

                    b.HasIndex("BirdId");

                    b.ToTable("BirdLog");
                });

            modelBuilder.Entity("BirdWatcher.Models.BirdLog", b =>
                {
                    b.HasOne("BirdWatcher.Models.Bird", "Bird")
                        .WithMany()
                        .HasForeignKey("BirdId");
                });
#pragma warning restore 612, 618
        }
    }
}