using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Agreement
{
    public class UserContext : IUserContext
    {
        public Guid? UserId { get; init; }
        public Guid? SessionId { get; init; }
        public string Username { get; init; }
        public string Email { get; set; }
        public string CurrentRole { get; set; }
        public List<string> Roles { get; set; }
        public Guid? GroupId { get; init; }

        private readonly HttpContext _httpContext;
        public UserContext(
            IHttpContextAccessor httpContextAccessor
            )
        {
            _httpContext = httpContextAccessor.HttpContext;
            if (Guid.TryParse(FindClaim(ClaimTypes.NameIdentifier)?.Value, out Guid userId) && userId != Guid.Empty)
            {
                UserId = userId;
            }
            if (Guid.TryParse(FindClaim(ClaimTypes.GroupSid)?.Value, out Guid groupSid) && groupSid != Guid.Empty)
            {
                GroupId = groupSid;
            }
            Username = FindClaim(ClaimTypes.Name)?.Value;
            Email = FindClaim(ClaimTypes.Email)?.Value;
            CurrentRole = FindClaim(ClaimTypes.Role)?.Value;
        }

        public Claim FindClaim(string claimType)
        {
            return _httpContext.User?.FindFirst(claimType);
        }

    }
}
