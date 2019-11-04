﻿// <auto-generated />
using System;
using Cards.Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cards.Core.Migrations
{
    [DbContext(typeof(CardContext))]
    [Migration("20191104085940_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cards.Core.Entities.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSaved")
                        .HasColumnType("bit");

                    b.Property<string>("Meaning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RepeatRateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ModeId");

                    b.HasIndex("RepeatRateId");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Cards.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a06d33df-fbee-4070-b839-65dcf47bac66"),
                            Name = "Word",
                            Sort = 1
                        },
                        new
                        {
                            Id = new Guid("d7f051f2-eb2b-4c9b-be24-b894f4e1ca65"),
                            Name = "Phrase",
                            Sort = 2
                        },
                        new
                        {
                            Id = new Guid("beedfe55-aada-4dc7-98ca-104052972d8b"),
                            Name = "Sentence",
                            Sort = 3
                        });
                });

            modelBuilder.Entity("Cards.Core.Entities.Mode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PrimaryLang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryLang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Modes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("40192768-f4bc-48c4-b396-fde50afd34ed"),
                            PrimaryLang = "En",
                            SecondaryLang = "Fr",
                            Sort = 1
                        },
                        new
                        {
                            Id = new Guid("a437818d-89b6-4ba0-84d0-c8b9eb6856e1"),
                            PrimaryLang = "Fr",
                            SecondaryLang = "En",
                            Sort = 2
                        });
                });

            modelBuilder.Entity("Cards.Core.Entities.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Cards.Core.Entities.RepeatRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RepeatRates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("079a5f79-dd4c-44cc-bd8d-5f9f7ef4e3cb"),
                            Name = "Daily",
                            Sort = 1
                        },
                        new
                        {
                            Id = new Guid("e1e223d6-e72e-445f-b55e-7ba6f1d3af9a"),
                            Name = "Two Days",
                            Sort = 2
                        },
                        new
                        {
                            Id = new Guid("dfe0359c-5c64-47c5-90d9-693110c7e642"),
                            Name = "Three Days",
                            Sort = 3
                        },
                        new
                        {
                            Id = new Guid("96eb9404-2fac-4567-b436-33bbf4fa1b2f"),
                            Name = "Weekly",
                            Sort = 4
                        },
                        new
                        {
                            Id = new Guid("c4c29e70-6504-42e7-acef-f21130e476d9"),
                            Name = "Two Weeks",
                            Sort = 5
                        },
                        new
                        {
                            Id = new Guid("5d2606bf-296e-42b0-8314-f4b76a3a6bdc"),
                            Name = "Monthly",
                            Sort = 6
                        });
                });

            modelBuilder.Entity("Cards.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cards.Core.Entities.Card", b =>
                {
                    b.HasOne("Cards.Core.Entities.Category", "Category")
                        .WithMany("Cards")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cards.Core.Entities.Mode", "Mode")
                        .WithMany("Cards")
                        .HasForeignKey("ModeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cards.Core.Entities.RepeatRate", "RepeatRate")
                        .WithMany("Cards")
                        .HasForeignKey("RepeatRateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cards.Core.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cards.Core.Entities.Note", b =>
                {
                    b.HasOne("Cards.Core.Entities.User", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
