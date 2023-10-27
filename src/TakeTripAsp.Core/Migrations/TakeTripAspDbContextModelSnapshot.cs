﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TakeTripAsp.Core.Context;

#nullable disable

namespace TakeTripAsp.Core.Migrations
{
    [DbContext(typeof(TakeTripAspDbContext))]
    partial class TakeTripAspDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
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
                            Id = "bbcaa020-8906-460f-84e9-501c17e1ed4a",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "024f0d10-07f0-4658-bda2-a5682e8f1ce1",
                            Name = "seller",
                            NormalizedName = "SELLER"
                        },
                        new
                        {
                            Id = "b413732d-f91d-400e-96e8-33ea08ca0577",
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
                            UserId = "19f78ca5-1819-4ca5-a6a6-7d2292772e3a",
                            RoleId = "bbcaa020-8906-460f-84e9-501c17e1ed4a"
                        },
                        new
                        {
                            UserId = "edd17eef-158d-46c9-9036-8120799ccb0e",
                            RoleId = "024f0d10-07f0-4658-bda2-a5682e8f1ce1"
                        },
                        new
                        {
                            UserId = "bc995625-b184-4552-accb-e873cbe984ce",
                            RoleId = "b413732d-f91d-400e-96e8-33ea08ca0577"
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
                            Id = "19f78ca5-1819-4ca5-a6a6-7d2292772e3a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2c558795-f376-4f0d-b09e-7d9f4d605409",
                            CoverPath = "\\img\\user\\user.jpg",
                            DateOfBirth = new DateTime(1998, 10, 27, 22, 19, 7, 803, DateTimeKind.Local).AddTicks(9354),
                            Email = "admin@taketrip.com",
                            EmailConfirmed = true,
                            FirstName = "Mariia",
                            LastName = "Kovalchuk",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@TAKETRIP.COM",
                            NormalizedUserName = "ADMIN@TAKETRIP.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEFjdWlkMSi/Va0YlZUBrR616nrZgg+szrVzXbG/ou+TT02ge8by+wEDd8PexlR5CbQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "50e0d2ab-f488-474c-9f71-9746b152852c",
                            TwoFactorEnabled = false,
                            UserName = "admin@taketrip.com"
                        },
                        new
                        {
                            Id = "edd17eef-158d-46c9-9036-8120799ccb0e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8b796489-ef58-4279-a5e4-d43efb35cc86",
                            CoverPath = "\\img\\user\\user.jpg",
                            DateOfBirth = new DateTime(1998, 10, 27, 22, 19, 7, 862, DateTimeKind.Local).AddTicks(8649),
                            Email = "seller@taketrip.com",
                            EmailConfirmed = true,
                            FirstName = "Ivan",
                            LastName = "Petrovych",
                            LockoutEnabled = false,
                            NormalizedEmail = "SELLER@TAKETRIP.COM",
                            NormalizedUserName = "SELLER@TAKETRIP.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMUbyQYjX0rriLIMEb0Vy7MTUV1UFNsLkqyPljaiwu7qq2hHs5PrcbmOrq6TQob64A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e8554423-bc83-4d68-a5a4-08b83384d293",
                            TwoFactorEnabled = false,
                            UserName = "seller@taketrip.com"
                        },
                        new
                        {
                            Id = "bc995625-b184-4552-accb-e873cbe984ce",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "70524826-23a0-4b04-a61f-5cecdb18e559",
                            CoverPath = "\\img\\user\\user.jpg",
                            DateOfBirth = new DateTime(1998, 10, 27, 22, 19, 7, 921, DateTimeKind.Local).AddTicks(6869),
                            Email = "client@taketrip.com",
                            EmailConfirmed = true,
                            FirstName = "Oleksandr",
                            LastName = "Shevchenko",
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENT@TAKETRIP.COM",
                            NormalizedUserName = "CLIENT@TAKETRIP.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOdiSNO3w1RLUeoOAETa6uEpnBOqoqO8vbNqKykzwK1i8vQv78IPV96U6BA3yUEl2Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "245c49ca-c4f5-4478-b133-1f6993f47bfe",
                            TwoFactorEnabled = false,
                            UserName = "client@taketrip.com"
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

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Continent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
