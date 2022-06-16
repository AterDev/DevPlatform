using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddDataStore();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DocsContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddOpenApiDocument(c =>
{
    c.GenerateXmlObjects = true;
    c.GenerateEnumMappingDescription = true;
    c.UseControllerSummaryAsTagDescription = true;
    c.PostProcess = (document) =>
    {
        document.Info.Title = "Docs Api";
        document.Info.Description = "Docs Api 文档";
        document.Info.Version = "1.0";
    };
});
// jwt
builder.Services.AddAuthentication(options =>
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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt")["Sign"])),
        ValidIssuer = builder.Configuration.GetSection("Jwt")["Issuer"],
        ValidAudience = builder.Configuration.GetSection("Jwt")["Audience"],
        ValidateIssuer = true,
        ValidateLifetime = true,
        RequireExpirationTime = false,
        ValidateIssuerSigningKey = true
    };
});
// 授权
builder.Services.AddAuthorization(options =>
{
});

// cors配置 
builder.Services.AddCors(options =>
{
    options.AddPolicy("default", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
     }); ;


var app = builder.Build();

// 初始化管理员账号
await using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DocsContext>();
    context.Database.EnsureCreated();

    var store = scope.ServiceProvider.GetRequiredService<UserDataStore>();
    var admin = store.Db.Where(u => u.UserName == "admin").FirstOrDefault();
    if (admin == null)
        await store.InitAdminUserAsync("admin", "admin123.");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(c => { c.DocumentTitle = "文档"; });
    app.UseStaticFiles();
}
app.UseCors("default");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();