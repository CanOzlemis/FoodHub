using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodHubAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using FoodHubAPI.Models.Interface;

namespace FoodHubAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "FoodHub API", Version = "v1" });
            });


            //Inject Appsettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DeveloperConnection"))
            );

            services.AddDefaultIdentity<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();



            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                options.User.RequireUniqueEmail = true;
            }
           );

            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddCors();

            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings")); //Accessing the appsettings.json settings


            //JWS authentication

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString()); //a 16 digit key. Can be changed

            services.AddAuthentication(x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
           }).AddJwtBearer ( x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = false;  //After succesfull login saving the token in server
               x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ClockSkew = TimeSpan.Zero
               };
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(x =>
          {
              x.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodHub API V1");
          });

           app.UseCors(opt =>
           opt.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString()) // THE LINK THAT THE WEB APPLICATION WILL BE AT
           .AllowAnyMethod()
           .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
