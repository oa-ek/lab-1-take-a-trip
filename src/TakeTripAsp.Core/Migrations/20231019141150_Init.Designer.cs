﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TakeTripAsp.Core.Context;

#nullable disable

namespace TakeTripAsp.Core.Migrations
{
    [DbContext(typeof(TakeTripAspDbContext))]
    [Migration("20231019141150_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryTour", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ToursId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ToursId");

                    b.HasIndex("ToursId");

                    b.ToTable("CategoryTour");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ad0238cf-6b66-4473-a805-1ff022d7e7ca",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "cda07bf4-86b9-4bc9-87c6-614de75c910e",
                            Name = "seller",
                            NormalizedName = "SELLER"
                        },
                        new
                        {
                            Id = "e46d5156-c5bb-4e10-9d7d-13fd6375c0ad",
                            Name = "client",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "987266f1-f159-4c44-b6e8-39f11b22c172",
                            RoleId = "ad0238cf-6b66-4473-a805-1ff022d7e7ca"
                        },
                        new
                        {
                            UserId = "7a90e5ea-59b7-4198-a62d-7b15d27e64fd",
                            RoleId = "cda07bf4-86b9-4bc9-87c6-614de75c910e"
                        },
                        new
                        {
                            UserId = "ebb5f25f-1df6-494b-8a58-1d6848582a8f",
                            RoleId = "e46d5156-c5bb-4e10-9d7d-13fd6375c0ad"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "987266f1-f159-4c44-b6e8-39f11b22c172",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f70182f2-30e3-4f17-9a4c-bfd9b145bdca",
                            CoverPath = "\\img\\user\\user.jpg",
                            DateOfBirth = new DateTime(1998, 10, 19, 17, 11, 49, 960, DateTimeKind.Local).AddTicks(7300),
                            Email = "admin@taketrip.com",
                            EmailConfirmed = true,
                            FirstName = "Mariia",
                            LastName = "Kovalchuk",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@TAKETRIP.COM",
                            NormalizedUserName = "MARIIA",
                            PasswordHash = "AQAAAAIAAYagAAAAEPEqXI8aCKccJmKZTWbU9PmF7DrDZiZi9UPXoywOLpQIChrXb1fc+KMCayOtZ/xYhA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "21a4c821-bae9-4cd7-8b6a-ce1bca0d2067",
                            TwoFactorEnabled = false,
                            UserName = "Mariia"
                        },
                        new
                        {
                            Id = "7a90e5ea-59b7-4198-a62d-7b15d27e64fd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1bf2a2cc-0e80-46c1-a769-11276277bac5",
                            CoverPath = "\\img\\user\\user.jpg",
                            DateOfBirth = new DateTime(1998, 10, 19, 17, 11, 50, 24, DateTimeKind.Local).AddTicks(9709),
                            Email = "seller@taketrip.com",
                            EmailConfirmed = true,
                            FirstName = "Ivan",
                            LastName = "Petrovych",
                            LockoutEnabled = false,
                            NormalizedEmail = "SELLER@TAKETRIP.COM",
                            NormalizedUserName = "IVAN",
                            PasswordHash = "AQAAAAIAAYagAAAAENlcVQ8mtaIYIEQQXrBY61wpFCdnjLib4vekp5gWcLZCBzc0yuyHVhARvMII1NnZcw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2f1da337-965a-498e-8ff5-62181d8ab78b",
                            TwoFactorEnabled = false,
                            UserName = "Ivan"
                        },
                        new
                        {
                            Id = "ebb5f25f-1df6-494b-8a58-1d6848582a8f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a25e8783-4eb0-494a-b1b7-580d8219cd24",
                            CoverPath = "\\img\\user\\user.jpg",
                            DateOfBirth = new DateTime(1998, 10, 19, 17, 11, 50, 94, DateTimeKind.Local).AddTicks(7508),
                            Email = "client@taketrip.com",
                            EmailConfirmed = true,
                            FirstName = "Oleksandr",
                            LastName = "Shevchenko",
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENT@TAKETRIP.COM",
                            NormalizedUserName = "OLEKSANDR",
                            PasswordHash = "AQAAAAIAAYagAAAAEFvnwUvsLMm7p1+eAczjukfBAukUxx2xNShNcF6S5u4BRiZJFdHMw5FPl6I04c0N6Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0b400a64-426c-4109-82b9-ccb20249b1dd",
                            TwoFactorEnabled = false,
                            UserName = "Oleksandr"
                        });
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.BookingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BookingStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookingsStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookingStatusName = "Не заброньовано"
                        },
                        new
                        {
                            Id = 2,
                            BookingStatusName = "Заброньовано"
                        },
                        new
                        {
                            Id = 3,
                            BookingStatusName = "Оплачено"
                        },
                        new
                        {
                            Id = 4,
                            BookingStatusName = "Скасовано"
                        });
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Bookings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingStatusId")
                        .HasColumnType("int");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsFullPayment")
                        .HasColumnType("bit");

                    b.Property<decimal>("Payment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingStatusId");

                    b.HasIndex("ClientId");

                    b.HasIndex("TourId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Екстримальний відпочинок"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Активний"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Пасивний"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Спортивний"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Пляжний"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Гірський"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Шопінг"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Лікувально-оздоровчий"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Гастрономічний"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Зелений"
                        });
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Reviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TourId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.SelectedTour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TourId");

                    b.ToTable("SelectedTour");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "Активний"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "Перенесений"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Скасований"
                        });
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BookingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FullPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("CategoryTour", b =>
                {
                    b.HasOne("TakeTripAsp.Core.Entity.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeTripAsp.Core.Entity.Tour", null)
                        .WithMany()
                        .HasForeignKey("ToursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TakeTripAsp.Core.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TakeTripAsp.Core.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeTripAsp.Core.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TakeTripAsp.Core.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Bookings", b =>
                {
                    b.HasOne("TakeTripAsp.Core.Entity.BookingStatus", "BookingStatus")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeTripAsp.Core.Entity.AppUser", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeTripAsp.Core.Entity.Tour", "Tour")
                        .WithMany("Bookings")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingStatus");

                    b.Navigation("Client");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Profile", b =>
                {
                    b.HasOne("TakeTripAsp.Core.Entity.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Reviews", b =>
                {
                    b.HasOne("TakeTripAsp.Core.Entity.AppUser", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeTripAsp.Core.Entity.Tour", "Tour")
                        .WithMany("Reviews")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.SelectedTour", b =>
                {
                    b.HasOne("TakeTripAsp.Core.Entity.AppUser", "Client")
                        .WithMany("Tours")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeTripAsp.Core.Entity.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Tour", b =>
                {
                    b.HasOne("TakeTripAsp.Core.Entity.Status", "Status")
                        .WithMany("Tours")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.AppUser", b =>
                {
                    b.Navigation("Tours");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.BookingStatus", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Status", b =>
                {
                    b.Navigation("Tours");
                });

            modelBuilder.Entity("TakeTripAsp.Core.Entity.Tour", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
