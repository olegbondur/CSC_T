using System;
using System.Collections.Generic;
using System.IO;
using CSC_T.BusinessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using CSC_T.BusinessLayer.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CSC_T.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CSC_T.Api.Helpers;
using CSC_T.Api.Services.Interfaces;
using CSC_T.Api.Services;
using CSC_T.BusinessLayer.DAL;

namespace CSC_T.Api
{
    public class Startup
    {

        private const string SecretKey = "super_secret_key!!8855";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CSCDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("CSC_T.Api")
            ));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", build => build
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());
            });

            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IJwtFactory, JwtFactory>();

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });

            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<CSCDbContext>().AddDefaultTokenProviders();

            services.AddMvc();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Info { Title = "CSC Web API", Version = "v1", Description = "ASP.NET Core Web API" });

                swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SwaggerCSC.xml"));

                swagger.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "Please insert JWT with Bearer into field. Example: Bearer {token}",
                    Type = "apiKey"
                });
                swagger.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                     {"Bearer", new string[] {} }
                });
            });

            services.AddAutoMapper();
        }

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigin");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CSC Web API");
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
