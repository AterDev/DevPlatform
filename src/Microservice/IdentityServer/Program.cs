using Core.Models;
using EntityFramework;
using IdentityServer;
using Quartz;
using static OpenIddict.Abstractions.OpenIddictConstants;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// dbcontext
var connectionString = configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<DbContext>(options =>
    options.UseNpgsql(connectionString).UseOpenIddict());

services.AddDbContext<ContextBase>(opt => opt.UseNpgsql(connectionString));

// identity
services.AddIdentity<Account, Role>()
    .AddEntityFrameworkStores<ContextBase>()
    .AddDefaultTokenProviders();

// openid
services.Configure<IdentityOptions>(options =>
{
    options.ClaimsIdentity.UserNameClaimType = Claims.Name;
    options.ClaimsIdentity.UserIdClaimType = Claims.Subject;
    options.ClaimsIdentity.RoleClaimType = Claims.Role;
    options.ClaimsIdentity.EmailClaimType = Claims.Email;

    //options.SignIn.RequireConfirmedAccount = true;
});

services.AddQuartz(options =>
{
    options.UseMicrosoftDependencyInjectionJobFactory();
    options.UseSimpleTypeLoader();
    options.UseInMemoryStore();
});

services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

services.AddOpenIddict()
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore().UseDbContext<DbContext>();
        options.UseQuartz();
    })
    .AddServer(options =>
    {
        // enable endpoints
        options.SetAuthorizationEndpointUris("/connect/authorize")
            .SetLogoutEndpointUris("/connect/logout")
            .SetIntrospectionEndpointUris("/connect/introspect")
            .SetTokenEndpointUris("/connect/token")
            .SetUserinfoEndpointUris("/connect/userinfo")
            .SetVerificationEndpointUris("/connect/verify");

        // enable flows
        options.AllowAuthorizationCodeFlow()
            .AllowHybridFlow()
            .AllowPasswordFlow()
            .AllowClientCredentialsFlow()
            .AllowRefreshTokenFlow();

        // register scopes
        options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles, "dataEventRecords");

        options.AddDevelopmentEncryptionCertificate()
            .AddDevelopmentSigningCertificate();

        options.UseAspNetCore()
            .EnableAuthorizationEndpointPassthrough()
            .EnableLogoutEndpointPassthrough()
            .EnableTokenEndpointPassthrough()
            .EnableUserinfoEndpointPassthrough()
            .EnableStatusCodePagesIntegration();
    })
    .AddValidation(options =>
    {
        options.UseLocalServer();
        options.UseAspNetCore();
    });

// cors
services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
                .AllowCredentials()
                .WithOrigins("https://localhost:4200")
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});



var app = builder.Build();
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});
app.Run();
