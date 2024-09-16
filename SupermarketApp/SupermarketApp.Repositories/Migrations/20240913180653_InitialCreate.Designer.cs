﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupermarketApp.Repositories.EfCore;

#nullable disable

namespace SupermarketApp.Repositories.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240913180653_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SupermarketApp.Entities.Entities.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("SupermarketApp.Entities.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MarketId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RayonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MarketId");

                    b.HasIndex("RayonId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SupermarketApp.Entities.Entities.Rayon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MarketId")
                        .HasColumnType("int");

                    b.Property<int>("RayonType")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MarketId");

                    b.ToTable("Rayons");
                });

            modelBuilder.Entity("SupermarketApp.Entities.Entities.Product", b =>
                {
                    b.HasOne("SupermarketApp.Entities.Entities.Market", "Market")
                        .WithMany("Products")
                        .HasForeignKey("MarketId");

                    b.HasOne("SupermarketApp.Entities.Entities.Rayon", "Rayon")
                        .WithMany("Products")
                        .HasForeignKey("RayonId");

                    b.Navigation("Market");

                    b.Navigation("Rayon");
                });

            modelBuilder.Entity("SupermarketApp.Entities.Entities.Rayon", b =>
                {
                    b.HasOne("SupermarketApp.Entities.Entities.Market", "Market")
                        .WithMany("Rayons")
                        .HasForeignKey("MarketId");

                    b.Navigation("Market");
                });

            modelBuilder.Entity("SupermarketApp.Entities.Entities.Market", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Rayons");
                });

            modelBuilder.Entity("SupermarketApp.Entities.Entities.Rayon", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
