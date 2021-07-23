using ETrafficViolationSystem.API.Configuration;
using ETrafficViolationSystem.API.Extensions;
using ETrafficViolationSystem.API.Filters;
using ETrafficViolationSystem.Common.Configurations;
using ETrafficViolationSystem.Data.Context;
using ETrafficViolationSystem.Entities.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrafficViolationSystem.API
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
            // CORS Policy
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // Database Context
            services.AddDbContext<ETrafficViolationSystemContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Fluent Validation/Custom Validation/ Configuration
            services.AddControllers(options =>
            {
                options.Filters.Add<CustomModelValidationFilter>();
                options.ReturnHttpNotAcceptable = true;
            }).AddFluentValidation(configuration =>
            {
                configuration.RegisterValidatorsFromAssemblyContaining<Startup>();
                configuration.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            }).AddXmlDataContractSerializerFormatters();

            // Registering AutoMapper Mappings
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // API Versions
            services.AddApiVersioning(version =>
            {
                version.DefaultApiVersion = new ApiVersion(1, 1);
                version.AssumeDefaultVersionWhenUnspecified = true;
                version.ReportApiVersions = true;
            });

            //Dependency Injection
            DependencyInjectionConfig.AddScoped(services);
            services.AddSingleton(provider => Configuration);
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.SuppressModelStateInvalidFilter = true;
            });
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            services.Configure<ResponseMessages>(Configuration.GetSection("ResponseMessages"));

            // Registering Identity For Authentication & Authorization
            services.AddIdentity<Users, Roles>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(2);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = true;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ETrafficViolationSystemContext>()
                .AddTokenProvider<DataProtectorTokenProvider<Users>>("ETrafficViolationSystem.API");

            // JWT Authentication Settings
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidIssuer = Configuration.GetValue<string>("JwtConfig:Issuer"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(Configuration.GetValue<string>("JwtConfig:Secret"))),
                    ValidateIssuer = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Swagger Configuration
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ETrafficViolationSystem.API",
                    Version = "v1"
                });
                // To Enable authorization using Swagger (JWT)  
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}

                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ETrafficViolationSystem.API v1");
                    c.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ETrafficViolationSystem.API v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.ConfigureCustomMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStatusCodePages();
        }
    }
}