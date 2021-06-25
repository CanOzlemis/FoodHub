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
    [Migration("20210303144207_Social_Media_Restaurant_Details")]
    partial class Social_Media_Restaurant_Details
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

                    b.HasIndex("RestaurantId");

                    b.ToTable("ActiveEarnings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RestaurantId = 1,
                            Total = 0f
                        });
                });

            modelBuilder.Entity("FoodHubAPI.Models.ApplicantRestaurants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("RestaurantStreet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicantRestaurants");
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

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<int>("AverageDeliveryTime")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MinOrderPrice")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("Id");

                    b.ToTable("RestaurantDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            About = "This restaurant is created only for testing environment. SHOULD NOT BE SEEN ON PRODUCTION",
                            Active = false,
                            Approved = false,
                            AverageDeliveryTime = 15,
                            City = "Antalya",
                            Created = new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218),
                            MinOrderPrice = 10f,
                            Name = "Test Restaurant",
                            Rating = 0f,
                            Street = "Muratpaşa/12. Cadde",
                            Updated = new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218)
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
                            ConcurrencyStamp = "b7fd9f6e-4f5e-40ee-af9e-cc55f46139e7",
                            Email = "cansarajlija+admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+ADMIN@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDZME0tD4VHh2PZFNDgQU3dku1cnbTwfgzZfNA7WbObknuYELP/+Lr1hRG1vheYbFg==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ce135086-6886-44a0-b157-a0ae0d621dcf",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+admin@gmail.com",
                            Created = new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218),
                            FirstName = "Can",
                            LastName = "Admin",
                            Updated = new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218)
                        },
                        new
                        {
                            Id = "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9927fcfd-9034-40e7-8823-f97542e520c5",
                            Email = "cansarajlija+owner@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+OWNER@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+OWNER@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOv/OL0VuT7K8a46IEkuYFtr1K2GCE7O/2Hqx0ndEvhney7PLVY8nW8u+/iI/Zny3Q==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9ae73731-9d2e-4aeb-a768-4829563b2346",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+owner@gmail.com",
                            Created = new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218),
                            FirstName = "Can",
                            LastName = "Owner",
                            Updated = new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218)
                        },
                        new
                        {
                            Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "912067e4-fe51-4a2c-aadf-04ad19cc34b3",
                            Email = "cansarajlija+user@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+USER@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+USER@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMVzjwU90IRSB+iBJS4ZqbBocyahJ5ulz8N5dY4AmARSfEY4S7Yeuj6a27hj85UPJA==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ad2ecf52-6d6c-456c-abbe-12c1e7247f42",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+user@gmail.com",
                            Created = new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218),
                            FirstName = "Can",
                            LastName = "User",
                            Updated = new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218)
                        });
                });

            modelBuilder.Entity("FoodHubAPI.Models.ActiveEarnings", b =>
                {
                    b.HasOne("FoodHubAPI.Models.RestaurantDetail", "RestaurantDetail")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantDetail");
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
