// <auto-generated />
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
    [Migration("20201225145137_Removed_RestaurantDetail_from_WorkingTimes")]
    partial class Removed_RestaurantDetail_from_WorkingTimes
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
                            Created = new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195),
                            MinOrderPrice = 10f,
                            Name = "Test Restaurant",
                            Rating = 5f,
                            Updated = new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195)
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
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8f66d675-db8d-4be4-bf6d-46631ba2fe07",
                            Email = "cansarajlija+admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+ADMIN@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOLEq2wotChloMpq+LktDgbvI8oMap3lFm4YMNwaTM03wZKMCLWc1FvD+2LwgnNzPQ==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f65d58ba-ae73-433c-ab56-c17ef0b5f423",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+admin@gmail.com",
                            Created = new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195),
                            FirstName = "Can",
                            LastName = "Admin",
                            Updated = new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195)
                        },
                        new
                        {
                            Id = "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2d3c14aa-28e9-40a4-b055-bd062fdb340a",
                            Email = "cansarajlija+owner@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+OWNER@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+OWNER@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKc1e8twcnjtznJcO0+uRNlUnJ69UsT8Y6/jNMG2BsFQ100t1PiK7FsdPLHJPkQmzQ==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5b88d16f-b34c-427a-857d-9d30d34bebc1",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+owner@gmail.com",
                            Created = new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195),
                            FirstName = "Can",
                            LastName = "Owner",
                            Updated = new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195)
                        },
                        new
                        {
                            Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4340c4a0-8b6f-47e3-8eef-a130ceb1cf4d",
                            Email = "cansarajlija+user@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANSARAJLIJA+USER@GMAIL.COM",
                            NormalizedUserName = "CANSARAJLIJA+USER@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFqitu0QHdhC534xZqS05teoulhaOba9/JBRtseKHZuFdxf0ZeXxkmH0gshzLcMvqQ==",
                            PhoneNumber = "05313035675",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5dfb6f71-1b44-40a1-8bc1-74e590a54a09",
                            TwoFactorEnabled = false,
                            UserName = "cansarajlija+user@gmail.com",
                            Created = new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195),
                            FirstName = "Can",
                            LastName = "User",
                            Updated = new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195)
                        });
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
