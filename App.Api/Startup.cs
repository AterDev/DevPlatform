using Core.Services;
using Core.Services.Option;
using Data.Context;
using IGeekFan.AspNetCore.Knife4jUI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Services.AutoMapper;
using System.IO;
using System.Text;

namespace App.Api
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
            var connectionStrings = Configuration.GetConnectionString("Default");
            services.AddDbContext<CoreContext>(option =>
            {
                option.UseMySQL(connectionStrings, op => op.MigrationsAssembly("Data.Context"));
            });

            // 配置和依赖注入
            services.AddOptions();
            services.Configure<MailOption>(Configuration.GetSection("Mail"));
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddSingleton(typeof(EmailService));
            services.AddRepositories();


            // jwt
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                //cfg.RequireHttpsMetadata = true;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Jwt")["Sign"])),
                    ValidIssuer = Configuration.GetSection("Jwt")["Issuer"],
                    ValidAudience = Configuration.GetSection("Jwt")["Audience"],
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            // 定义policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("admin", "Admin"));
                options.AddPolicy("User", policy =>
                {
                    policy.RequireRole("user", "User", "admin");
                });
                options.AddPolicy("Customer", policy => policy.RequireRole("customer"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            // OpenApi
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API 文档",
                    Version = "v1",
                    Description = "DevPlatform",
                    Contact = new OpenApiContact
                    {
                        Email = "zpty@outlook.com",
                        Name = "Niltor",
                    }
                });
                c.AddServer(new OpenApiServer()
                {
                    Url = "",
                    Description = "DevPlatform"
                });
                c.CustomOperationIds(apiDesc =>
                 {
                     var controllerAction = apiDesc.ActionDescriptor as ControllerActionDescriptor;
                     return controllerAction.ControllerName + "-" + controllerAction.ActionName;
                 });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "App.Api.xml");
                c.IncludeXmlComments(filePath, true);
            });

            services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseKnife4UI(c =>
                {
                    c.RoutePrefix = "api/docs"; // serve the UI at root
                    c.SwaggerEndpoint("/v1/api-docs", "V1 Docs");
                });
                app.UseCors("AllowAll");
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger("{documentName}/api-docs");
            });
        }
    }
}
