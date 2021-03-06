﻿// <auto-generated />
using System;
using Eji.SwimTrack.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Eji.SwimTrack.DAL.EntityFramework.Migrations
{
    [DbContext(typeof(SwimTrackContext))]
    partial class SwimTrackContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eji.SwimTrack.Models.Entities.Swim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completed");

                    b.Property<bool?>("DQ");

                    b.Property<int>("Distance");

                    b.Property<int>("DistanceUnits");

                    b.Property<int?>("EventNumber");

                    b.Property<int?>("Heat");

                    b.Property<bool>("IsRelay");

                    b.Property<int?>("Lane");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ShortCourse");

                    b.Property<int>("Stroke");

                    b.Property<DateTime?>("SwimDate");

                    b.Property<int?>("SwimmerId");

                    b.Property<decimal?>("TimeSeconds")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("SwimmerId");

                    b.ToTable("Swims");
                });

            modelBuilder.Entity("Eji.SwimTrack.Models.Entities.Swimmer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<string>("Nickname")
                        .HasMaxLength(100);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Swimmers");
                });

            modelBuilder.Entity("Eji.SwimTrack.Models.Entities.Swim", b =>
                {
                    b.HasOne("Eji.SwimTrack.Models.Entities.Swimmer", "Swimmer")
                        .WithMany("Swims")
                        .HasForeignKey("SwimmerId");
                });
#pragma warning restore 612, 618
        }
    }
}
