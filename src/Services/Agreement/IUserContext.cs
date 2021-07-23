using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Agreement
{
    /// <summary>
    /// 用户上下文
    /// </summary>
    public interface IUserContext
    {
        public Guid? UserId { get; init; }
        public Guid? SessionId { get; init; }
        public string Username { get; init; }
        public string Email { get; set; }
        public bool IsAdmin { get; init; }
        public string CurrentRole { get; set; }
        public List<string> Roles { get; set; }
        public Guid? GroupId { get; init; }
        Claim FindClaim(string claimType);
    }
}
