﻿// <auto-generated />
using System;
using HSPExpenseTracker.DAL.Concreate.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HSPExpenseTracker.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HSPExpenseTracker.Entities.Models.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("HSPExpenseTracker.Entities.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 2L,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6060),
                            Name = "Sağlık Harcaması",
                            RecordDate = new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6061)
                        },
                        new
                        {
                            Id = 3L,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6064),
                            Name = "Okul Masrafları",
                            RecordDate = new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6064)
                        },
                        new
                        {
                            Id = 4L,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6066),
                            Name = "Eğlence",
                            RecordDate = new DateTime(2023, 10, 2, 6, 50, 28, 632, DateTimeKind.Utc).AddTicks(6066)
                        });
                });

            modelBuilder.Entity("HSPExpenseTracker.Entities.Models.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("numeric(18,2)");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("HSPExpenseTracker.Entities.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HSPExpenseTracker.Entities.Models.Account", b =>
                {
                    b.HasOne("HSPExpenseTracker.Entities.Models.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HSPExpenseTracker.Entities.Models.Transaction", b =>
                {
                    b.HasOne("HSPExpenseTracker.Entities.Models.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HSPExpenseTracker.Entities.Models.Category", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("HSPExpenseTracker.Entities.Models.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
