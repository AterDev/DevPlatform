using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        [Inject]
        public AuthService AuthService { get; set; }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, AuthService.Username??""),
                new Claim(ClaimTypes.Role,AuthService.Role??""),
                new Claim(ClaimTypes.NameIdentifier,AuthService.Id.ToString()??"")
            });
            // TODO? 验证状态
            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
