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
    [Migration("20201225145852_Colum_fix_for_FK")]
    partial class Colum_fix_for_FK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

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
                            Created = new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267),
                            MinOrderPrice = 10f,
                            Name = "Test Restaurant",
                            Rating = 5f,
                            Updated = new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267)
                        });
                });

            modelBuilder.Entity("FoodHubAPI.Models.RestaurantOwner", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

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
                            ConcurrencyStamp = "8917b58e-ff75-4c85-8cd8-f6096609b906",
                            Email = "cansarajlija+admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+ADMIN@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOYPCpAO07ri2uhfZXzWzOmMPeNRrYmNFtajMCI9cbgclbg3CsSn5fBXYkmERi7Oow==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "191d26e6-5854-4dd4-9ec6-62e1de8334fe",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+admin@gmail.com",
                            Created = new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267),
                            FirstName = "Can",
                            LastName = "Admin",
                            Updated = new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267)
                        },
                        new
                        {
                            Id = "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0f276f0a-b034-4753-bd74-37148110a97e",
                            Email = "cansarajlija+owner@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+OWNER@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+OWNER@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEHkJSHSVYWwBseK5/kEUV28LAWZfNIP4kjw2m+kB1lEMRNqGxxsovI4n1ACCD3wAlQ==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "50854290-d472-4630-b799-a4bead75e8e9",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+owner@gmail.com",
                            Created = new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267),
                            FirstName = "Can",
                            LastName = "Owner",
                            Updated = new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267)
                        },
                        new
                        {
                            Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4606b2df-645a-463d-8c8e-8b7875a0f41b",
                            Email = "cansarajlija+user@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+USER@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+USER@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEL8HdU1zStnvmZqE+7e71xtkS/Pr/pljOi8SBHLX2hMoEVZzpdusjZbnd2cM+qUYJQ==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a9069b9b-de66-43ee-8d8f-4d9945461a77",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+user@gmail.com",
                            Created = new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267),
                            FirstName = "Can",
                            LastName = "User",
                            Updated = new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267)
                        });
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