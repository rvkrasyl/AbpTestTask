﻿// <auto-generated />
using System;
using AbpDal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AbpDal.Migrations
{
    [DbContext(typeof(AbpExperimentDbContext))]
    [Migration("20230522112905_InitialCreateWith1to1Relationship")]
    partial class InitialCreateWith1to1Relationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AbpDal.Entities.ButtonColorExperimentData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ButtonColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExperimentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId")
                        .IsUnique();

                    b.ToTable("ColorExperiments");
                });

            modelBuilder.Entity("AbpDal.Entities.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeviceToken")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceToken")
                        .IsUnique()
                        .HasFilter("[DeviceToken] IS NOT NULL");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("AbpDal.Entities.PriceExperimentData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExperimentDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Price")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId")
                        .IsUnique();

                    b.ToTable("PriceExperiments");
                });

            modelBuilder.Entity("AbpDal.Entities.ButtonColorExperimentData", b =>
                {
                    b.HasOne("AbpDal.Entities.Device", "Device")
                        .WithOne("ButtonColorExperimentData")
                        .HasForeignKey("AbpDal.Entities.ButtonColorExperimentData", "DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("AbpDal.Entities.PriceExperimentData", b =>
                {
                    b.HasOne("AbpDal.Entities.Device", "Device")
                        .WithOne("PriceExperimentData")
                        .HasForeignKey("AbpDal.Entities.PriceExperimentData", "DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("AbpDal.Entities.Device", b =>
                {
                    b.Navigation("ButtonColorExperimentData");

                    b.Navigation("PriceExperimentData");
                });
#pragma warning restore 612, 618
        }
    }
}