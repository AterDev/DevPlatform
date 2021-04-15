// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the demo root for license information.


using System.Collections.Generic;
using IdentityServer4.Models;

namespace Service.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResource("profile",
                    userClaims: new[] { "name", "email", "website" },
                    displayName: "Your profile data"),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResources.Address(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api"),
                new ApiScope("webapp"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // interactive spa client using code flow + pkce
                new Client
                {
                    ClientId = "webapp",
                    ClientName = "Ng Web Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,

                    RedirectUris = { "http://localhost:4200/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:4200/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:4200/signout-callback-oidc" },
                    BackChannelLogoutUri = "http://localhost:4200/signout-oidc",
                    AllowedCorsOrigins =     { "http://localhost:4200","https://localhost:4200" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "webapp" , "offline_access" }
                },
            };
    }
}
