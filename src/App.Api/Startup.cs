using System.IO;
using System.Security.Claims;
using System.Text;
using AutoMapper;
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
using Share.AutoMapper;

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
            // 使用cli工具生成仓储，请取消以下注释
            services.AddRepositories();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddHttpContextAccessor();
            services.AddOptions();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<ContextBase>(option =>
                {
                    option.UseNpgsql(connectionString, sql => { sql.MigrationsAssembly("Data.Context"); });
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
                options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Name));
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API 文档",
                    Version = "v1",
                    Description = "Description",
                    Contact = new OpenApiContact
                    {
                        Email = "YourEmail",
                        Name = "Name",
                    }
                });
                c.AddServer(new OpenApiServer()
                {
                    Url = "",
                    Description = "Description"
                });
                c.CustomOperationIds(apiDesc =>
                {
                    var controllerAction = apiDesc.ActionDescriptor as ControllerActionDescriptor;
                    return controllerAction.ControllerName + "-" + controllerAction.ActionName;
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "App.Api.xml");
                c.IncludeXmlComments(filePath, true);
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
                app.UseSwagger();

                app.UseKnife4UI(c =>
                {
                    c.RoutePrefix = "api/docs"; // serve the UI at root
                    c.SwaggerEndpoint("/v1/api-docs", "V1 Docs");
                });
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
                endpoints.MapSwagger("{documentName}/api-docs");
            });
        }
    }
}
