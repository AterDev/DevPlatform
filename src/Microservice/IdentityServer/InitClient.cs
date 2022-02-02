using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace IdentityServer;

public static class InitClient
{
    public static OpenIddictApplicationDescriptor AdminClient = new()
    {
        ClientId = "webapp_admin",
        RedirectUris =
        {
            new Uri("https://localhost:4200/")
        },
        PostLogoutRedirectUris =
        {
            new Uri("https://localhost:4200/authentication/logout-callback")
        },
        Permissions =
        {
            Permissions.Endpoints.Authorization,
            Permissions.Endpoints.Logout,
            Permissions.Endpoints.Token,
            Permissions.GrantTypes.AuthorizationCode,
            Permissions.GrantTypes.RefreshToken,
            Permissions.ResponseTypes.Code,
            Permissions.Scopes.Email,
            Permissions.Scopes.Profile,
            Permissions.Scopes.Roles
        },
        Requirements =
        {
            Requirements.Features.ProofKeyForCodeExchange
        }
    };

    public static OpenIddictApplicationDescriptor Api = new()
    {
        ClientId = "api",
        RedirectUris =
        {
            new Uri("https://localhost:15002/")
        },
        Permissions =
        {
            Permissions.Endpoints.Introspection,
            Permissions.Endpoints.Authorization,
            Permissions.Endpoints.Token,
            Permissions.GrantTypes.AuthorizationCode,
            Permissions.ResponseTypes.Code
        }
    };
}
