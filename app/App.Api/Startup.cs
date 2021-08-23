using System.IO;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Services;
using EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Share.AutoMapper;
using Services.Agreement;
using App.Api.Controllers;
using Services.Repositories;
using Services.Azure;

namespace App.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<IUserContext, UserContext>();
            services.AddRepositories();
            services.Configure<AzureOptions>(Configuration.GetSection("Azure"));
            services.AddOptions();
            services.AddScoped(typeof(WebService));
            services.AddScoped(typeof(FileService));

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<ContextBase>(option =>
                {
                    option.UseNpgsql(connectionString, sql => { sql.MigrationsAssembly("EntityFrameworkCore"); });
                });

            #region 接口相关内容:jwt/授权/cors
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
                    // 如果不如果jwt，可注释掉，你可能会使用IdentityServer
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Jwt")["Sign"])),
                    ValidIssuer = Configuration.GetSection("Jwt")["Issuer"],
                    ValidAudience = Configuration.GetSection("Jwt")["Audience"],
                    ValidateIssuer = true,
                    ValidateLifetime = false,
                    RequireExpirationTime = false,
                    ValidateAudience = false,
                    //ValidateIssuerSigningKey = true
                };
            });
            // 验证
            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy =>
                    policy.RequireRole("Admin", "User"));
                options.AddPolicy("Admin", policy =>
                    policy.RequireRole("Admin"));
            });

            // services.AddScoped(typeof(JwtService)); 
            // cors配置 
            services.AddCors(options =>
            {
                options.AddPolicy("default", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            #endregion

            // api 接口文档设置
            services.AddOpenApiDocument(c =>
            {
                c.GenerateXmlObjects = true;
                c.GenerateEnumMappingDescription = true;
                c.UseControllerSummaryAsTagDescription = true;
                c.PostProcess = (document) =>
                {
                    document.Info.Title = "Dev Platform";
                    document.Info.Description = "Api 文档";
                    document.Info.Version = "1.0";
                };
            });
            services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("default");
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3(c => { c.DocumentTitle = "文档"; });
                app.UseStaticFiles();
            }
            else
            {
                // 生产环境需要新的配置
                app.UseCors("default");
                app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
                app.UseHttpsRedirection();
            }

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
