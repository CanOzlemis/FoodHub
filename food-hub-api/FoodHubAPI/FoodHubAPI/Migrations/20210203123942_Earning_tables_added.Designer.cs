﻿// <auto-generated />
using System;
using FoodHubAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodHubAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210203123942_Earning_tables_added")]
    partial class Earning_tables_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FoodHubAPI.Models.ActiveEarnings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("ActiveEarnings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RestaurantId = 1,
                            Total = 0f
                        });
                });

            modelBuilder.Entity("FoodHubAPI.Models.EarningsHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EarningsHistory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Month = 12,
                            RestaurantId = 1,
                            Total = 13254.75f,
                            Year = 2019
                        },
                        new
                        {
                            Id = 2,
                            Month = 1,
                            RestaurantId = 1,
                            Total = 1710.25f,
                            Year = 2020
                        });
                });

            modelBuilder.Entity("FoodHubAPI.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("FoodHubAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("FoodHubAPI.Models.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ProductUnitPrice")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("FoodHubAPI.Models.RatingAndReview", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RatingAndReview");
                });

            modelBuilder.Entity("FoodHubAPI.Models.RestaurantDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("About")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<int>("AverageDeliveryTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<float>("MinOrderPrice")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("Id");

                    b.ToTable("RestaurantDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            About = "This restaurant is created only for testing environment. SHOULD NOT BE SEEN ON PRODUCTION",
                            Approved = false,
                            AverageDeliveryTime = 15,
                            Created = new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895),
                            MinOrderPrice = 10f,
                            Name = "Test Restaurant",
                            Rating = 0f,
                            Updated = new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895)
                        });
                });

            modelBuilder.Entity("FoodHubAPI.Models.RestaurantOwner", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantOwner");

                    b.HasData(
                        new
                        {
                            UserId = "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                            RestaurantId = 1
                        });
                });

            modelBuilder.Entity("FoodHubAPI.Models.WorkingTimes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<TimeSpan>("CloseTime")
                        .HasColumnType("time");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("OpenTime")
                        .HasColumnType("time");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("WorkingTimes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CloseTime = new TimeSpan(0, 22, 0, 0, 0),
                            Day = 0,
                            OpenTime = new TimeSpan(0, 7, 0, 0, 0),
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            CloseTime = new TimeSpan(0, 22, 0, 0, 0),
                            Day = 1,
                            OpenTime = new TimeSpan(0, 7, 0, 0, 0),
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            CloseTime = new TimeSpan(0, 22, 0, 0, 0),
                            Day = 2,
                            OpenTime = new TimeSpan(0, 7, 0, 0, 0),
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 4,
                            CloseTime = new TimeSpan(0, 22, 0, 0, 0),
                            Day = 3,
                            OpenTime = new TimeSpan(0, 7, 0, 0, 0),
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 5,
                            CloseTime = new TimeSpan(0, 22, 0, 0, 0),
                            Day = 4,
                            OpenTime = new TimeSpan(0, 7, 0, 0, 0),
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 6,
                            CloseTime = new TimeSpan(0, 22, 0, 0, 0),
                            Day = 5,
                            OpenTime = new TimeSpan(0, 7, 0, 0, 0),
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 7,
                            CloseTime = new TimeSpan(0, 22, 0, 0, 0),
                            Day = 6,
                            OpenTime = new TimeSpan(0, 7, 0, 0, 0),
                            RestaurantId = 1
                        });
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

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "1",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "2",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3",
                            ConcurrencyStamp = "3",
                            Name = "Owner",
                            NormalizedName = "OWNER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                            RoleId = "3"
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

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FoodHubAPI.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "048b518e-68a5-4eae-bd10-e5a8f77c91e9",
                            Email = "cansarajlija+admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+ADMIN@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFxHFTd5YwH0JtyjYpufhz67F+XlKytrEVkmyXgDdUpZd7dGQZJasOJoxvPye+8LcQ==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e87165cb-d8da-4e17-a16e-623e011c0c88",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+admin@gmail.com",
                            Created = new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895),
                            FirstName = "Can",
                            LastName = "Admin",
                            Updated = new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895)
                        },
                        new
                        {
                            Id = "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "95a7751b-8577-4596-bc23-affce45360c6",
                            Email = "cansarajlija+owner@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+OWNER@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+OWNER@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEIsY7eHulcMSD9ycS9kFswdvwd5AxKLMf8TMQkjiMmhnokUz3emzpbUz3NM/qQBMIA==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6f21a69f-9f2c-4094-928c-8ba21c73f5ca",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+owner@gmail.com",
                            Created = new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895),
                            FirstName = "Can",
                            LastName = "Owner",
                            Updated = new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895)
                        },
                        new
                        {
                            Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "47881711-bb43-4b36-a93e-8eb10028e2bb",
                            Email = "cansarajlija+user@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+USER@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+USER@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ21gQ+7rfdadkPJSkKaxH9vanExqp7OfhrF80PvkmFghn5lsSFjjg65Vfi+wy7JIQ==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9bebcfa3-02b0-4dfa-9087-6a1d3f418b09",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+user@gmail.com",
                            Created = new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895),
                            FirstName = "Can",
                            LastName = "User",
                            Updated = new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895)
                        });
                });

            modelBuilder.Entity("FoodHubAPI.Models.Menu", b =>
                {
                    b.HasOne("FoodHubAPI.Models.RestaurantDetail", "RestaurantDetail")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantDetail");
                });

            modelBuilder.Entity("FoodHubAPI.Models.Order", b =>
                {
                    b.HasOne("FoodHubAPI.Models.RestaurantDetail", "RestaurantDetail")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodHubAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantDetail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodHubAPI.Models.OrderDetails", b =>
                {
                    b.HasOne("FoodHubAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FoodHubAPI.Models.RatingAndReview", b =>
                {
                    b.HasOne("FoodHubAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodHubAPI.Models.RestaurantDetail", "RestaurantDetail")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Order");

                    b.Navigation("RestaurantDetail");
                });

            modelBuilder.Entity("FoodHubAPI.Models.RestaurantOwner", b =>
                {
                    b.HasOne("FoodHubAPI.Models.RestaurantDetail", "RestaurantDetail")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodHubAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantDetail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodHubAPI.Models.WorkingTimes", b =>
                {
                    b.HasOne("FoodHubAPI.Models.RestaurantDetail", "RestaurantDetail")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantDetail");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}