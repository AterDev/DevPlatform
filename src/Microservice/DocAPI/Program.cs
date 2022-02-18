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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();