﻿// <auto-generated />
using System;
using DocAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DocAPI.Migrations
{
    [DbContext(typeof(DocsContext))]
    [Migration("20220626061730_UpdateWebConfig")]
    partial class UpdateWebConfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("DocAPI.Models.Docs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DocsCatalogId")
                        .HasColumnType("TEXT");

                    b.Property<string>("GitSha")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("GitUrl")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Sort")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("UpdatedTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DocsCatalogId");

                    b.ToTable("Docs");
                });

            modelBuilder.Entity("DocAPI.Models.DocsCatalog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("GitSha")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("GitUrl")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sort")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("UpdatedTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("DocsCatalogs");
                });

            modelBuilder.Entity("DocAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Avatar")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("UpdatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DocAPI.Models.WebConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("GithubPAT")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("GithubUser")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<long?>("RepositoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("UpdatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSiteName")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WebConfigs");
                });

            modelBuilder.Entity("DocAPI.Models.Docs", b =>
                {
                    b.HasOne("DocAPI.Models.DocsCatalog", "DocsCatalog")
                        .WithMany("Docs")
                        .HasForeignKey("DocsCatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocsCatalog");
                });

            modelBuilder.Entity("DocAPI.Models.DocsCatalog", b =>
                {
                    b.HasOne("DocAPI.Models.DocsCatalog", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("DocAPI.Models.DocsCatalog", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Docs");
                });
#pragma warning restore 612, 618
        }
    }
}
