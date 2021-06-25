using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class ApplicationContext:IdentityDbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){ }

        public DbSet<RestaurantDetail> RestaurantDetails { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<RestaurantOwner> RestaurantOwner { get; set; }
        public DbSet<WorkingTimes> WorkingTimes { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<RatingAndReview> RatingAndReview { get; set; }
        public DbSet<PreviousEarnings> PreviousEarnings { get; set; }
        public DbSet<ApplicantRestaurants> ApplicantRestaurants { get; set; }
        public DbSet<FavouriteRestaurants> FavouriteRestaurants { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<BanList> BanList { get; set; }


        /// <summary>
        /// Seeder. While the database is being created, this function adds the data inside
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string USER_ID =  "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            string OWNER_ID = "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6";

            //Seeding the roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "1",
                    ConcurrencyStamp = "1"
                },
                new IdentityRole {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = "2",
                    ConcurrencyStamp = "2"
                },
                new IdentityRole {
                    Name = "Owner",
                    NormalizedName = "OWNER",
                    Id = "3",
                    ConcurrencyStamp = "3"
                }
            );

            var now = DateTime.Now;

            //create test user
            List<User> appUsers = new List<User> {
                new User {
                    Id = ADMIN_ID,
                    EmailConfirmed = true,
                    UserName = "cansarajlija+admin@gmail.com",
                    NormalizedUserName = "CANSARAJLIJA+ADMIN@GMAIL.COM",
                    FirstName = "Can",
                    LastName = "Admin",
                    Email = "cansarajlija+admin@gmail.com",
                    NormalizedEmail = "CANSARAJLIJA+ADMIN@GMAIL.COM",
                    PhoneNumber = "05313035675",
                    Created = now,
                    Updated = now
                },
                new User {
                    Id = OWNER_ID,
                    EmailConfirmed = true,
                    UserName = "cansarajlija+owner@gmail.com",
                    NormalizedUserName = "CANSARAJLIJA+OWNER@GMAIL.COM",
                    FirstName = "Can",
                    LastName = "Owner",
                    Email = "cansarajlija+owner@gmail.com",
                    NormalizedEmail = "CANSARAJLIJA+OWNER@GMAIL.COM",
                    PhoneNumber = "05313035675",
                    Created = now,
                    Updated = now
                },
                new User {
                    Id = USER_ID,
                    EmailConfirmed = true,
                    UserName = "cansarajlija+user@gmail.com",
                    NormalizedUserName = "CANSARAJLIJA+USER@GMAIL.COM",
                    FirstName = "Can",
                    LastName = "User",
                    Email = "cansarajlija+user@gmail.com",
                    NormalizedEmail = "CANSARAJLIJA+USER@GMAIL.COM",
                    PhoneNumber = "05313035675",
                    Created = now,
                    Updated = now
                }

            };

            foreach ( var appUser in appUsers) {
                //Set the password for the user
                PasswordHasher<User> hashedPassword = new PasswordHasher<User>();
                appUser.PasswordHash = hashedPassword.HashPassword(appUser, "Test1234");
                //Seeding the user
                builder.Entity<User>().HasData(appUser);
            }


            //set user roles
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>{ RoleId = "1", UserId = USER_ID },
                new IdentityUserRole<string>{ RoleId = "2", UserId = ADMIN_ID },
                new IdentityUserRole<string>{ RoleId = "3", UserId = OWNER_ID }
            );

            builder.Entity<Feedback>().HasData(
                new Feedback { 
                    Id = 1,
                    UserId = USER_ID,
                    Created = DateTime.Now,
                    Type = Enum.enums.FeedbackType.Suggestion.ToString(),
                    Message = "This is a SUGGESTION feedback message from a normal user account"
                },
                new Feedback
                {
                    Id = 2,
                    UserId = USER_ID,
                    Created = DateTime.Now,
                    Type = Enum.enums.FeedbackType.BugReport.ToString(),
                    Message = "This is a BUG REPORT feedback message from a normal user account"
                },
                new Feedback
                {
                    Id = 3,
                    UserId = USER_ID,
                    Created = DateTime.Now,
                    Type = Enum.enums.FeedbackType.SomethingElse.ToString(),
                    Message = "This is a SOMETHING ELSE  feedback message from a normal user account"
                },
                new Feedback
                {
                    Id = 4,
                    UserId = USER_ID,
                    Created = DateTime.Now,
                    Type = Enum.enums.FeedbackType.Question.ToString(),
                    Message = "This is a QUESTION  feedback message from a normal user account"
                }
                );

            //Seeding a test restaurant for testing purpouses
            builder.Entity<RestaurantDetail>().HasData(
                new RestaurantDetail
                {
                    Id = 1,
                    Name = "Test Restaurant",
                    About = "This restaurant is created only for testing environment. SHOULD NOT BE SEEN ON PRODUCTION",
                    City = "Antalya",
                    Street = "Muratpaşa/12. Cadde",
                    Rating = 0,
                    AverageDeliveryTime = 15,
                    MinOrderPrice = 10,
                    Approved = false,
                    Created = now,
                    Updated = now
                }
            );

            //assign restaurant to the owner
            builder.Entity<RestaurantOwner>().HasData(
                new RestaurantOwner
                {
                    RestaurantId = 1,
                    UserId = OWNER_ID
                });


            //Set the test restaurant working times
            List<WorkingTimes> allWorkingTimes = new List<WorkingTimes> { };
            for(var i = 0; i < 7; i++)
            {
                allWorkingTimes.Add(new WorkingTimes
                {
                    Id = i+1,
                    RestaurantId = 1,
                    Day = i,
                    OpenTime = new TimeSpan(7, 0, 0),
                    CloseTime = new TimeSpan(22, 0, 0)
                });
            }
            builder.Entity<WorkingTimes>().HasData(allWorkingTimes);


            //Initialising active earning row for the test restaurant
            builder.Entity<PreviousEarnings>().HasData(
                new PreviousEarnings
                {
                    Id = 1,
                    RestaurantId = 1,
                    Total = 0
                });

        }

    }
}
