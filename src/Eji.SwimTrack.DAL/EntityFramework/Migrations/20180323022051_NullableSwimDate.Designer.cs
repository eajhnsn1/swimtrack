﻿// <auto-generated />
using Eji.SwimTrack.DAL.EntityFramework;
using Eji.SwimTrack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Eji.SwimTrack.DAL.EntityFramework.Migrations
{
    [DbContext(typeof(SwimTrackContext))]
    [Migration("20180323022051_NullableSwimDate")]
    partial class NullableSwimDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eji.SwimTrack.Models.Entities.Swim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Completed");

                    b.Property<int>("Distance");

                    b.Property<int>("DistanceUnits");

                    b.Property<bool>("ShortCourse");

                    b.Property<DateTime?>("SwimDate");

                    b.Property<decimal?>("TimeSeconds")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Swims");
                });
#pragma warning restore 612, 618
        }
    }
}