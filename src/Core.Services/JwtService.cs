using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class JwtService
    {
        public JwtService()
        {
        }
        /// <summary>
        /// 生成jwt token
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        /// <param name="sign"></param>
        /// <param name="audience"></param>
        /// <param name="issuer"></param>
        /// <returns></returns>
        public string BuildToken(string id, string role, string sign, string audience, string issuer)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sign));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                // 此处自定义claims
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Role, role)
            };
            var jwt = new JwtSecurityToken(issuer, audience, claims, signingCredentials: signingCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
